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
using ShoppingCartList.Resources.layout;

namespace ShoppingCartList
{
    [Activity(Label = "ItemMenuActivity")]
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

            itemListView.ItemClick += ItemListView_ItemClick;
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