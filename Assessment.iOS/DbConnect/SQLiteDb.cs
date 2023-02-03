using System;
using System.IO;
using Assessment.DbConnect;
using Assessment.iOS.DbConnect;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]
namespace Assessment.iOS.DbConnect
{
    public class SQLiteDb : ISQLiteDb
    {
        #region METHODS

        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string path = Path.Combine(documentsPath, "MyEmployeeDb.db3");

            return new SQLiteAsyncConnection(path);
        }

        #endregion
    }
}