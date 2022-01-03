﻿using Modulo1.Dal;
using Plugin.Media;
using System;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Modulo1.Modelo;

namespace Modulo1.Paginas.TiposItensCardapio
{
    public partial class TiposItensCardapioNewPage : ContentPage
    {
        private byte[] bytesFoto;
        private TipoItemCardapioDAL dalTipoItemCardapio = new TipoItemCardapioDAL();


        public TiposItensCardapioNewPage()
        {
            InitializeComponent();
            PreparaParaNovoTipoItemCardapio();
            RegistraClickBotaoCamera();
            RegistraClickBotaoAlbum();
        }

        private void PreparaParaNovoTipoItemCardapio()
        {
            nome.Text = string.Empty;
            fototipoitemcardapio.Source = null;
        }

        private void RegistraClickBotaoCamera()
        {
            // Criação do método anônimo para captura do evento click do botão
            BtnCamera.Clicked += async (sender, args) =>
            {
                // Inicialização do plugin de interação com a câmera e álbum
                await CrossMedia.Current.Initialize();
                // Verificação de disponibilização da câmera e se é possível tirar foto
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("Não existe câmera", "A câmera não está  disponível.", "OK");
                    return;
                }
                /* Método que habilita a câmera, informando a pasta onde a foto deverá
                    ser armazenada, o nome a ser dado ao arquivo e se é ou não para 
                    armazenar a foto também no álbum */
                var file = await CrossMedia.Current.TakePhotoAsync(
              new Plugin.Media.Abstractions.StoreCameraMediaOptions
              {
                  Directory = "Fotos",
                  Name = "tipoitem.jpg",
                  SaveToAlbum = true
              });
                // Caso o usuário não tenha tirado a foto, clicando no botão cancelar
                if (file == null)
                    return;

                var stream = file.GetStream();
                var memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);

                fototipoitemcardapio.Source = ImageSource.FromStream(() =>
                {
                    var s = file.GetStream();
                    file.Dispose();
                    return s;
                });
                bytesFoto = memoryStream.ToArray();
            };
        }
         
        private void RegistraClickBotaoAlbum()
        {
            BtnAlbum.Clicked += async (sender, args) =>
            {
                await CrossMedia.Current.Initialize();
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Álbum não suportado", "Não existe permissão para acessar o álbum de fotos", "OK");

                    return;
                }

                // Executa a seleção de uma foto do álbum
                var file = await CrossMedia.Current.PickPhotoAsync();
                if (file == null)
                    return;

                var stream = file.GetStream();
                var memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                fototipoitemcardapio.Source = ImageSource.FromStream(() =>
                {
                    var s = file.GetStream();
                    file.Dispose();
                    return s;
                });
                bytesFoto = memoryStream.ToArray();
            };
        }

        public void BtnGravarClick(object sender, EventArgs e)
        {
            if (nome.Text.Trim() == string.Empty)
            {
                this.DisplayAlert("Erro", "Você	precisa	informar o nome para o novo tipo de item do cardápio.", "Ok");
            }
            else
            {
                dalTipoItemCardapio.Add(new TipoItemCardapio()
                {
                    Nome = nome.Text,
                    Foto = bytesFoto
                });
                PreparaParaNovoTipoItemCardapio();
            }
        }

    }
}