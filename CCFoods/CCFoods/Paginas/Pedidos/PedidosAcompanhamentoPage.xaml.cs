using Modulo1.DAL;
using Modulo1.RESTServices;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Modulo1.Paginas.Pedidos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PedidosAcompanhamentoPage : ContentPage
    {
        private IGeolocator locator;
        private LocalizacaoEntregadorDAL localizacaoDAL = new LocalizacaoEntregadorDAL();
        private LocalizacaoEntregadorREST services = new LocalizacaoEntregadorREST();

        public PedidosAcompanhamentoPage()
        {
            InitializeComponent();
            locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            locator.PositionChanged += OnPositionChanged;
        }
        private async void OnPositionChanged(object obj, PositionEventArgs e)
        {
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Xamarin.Forms.Maps.Position(e.Position.Latitude, e.Position.Longitude),
                Distance.FromKilometers(0.3f)));
            var localPin = new Pin()
            {
                Position = new Xamarin.Forms.Maps.Position(e.Position.Latitude, e.Position.Longitude),
                Label = "Entregador/" + e.Position.Timestamp.ToLocalTime().TimeOfDay
            };
            MyMap.Pins.Add(localPin);

            await UpdateToServer();
            await UpdateDispositivo();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            locator.StartListeningAsync(TimeSpan.FromMilliseconds(60000), 50);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            locator.StopListeningAsync();
        }

        private async Task UpdateToServer()
        {
            await services.UpdateLocalizacaoToServerAsync(localizacaoDAL.GetAllInseridoDispositivo());
        }

        private async Task UpdateDispositivo()
        {
            var localizacoesServer = await services.GetLocalizacoesAsync();
            var localizacoesDispositivo = localizacaoDAL.GetAll();
            var localizacoesAtualizado = localizacoesServer.Except(localizacoesDispositivo);

            foreach (var garcomNovo in localizacoesAtualizado)
            {
                localizacaoDAL.Add(garcomNovo);
            }
        }
    }
}