using Acr.UserDialogs;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace fin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Asignar_tareas : ContentPage
    {
        ObservableCollection<asignaciontareas> Items { get; set; }

        static MobileServiceClient cliente;
        static IMobileServiceTable<asignaciontareas> Tabla1;

        static MobileServiceUser usuario;
        string tarea, fechaTermino, fechaInicio, prioridad, dependencia;

        public Asignar_tareas()
        {
          
            InitializeComponent();
            cliente = new MobileServiceClient(AzureConnection.AzureURL);
            Tabla1 = cliente.GetTable<asignaciontareas>();
            datePicker.Date = DateTime.Now;
            datePicker.MinimumDate = DateTime.Now;
            datePicker.MaximumDate = new DateTime(2020, 1, 1);
            leerTareasAsignadas();



        }
        private async void leerTareasAsignadas()
        {
            IEnumerable<asignaciontareas> elementos2 = await Tabla1.ToEnumerableAsync();
            Items = new ObservableCollection<asignaciontareas>(elementos2);
            int cont = Items.Count;
            var ListaTareasAsignadas = new List<string>();
            var codigo = new List<string>();

            for (int i = 0; i < cont; i++)
            {
               ListaTareasAsignadas.Add( Items[i].Id+ " Tarea :"+Items[i].Tarea + " asignada a :"+Items[i].Id_usuario);
            }
            pkrDependencia.ItemsSource = ListaTareasAsignadas ;
          

        }


        private void pkrTarea_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            if (selectedIndex != -1)
            {
                tarea = (string)picker.ItemsSource[selectedIndex];
            }
        }

        private void pkrPrioridad_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            if (selectedIndex != -1)
            {
                prioridad =  (string)picker.ItemsSource[selectedIndex];

            }

        }

        

        private  void pkrDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            if (selectedIndex != -1)
            {
                string d= (string)picker.ItemsSource[selectedIndex];
                dependencia = d.Substring(1, 36);
            }

        }

        private async void Registrar_Clicked(object sender, EventArgs e)
        {
            if (Usuario.Text == null || tarea == null || prioridad == null)
            {
                await DisplayAlert("Error", "Es obligatorio llenar todos los campos", "OK");
            }
            else
            {
                DateTime fecha = DateTime.Now;
                var data = new asignaciontareas
                {
                    Id_usuario = Usuario.Text,
                    Tarea = tarea,
                    Prioridad = prioridad,
                    FechaAsig = Convert.ToDateTime(fecha),
                    FechaTerm = Convert.ToDateTime(fechaTermino),
                    Dependencia= dependencia,
                    Estatus = "Creada"
                };
                try
                {
                    await Tabla1.InsertAsync(data);
                    leerTareasAsignadas();
                    await DisplayAlert("Agregado", "Producto Agregado Correctamente", "OK");
                }
                catch (Exception error)
                {
                    await DisplayAlert("error", "" + error, "OK");
                }
            }
        }

        private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            fechaTermino = e.NewDate.ToString();
        }
    }
}