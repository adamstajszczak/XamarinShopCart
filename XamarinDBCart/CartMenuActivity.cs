using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using XamarinDBCart.Adapters;
using XamarinDBCart.DataBaseHelper;
using XamarinDBCart.Model;

namespace XamarinDBCart
{
    [Activity(Label = "CartMenuActivity")]
    public class CartMenuActivity : Activity
    {
        private ListView cartListView;
        private List<Items> allItems;
        DatabaseCart db;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CartMenuView);

            allItems = new List<Items>();

            db = new DatabaseCart();
            db.CreateDatabase();

            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            Log.Info("FolderBazy: ", folder);

            cartListView = FindViewById<ListView>(Resource.Id.cartListView);
            cartListView.FastScrollEnabled = true;

            WczytajDane();
        }

        private void WczytajDane()
        {
            allItems = db.SelectTable(); //potencjalny blad
            var adapter = new ItemListViewAdapter(this, allItems);
            cartListView.Adapter = adapter;
        }
    }
}