using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }


        public static IEnumerable<Estudiante> SELECT_WHERE(SQLiteConnection db, string usuario, string contra)
        {
            return db.Query<Estudiante>("SELECT*FROM Estudiante where Usuario =? and Contrasenia=?", usuario, contra);
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {

            
                var documentPath = Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments),"uisrael.db3");

                var db = new SQLiteConnection(documentPath);

                db.CreateTable<Estudiante>();

                IEnumerable<Estudiante> resultado = SELECT_WHERE(db, Usuario.Text, Contra.Text);

                if (resultado.Count()>0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    DisplayAlert("Alerta", "Verifgique Usuario/Contraseña", "Ok");
                }
            }
            catch(Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Ok");
            }

        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro());
        }
    }
}