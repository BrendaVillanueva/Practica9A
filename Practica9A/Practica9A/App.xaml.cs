using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Practica9A
{
    public partial class App : Application
    {
        public static ISQLAzure Authenticador { get; private set; }

        public static void Init (ISQLAzure authenticator)
        {
            Authenticador = authenticator;
        }


        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Practica9A.DataPage());
        }

        protected override void OnStart() //COLOCAR EVENTO DE AUTENTICAR
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
