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
        public bool CreateDatabase()
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "Items.db")))
                {
                    conn.CreateTable<Items>();
                    return true;
                }
            }
            catch (SQLite.SQLiteException)
            {
                return false;
            }
        }

        public bool InsertIntoTable(Items items)
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

        public List<Items> SelectTable()
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

        public bool UpdateTable(Items items)
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

        public bool DeleteFromTable(Items items)
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

        public bool SelectQueryTable(int ItemId)
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


        public List<Items> SelectOneItem(int ItemId)
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

        public void DropTable()
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

        public bool CheckItemName(string itemName)
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

        public List<Items> SelectSearch(string search)
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