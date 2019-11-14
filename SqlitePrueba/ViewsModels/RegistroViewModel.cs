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

namespace SqlitePrueba.ViewsModels
{
    public class RegistroViewModel : BaseViewModel
    {
        private String name;
        private String lastname;

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
