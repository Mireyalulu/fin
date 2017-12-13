using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace fin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Administrador : ContentPage
    {
        public Administrador()
        {
            InitializeComponent();
            id_user.Text = MainPage.id;
            nombre.Text = MainPage.nombre;
        }

        private async void Asignar_tareas_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushModalAsync(new Asignar_tareas());
        }

        private async void Registrarse_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Regis_usu());
        }
    }
}