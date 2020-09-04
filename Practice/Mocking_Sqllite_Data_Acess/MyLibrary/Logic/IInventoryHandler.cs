using System.Collections.Generic;

namespace MyLibrary.Logic
{
    public interface IInventoryHandler
    {
        void CreateDBAndTables();
        (T, bool) CreateModel<T>() where T : new();
        void DeleteDB();
        void DisplayTable<M>(List<M> tableContainsForeignKey);
        string GetDBTableName<T>(T model);
        List<T> LoadModel<T>(T model);
        void SaveModel<T>(T model);
    }
}