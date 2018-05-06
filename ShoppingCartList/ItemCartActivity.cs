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
using ShoppingCartList.Core.Service;
using ShoppingCartList.Core.Model;
using ShoppingCartList.Adapters;

namespace ShoppingCartList
{
    [Activity(Label = "ItemCartActivity")]
    public class ItemCartActivity : Activity
    {
        private ListView itemListView;
        private List<Item> allItems;
        private ItemDataService itemDataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ItemCartView);

            itemListView = FindViewById<ListView>(Resource.Id.itemListView);

            itemDataService = new ItemDataService();

            allItems = itemDataService.GetCartItems();

            itemListView.Adapter = new ItemListAdapter(this, allItems);

            itemListView.FastScrollEnabled = true;

            itemListView.ItemClick += ItemListView_ItemClick;
        }

        private void ItemListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //TODO
        }
    }
}