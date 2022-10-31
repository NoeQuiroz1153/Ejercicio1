
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio1.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mainpage : MasterDetailPage
    {
        public Mainpage()
        {
            InitializeComponent();
            this.Master = new Master();
            this.Detail = new NavigationPage(new datexer2());
            App.Masterdet = this;
        }
    }
}