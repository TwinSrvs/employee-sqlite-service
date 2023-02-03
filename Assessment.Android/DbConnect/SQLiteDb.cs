using System;
using System.IO;
using Assessment.DbConnect;
using Assessment.Droid.DbConnect;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]
namespace Assessment.Droid.DbConnect
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