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
    public partial class InsertPage : ContentPage
    {
        public InsertPage()
        {
            InitializeComponent();

            string[] semestres = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            Picker_Semestre.ItemsSource = semestres;
            //PICKER CARRERAS
            string[] carreras = { "Ing. Sistemas Computacionales", "Ing.Industrial", "Ing.Civil", "Ing. Mecatronica", "Lic.Biologia", "Lic. Administracion", "Lic.Gastronomia" };
            Picker_Carrera.ItemsSource = carreras;
        }

        private async void Button_Insertar_Clicked(object sender, EventArgs e)
        {

            var datos = new _13090416
            {
                Nombre= Entry_Nombre.Text,
                Apellidos = Entry_Apellidos.Text,
                Direccion = Entry_Direccion.Text,
                Telefono = Entry_Telefono.Text,
                Carrera = Convert.ToString(Picker_Carrera.SelectedItem),
                Semestre = Convert.ToString(Picker_Semestre.SelectedItem),
                Correo = Entry_Correo.Text,
                Github = Entry_Github.Text
            };

            await DataPage.Tabla.InsertAsync(datos);

            await Navigation.PushAsync(new DataPage());

        }
    }
}