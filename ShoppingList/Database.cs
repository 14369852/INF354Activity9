using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Android.Util;
using SQLite;
using ShoppingList.Resources.Model;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingList.Resources.Helper
{
    public class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool CreateDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Persons.db")))
                {
                    //connection.CreateTable<Item>;
                    return true;
                }
            }
            catch(SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        //Add or Insert Operation  

        public bool insertIntoTable(Item item)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ShoppingList.db")))
                {
                    connection.Insert(item);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        public List<Item> selectTable()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ShoppingList.db")))
                {
                    return connection.Table<Item>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        //Delete Data Operation  

        public bool removeTable(Item item)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ShoppingList.db")))
                {
                    connection.Delete(item);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
    }
}