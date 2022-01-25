using Modulo1.Dal;
using Modulo1.Modelo;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Modulo1.Paginas.Entregadores
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntregadoresNewPage : ContentPage
    {
        private EntregadorDAL dalEntregadores = new EntregadorDAL();
        public EntregadoresNewPage()
        {
            InitializeComponent();
            PreparaParaNovoEntregador();
        }

        public void BtnGravarClick(object sender, EventArgs e)
        {
            if (nome.Text.Trim() == string.Empty || telefone.Text == string.Empty)
            {
                this.DisplayAlert("Erro", "Você precisa informar o nome e telefone para o novo entregador.", "Ok");
            }
            else
            {
                dalEntregadores.Add(new Entregador()
                {
                    Nome = nome.Text,
                    Telefone = telefone.Text
                });
                PreparaParaNovoEntregador();
            }
        }
        private void PreparaParaNovoEntregador()
        {
            nome.Text = string.Empty;
            telefone.Text = string.Empty;
        }
    }
}
