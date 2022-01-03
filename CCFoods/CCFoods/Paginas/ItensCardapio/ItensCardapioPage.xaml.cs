using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Modulo1.Paginas.ItensCardapio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItensCardapioPage : ContentPage
    {
        public ItensCardapioPage()
        {
            InitializeComponent();
            BtnNovoItem.Clicked += BtnNovoItemClick;
        }

        private async void BtnNovoItemClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItensCardapioNewPage());
        }
    }
}