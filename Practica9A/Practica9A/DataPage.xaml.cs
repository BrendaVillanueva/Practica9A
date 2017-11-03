using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.ObjectModel;

namespace Practica9A
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataPage : ContentPage
    {
        public ObservableCollection<_13090416> Items { get; set; }
        public static MobileServiceClient cliente;
        public static IMobileServiceTable<_13090416> Tabla;

        public DataPage()
        {
            InitializeComponent();

            cliente = new MobileServiceClient(AzureConnection.AzureURL);
            Tabla = cliente.GetTable<_13090416>();
            LeerTabla();


        }

        private void Insertar_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new InsertPage());

        }

        private void Button_Mostrar_Datos_Eliminados_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DeletePage());
        }


        public async void LeerTabla()
        {
            IEnumerable<_13090416> elementos = await Tabla.ToEnumerableAsync();
            Items = new ObservableCollection<_13090416>(elementos);
            BindingContext = this;
        }

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            await Navigation.PushAsync(new SelectPage(e.SelectedItem as _13090416));
        }

    }
}