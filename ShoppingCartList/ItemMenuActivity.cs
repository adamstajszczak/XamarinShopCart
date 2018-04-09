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
using ShoppingCartList.Adapters;
using ShoppingCartList.Core.Model;
using ShoppingCartList.Core.Service;

namespace ShoppingCartList
{
    [Activity(Label = "ItemMenuActivity", MainLauncher = true)]
    public class ItemMenuActivity : Activity
    {
        private ListView itemListView;
        private List<Item> allItems;
        private ItemDataService itemDataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ItemMenuView);

            itemListView = FindViewById<ListView>(Resource.Id.itemListView);

            itemDataService = new ItemDataService();

            allItems = itemDataService.GetAllItems();

            itemListView.Adapter = new ItemListAdapter(this, allItems);

            itemListView.FastScrollEnabled = true;
        }
    }
}