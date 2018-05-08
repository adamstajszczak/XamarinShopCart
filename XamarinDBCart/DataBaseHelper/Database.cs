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
using XamarinDBCart.Model;

namespace XamarinDBCart.DataBaseHelper
{
    class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool createDatabase()
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "Items.db")))
                {
                    conn.CreateTable<Items>();
                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                return false;
            }
        }

        public bool insertIntoTable(Items items)
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "Items.db")))
                {
                    conn.Insert(items);
                    return true;
                }
            }
            catch (Exception)
            {
                Toast.MakeText(Application.Context, "Nie uało się zapisać do bazy!", ToastLength.Short).Show();
                return false;
            }
        }

        public List<Items> selectTable()
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "Items.db")))
                {

                    return conn.Table<Items>().ToList();
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool updateTable(Items items)
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "Items.db")))
                {
                    conn.Query<Items>("UPDATE Student Set Name=?, Description=?, Price=? Where ItemId=?", items.Name, items.Description, items.Price, items.ItemId);
                    return true;
                }
            }
            catch (Exception)
            {
                Toast.MakeText(Application.Context, "Nie można wykonać update'u!", ToastLength.Short).Show();
                return false;
            }
        }

        public bool deleteFromTable(Items items)
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "Items.db")))
                {
                    conn.Delete(items);
                    return true;
                }
            }
            catch (Exception)
            {
                Toast.MakeText(Application.Context, "Nie mozna usunac", ToastLength.Short).Show();
                return false;
            }
        }

        public bool selectQueryTable(int ItemId)
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "Items.db")))
                {
                    conn.Query<Items>("SELECT * From Items Where ItemId=?", ItemId);
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }


        public List<Items> selectOneItem(int ItemId)
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "Items.db")))
                {

                    return conn.Query<Items>("SELECT * From Items Where ItemId=?", ItemId).ToList();
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public void dropTable()
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "Items.db")))
                {
                    conn.DropTable<Items>();
                }
            }
            catch (Exception)
            {
                Toast.MakeText(Application.Context, "Nie mozna usunac", ToastLength.Short).Show();
            }
        }

        public bool checkItemName(string itemName)
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "Items.db")))
                {
                    List<Items> item = conn.Query<Items>("SELECT * From Items Where Name=?", itemName).ToList();
                    if (item.Count == 0)
                    {
                        return false;
                    }
                    
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Items> selectSearch(string search)
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "Items.db")))
                {

                    return conn.Query<Items>("SELECT * From Items Where Name like'"+ search+ "%'").ToList();
                }
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}