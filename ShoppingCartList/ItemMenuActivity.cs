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
using ShoppingCartList.Fragments;
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

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            AddTab("Spożywcze", Resource.Drawable.dairyProducts, new DairyProductsFragment());
            AddTab("Alkohole", Resource.Drawable.alcoholProducts, new AlcoholProductsFragment());

        }

        private void AddTab(string tabText, int iconResourceId, Fragment view)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);
            tab.SetIcon(iconResourceId);

            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
                if (fragment != null)
                    e.FragmentTransaction.Remove(fragment);
                e.FragmentTransaction.Add(Resource.Id.fragmentContainer, view);
            };

            tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                e.FragmentTransaction.Remove(view);
            };
            this.ActionBar.AddTab(tab);
        }

        private void ItemListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var item = allItems[e.Position];

            var intent = new Intent();
            intent.SetClass(this, typeof(ItemDetailActivity));
            intent.PutExtra("selectedItemId", item.ItemId);

            StartActivityForResult(intent, 100);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok && requestCode == 100)
            {
                var selectedItem = itemDataService.GetItemById(data.GetIntExtra("selectedItemId", 0));

                var dialog = new AlertDialog.Builder(this);
                dialog.SetTitle("Potwierdzenie");
                dialog.SetMessage(string.Format("Dodałeś {0}x {1}", data.GetIntExtra("amount", 0), selectedItem.Name));
                dialog.Show();
            }
        }
    }
}