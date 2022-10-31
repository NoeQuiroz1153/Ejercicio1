using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio1.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio1.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class datexer2 : ContentPage
    {
        public datexer2()
        {
            InitializeComponent();
            
        }


        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                Viewdata.ItemsSource = await App.Database.Leercontacto();
            }
            catch { }



        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new exer2());
        }

        async void SwipeItem_Invoked(object sender, EventArgs e)
        {
         var item = sender as SwipeItem;
         var contac = item.CommandParameter as Contactos;
         await Navigation.PushAsync(new exer2(contac));
        }

        async void SwipeItem_Invoked_1(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var contac = item.CommandParameter as Contactos;
            var resultado = await DisplayAlert("Eliminar", $"Elimanando a {contac.Nombre} de la base de datos","SI","NO");
            if (resultado)
            {
                await App.Database.Borrarcontacto(contac);
                Viewdata.ItemsSource = await App.Database.Leercontacto();
            }
        }

        async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Viewdata.ItemsSource = await App.Database.Buscar(e.NewTextValue);
        }
    }
}