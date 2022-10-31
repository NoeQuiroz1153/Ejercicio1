using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ejercicio1.vistas;

namespace Ejercicio1.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : ContentPage
    {
        public Master()
        {
            InitializeComponent();
        }

        private async void btnCalcu_Clicked(object sender, EventArgs e)
        {
         App.Masterdet.IsPresented = false;
            await App.Masterdet.Detail.Navigation.PushAsync(new homepage());
        }

        private async void btnCorrep_Clicked(object sender, EventArgs e)
        {
            App.Masterdet.IsPresented = false;
            await App.Masterdet.Detail.Navigation.PushAsync(new exer2());
        }
    }
}