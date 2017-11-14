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
    public partial class SelectPage : ContentPage
    {
        public SelectPage(object selectedItem)
        {
            var dato = selectedItem as _13090416;
            BindingContext = dato;

            InitializeComponent();


            string[] semestres = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            Picker_Semestre.ItemsSource = semestres;
            Picker_Semestre.SelectedItem = dato.Semestre;
            //PICKER CARRERAS
            string[] carreras = { "Ing. Sistemas Computacionales", "Ing.Industrial", "Ing.Civil", "Ing. Mecatronica", "Lic.Biologia", "Lic. Administracion", "Lic.Gastronomia" };
            Picker_Carrera.ItemsSource = carreras;
            Picker_Carrera.SelectedItem = dato.Carrera;
        }

        private async  void Button_Actualizar_Clicked(object sender, EventArgs e)
        {
            var datos = new _13090416
            {
                Matricula = Entry_Matricula.Text,
                Nombre = Entry_Nombre.Text,
                Apellidos = Entry_Apellido.Text,
                Direccion = Entry_Direccion.Text,
                Telefono = Entry_Telefono.Text,
                Carrera = Convert.ToString(Picker_Carrera.SelectedItem),
                Semestre = Convert.ToString(Picker_Semestre.SelectedItem),
                Correo = Entry_Correo.Text,
                Github = Entry_GitHub.Text

            };
            await DataPage.Tabla.UpdateAsync(datos);
            await Navigation.PopAsync();
        }

        private async void Button_Eliminar_Clicked(object sender, EventArgs e)
        {
            var datos = new _13090416
            {
                Matricula = Entry_Matricula.Text,


            };
            await DataPage.Tabla.DeleteAsync(datos);
            await Navigation.PopAsync();

        }
    }
}