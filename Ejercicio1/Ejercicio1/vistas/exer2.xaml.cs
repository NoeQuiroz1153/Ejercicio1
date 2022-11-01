using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio1.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class exer2 : ContentPage
    {
        public exer2()
        {
            InitializeComponent();
        }
        Models.Contactos _contactos;
        public exer2(Models.Contactos contactos)
        {
            InitializeComponent();
            Title = "Editar Contacto";
            _contactos = contactos;
            nombre.Text = contactos.Nombre;
            apellido.Text = contactos.Apellido;
            edad.Text = Convert.ToString(contactos.Edad);
            var pick = Convert.ToString(pickerpais.ItemsSource);
            pick = contactos.Pais;
            nota.Text = contactos.Nota;
            nombre.Focus();

        }
         async void btnenviar_Clicked(object sender, EventArgs e)
        {
            var pick = Convert.ToString(pickerpais.ItemsSource);
            if (string.IsNullOrEmpty(nombre.Text) || string.IsNullOrEmpty(apellido.Text) || string.IsNullOrEmpty(edad.Text) || string.IsNullOrEmpty(pick))
            {
                await DisplayAlert("Incompleto", "Necesita llenar todos los campos", "ok");
            }
           else if(_contactos!=null)
            {
                editarcontact();
            }    
           else
            {
                AgregarnewContacto();
            }
       }


      async void AgregarnewContacto()
        {
            await App.Database.Crearcontacto(new Models.Contactos
            {
                Nombre = nombre.Text,
                Apellido = apellido.Text,
                Edad = Convert.ToInt32(edad.Text),
                Pais = Convert.ToString(pickerpais.SelectedIndex),
                Nota = nota.Text,
            });
          await Navigation.PopAsync();
        }

        async void editarcontact()
        {
            _contactos.Nombre = nombre.Text;
            _contactos.Apellido = apellido.Text;
            _contactos.Edad = Convert.ToInt32(edad.Text);
            _contactos.Pais =Convert.ToString(pickerpais.Items);
            _contactos.Nota = nota.Text;
            await App.Database.Updatecontacto(_contactos);
            await Navigation.PopAsync();
            
        }




    }
}