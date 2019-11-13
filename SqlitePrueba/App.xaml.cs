using SqlitePrueba.Views;
using System;
using Xamarin.Forms;
using SqlitePrueba.Models;
using Xamarin.Forms.Xaml;

namespace SqlitePrueba
{
    public partial class App : Application
    {
        public App(String filename)
        {
            InitializeComponent();
            UserRepository.Incializador(filename);
            MainPage = new NavigationPage(new RegistroPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
