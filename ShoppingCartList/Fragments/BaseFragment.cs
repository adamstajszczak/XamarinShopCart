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
using ShoppingCartList.Core.Model;
using ShoppingCartList.Core.Service;
using ShoppingCartList.Resources.layout;

namespace ShoppingCartList.Fragments
{
    public class BaseFragment : Fragment
    {
        protected ListView listView;
        protected ItemDataService itemDataService;
        protected List<Item> items;

        public BaseFragment()
        {
            itemDataService = new ItemDataService();
        }

        protected void HandleEvents()
        {
            listView.ItemClick += ListView_ItemClick;
        }
        protected void FindViews()
        {
            listView = this.View.FindViewById<ListView>(Resource.Id.itemListView);
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var item = items[e.Position];

            var intent = new Intent();
            intent.SetClass(this.Activity, typeof(ItemDetailActivity));
            intent.PutExtra("selectedItemId", item.ItemId);

            StartActivityForResult(intent, 100);
        }
    }
}