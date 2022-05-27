using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App7.Droid;
using SQLite;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(SqliteClient))]


namespace App7.Droid
{
    public class SqliteClient : Database
    {

        

        public SQLiteAsyncConnection GetConnection()
        {
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            // se crea la base de datos
            var path = Path.Combine(documentPath, "uisrael.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}