using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ejercicio1.vistas;
using SQLite;
using System.IO;
using Ejercicio1.Models;


namespace Ejercicio1
{
    public partial class App : Application
    {
        private static sqlconex db;

        public static sqlconex Database
        {
            get { 
                 if (db == null)
                {
                    db = new sqlconex(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MiBase.db3"));
                }
                 return db;
                }
            
        }


        public static MasterDetailPage Masterdet { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new datexer2());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
