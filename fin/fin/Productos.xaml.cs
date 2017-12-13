using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace fin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Productos : ContentPage
    {
        public ObservableCollection<productos> Items { get; set; }

        public static MobileServiceClient cliente;
        public static IMobileServiceTable<productos> Tabla;
        public static MobileServiceUser usuario;

        public Productos()
        {
            InitializeComponent();
            cliente = new MobileServiceClient(AzureConnection.AzureURL);
            Tabla = cliente.GetTable<productos>();
        }

        private async void Producto_Clicked(object sender, EventArgs e)
        {
            if (txtNombre.Text == null || txtDescripcion.Text == null || txtPrecio.Text == null)
            {
                await DisplayAlert("Error", "Es obligatorio llenar todos los campos", "OK");
            }
            else
            {
                var datos = new productos
                {

                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = txtPrecio.Text
                };
                try
                {
                    await Tabla.InsertAsync(datos);
                    await DisplayAlert("Agregado", "Producto Agregado Correctamente", "OK");
                }
                catch (Exception error)
                {
                    await DisplayAlert("error", "" + error, "OK");
                }
            }
        }
    }
}