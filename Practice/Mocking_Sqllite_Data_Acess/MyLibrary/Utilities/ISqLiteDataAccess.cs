using System.Collections.Generic;

namespace MyLibrary
{
    public interface ISqLiteDataAccess
    {
        string DBName { get; set; }

        void CreateDB();
        void CreateDBTables();
        List<T> LoadData<T>(string sql);
        void SaveData<T>(T model, string sql);
    }
}