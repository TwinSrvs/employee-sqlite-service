using SQLite;

namespace Assessment.DbConnect
{
    public interface ISQLiteDb
    {
        #region METHODS

        SQLiteAsyncConnection GetConnection();

        #endregion
    }
}