using Modulo1.Dal;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Modulo1.Paginas.Entregadores
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntregadoresListPage : ContentPage
    {
        private EntregadorDAL dalEntregador = new EntregadorDAL();
        public EntregadoresListPage()
        {
            InitializeComponent();
            lvEntregadores.ItemsSource = dalEntregador.GetAll();
        }
    }
}