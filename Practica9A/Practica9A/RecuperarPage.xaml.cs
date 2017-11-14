using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.WindowsAzure.MobileServices;


namespace Practica9A
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecuperarPage : ContentPage
    {
        public RecuperarPage(object selectedItem)
        {
            var dato = selectedItem as _13090416;
            BindingContext = dato;

            InitializeComponent();
        }

        private async void Button_Recuperar_Clicked(object sender, EventArgs e)
        {
            var datos = new _13090416
            {
                Matricula= Entry_Matricula.Text

            };
            await DataPage.Tabla.UndeleteAsync(datos);
            await Navigation.PopAsync();
        }
    }
}