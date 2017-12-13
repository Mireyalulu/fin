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
    public partial class Usuario : ContentPage
    {
        public Usuario()
        {
            InitializeComponent();
            id_user.Text = MainPage.id;
            nombre.Text = MainPage.nombre;
            apellido.Text = MainPage.apellido;
            correo.Text = MainPage.correo;
            tipo_usu.Text = MainPage.tipousu;

        }
    }
}