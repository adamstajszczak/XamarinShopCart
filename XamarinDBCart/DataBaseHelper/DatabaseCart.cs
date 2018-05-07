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
    class DatabaseCart
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool createDatabase()
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "Cart.db")))
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
                using (var conn = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "Cart.db")))
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
                using (var conn = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "Cart.db")))
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
                using (var conn = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "Cart.db")))
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

        public bool deleteTable(Items items)
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "Cart.db")))
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
                using (var conn = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "Cart.db")))
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

        public bool checkItemName(string itemName)
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "Cart.db")))
                {
                    conn.Query<Items>("SELECT * From Items Where Name=?", itemName);
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}