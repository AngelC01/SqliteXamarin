using System;
using SqlitePrueba.ViewsModels;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Xamarin.Forms;
using SqlitePrueba.Views;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SqlitePrueba.Models;
using Plugin.Media;

namespace SqlitePrueba.ViewsModels
{
    public class RegistroViewModel : BaseViewModel
    {
        private String name;
        private String lastname;
        private ImageSource imagProfile;  //Binding con el source de la imagen como la etiqueta imagen tiene source es este source
        //que debo crear en las propiedades
        public ImageSource ImagProfile
        {
            get { return this.imagProfile; }
            set { SetValue(ref this.imagProfile, value); }
        }

        public String Name
        {
            get { return this.name; }
            set { SetValue(ref this.name, value); }
        }

        public String LastName
        {
            get { return this.lastname; }
            set { SetValue(ref this.lastname, value); }
        }

        public ICommand SeleccionarFotoCommand
        {
            get
            {
                return new RelayCommand(SeleccionarFoto);
            }

        }

        private async void SeleccionarFoto()
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,

            });


            if (file == null)
            {
                return;
            }
                

            ImagProfile = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }


        public ICommand TomarFotoCommand
        {
            get
            {
                return new RelayCommand(TomarFoto);    
            }
        }

        private async void TomarFoto()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000,
                DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front
            });

            if (file == null)
                return;

            await Application.Current.MainPage.DisplayAlert("File Location", file.Path, "OK");

            ImagProfile = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }

        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(Register);
            }
        }
        public ICommand ConsultarCommand
        {
            get
            {
                return new RelayCommand(Consultar);
            }
        }

        private async void Register()
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   "Debe ingresar  nombre",
                   "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.LastName))
            {
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   "Debe ingresar apelldio",
                   "Aceptar");
                return;
            }


            
            UserRepository.Instancia.AddNewUser(this.Name, this.LastName);
            BlanquearTxt();
        }

        private async void Consultar()
        {
            

            BlanquearTxt();
           
            MainViewModel.GetInstance().Consulta = new ConsultaViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ConsultaPage());
        }

        

        private void BlanquearTxt()
        {
            this.Name = string.Empty;
            this.LastName = string.Empty;
        }
    }

}
