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
    public class RegistroViewModel:BaseViewModel
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

        private void Register()
        {
            UserRepository.Instancia.AddNewUser(this.Name, this.LastName);
        }

        private async void Consultar()
        {

            MainViewModel.GetInstance().Consulta= new ConsultaViewModel();
            
            await Application.Current.MainPage.Navigation.PushAsync(new ConsultaPage());
        }


    }

}
