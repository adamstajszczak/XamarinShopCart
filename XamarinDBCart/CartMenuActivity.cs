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
        private Button clearCart;
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


            FindViews();
            WczytajDane();
            cartListView.FastScrollEnabled = true;
            clearCart.Click += ClearCart_Click;

            cartListView.ItemClick += CartListView_ItemClick;
        }

        private void CartListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var item = allItems[e.Position];

            item.ImagePath = "done";            
        }

        private void ClearCart_Click(object sender, EventArgs e)
        {
            try
            {
                db.DropTable();
                var intent = new Intent(this, typeof(MenuActivity));
                intent.PutExtra("message", "Wyczyszczono pomyślnie koszyk!");
                StartActivity(intent);
            } catch (Exception)
            {
                Toast.MakeText(Application.Context, "Błąd! Nie udało się wyczyścić koszyka", ToastLength.Short).Show();
            }
        }

        private void FindViews()
        {
            cartListView = FindViewById<ListView>(Resource.Id.cartListView);
            clearCart = FindViewById<Button>(Resource.Id.clearCart);
        }

        private void WczytajDane()
        {
            allItems = db.SelectTable(); //potencjalny blad
            var adapter = new ItemListViewAdapter(this, allItems);
            cartListView.Adapter = adapter;
        }
    }
}