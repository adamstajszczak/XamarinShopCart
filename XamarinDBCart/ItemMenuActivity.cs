﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using XamarinDBCart.Adapters;
using XamarinDBCart.DataBaseHelper;
using XamarinDBCart.Model;

namespace XamarinDBCart
{
    [Activity(Label = "ItemMenuActivity")]
    public class ItemMenuActivity : Activity
    {
        private ListView itemListView;
        private EditText searchProduct;
        private List<Items> allItems;
        Database db;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ItemMenuView);

            allItems = new List<Items>();

            db = new Database();
            db.CreateDatabase();

            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            Log.Info("FolderBazy: ", folder);

            itemListView = FindViewById<ListView>(Resource.Id.itemListView);
            itemListView.FastScrollEnabled = true;
            itemListView.ItemClick += ItemListView_ItemClick;

            WczytajDane();

            searchProduct = FindViewById<EditText>(Resource.Id.searchProduct);
            searchProduct.AfterTextChanged += SearchProduct_AfterTextChanged;
        }

        private void SearchProduct_AfterTextChanged(object sender, AfterTextChangedEventArgs e)
        {
            if (searchProduct.Text == "") WczytajDane();
            else
            {
                allItems = db.SelectSearch(searchProduct.Text);
                var adapter = new ItemListViewAdapter(this, allItems);
                itemListView.Adapter = adapter;
            }
        }

        private void WczytajDane()
        {
            allItems = db.SelectTable(); //potencjalny blad
            var adapter = new ItemListViewAdapter(this, allItems);
            itemListView.Adapter = adapter;
        }

        private void ItemListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var item = allItems[e.Position];

            var intent = new Intent();
            intent.SetClass(this, typeof(ItemDetailActivity));
            intent.PutExtra("selectedItemId", item.ItemId);

            StartActivityForResult(intent, 100);
        }
    }
}