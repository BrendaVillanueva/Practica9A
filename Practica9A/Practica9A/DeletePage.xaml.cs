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
    public partial class DeletePage : ContentPage
    {
        public ObservableCollection<_13090416> Items { get; set; }
        public static MobileServiceClient Cliente;
        public static IMobileServiceTable<_13090416> Tabla;

        public DeletePage()
        {
            Cliente = new MobileServiceClient(AzureConnection.AzureURL);
            Tabla = Cliente.GetTable<_13090416>();

            InitializeComponent();
        }


        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            await Navigation.PushAsync(new RecuperarPage(e.SelectedItem as _13090416));
        }


        private async void Button_Mostrar_Eliminados_Clicked(object sender, EventArgs e)
        {

            IEnumerable<_13090416> elementos = await Tabla.IncludeDeleted().Where(_13090416 => _13090416.Deleted == true).ToEnumerableAsync();
            Items = new ObservableCollection<_13090416>(elementos);
            BindingContext = this;
        }
    }
}