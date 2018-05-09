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
using XamarinDBCart.DataBaseHelper;
using XamarinDBCart.Model;

namespace XamarinDBCart
{
    [Activity(Label = "MenuActivity", MainLauncher = true)]
    public class MenuActivity : Activity
    {
        private Button orderButton;
        private Button cartButton;
        private Button aboutButton;
        private Button addItem;
        Database db;
        DatabaseCart dbCart;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainMenu);

            //db = new database();
            //db.createdatabase();
            //loaditems li = new loaditems();
            //li.wczytajdane();
            FindViews();
            HandleEvents();

            var message = Intent.Extras.GetString("message");

            if (message.Length > 0)
            {
                Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
            }
        }

        private void FindViews()
        {
            orderButton = FindViewById<Button>(Resource.Id.orderButton);
            cartButton = FindViewById<Button>(Resource.Id.cartButton);
            aboutButton = FindViewById<Button>(Resource.Id.aboutButton);
            addItem = FindViewById<Button>(Resource.Id.addItem);
        }

        private void HandleEvents()
        {
            orderButton.Click += OrderButton_Click;
            aboutButton.Click += AboutButton_Click;
            addItem.Click += AddItem_Click;
            cartButton.Click += CartButton_Click;
        }

        private void CartButton_Click(object sender, EventArgs e)
        {
            dbCart = new DatabaseCart();
            dbCart.CreateDatabase();
            if (db.SelectTable().Count == 0)
            {
                Toast.MakeText(Application.Context, "Lista przedmiotów jest pusta!", ToastLength.Short).Show();
            }
            else
            {
                var intent = new Intent(this, typeof(CartMenuActivity));
                StartActivity(intent);
            }
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AddItemActivity));
            StartActivity(intent);
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AboutActivity));
            StartActivity(intent);
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            db = new Database();
            db.CreateDatabase();
            if (db.SelectTable().Count == 0)
            {
                Toast.MakeText(Application.Context, "Lista przedmiotów jest pusta!", ToastLength.Short).Show();
            }
            else
            {
                var intent = new Intent(this, typeof(ItemMenuActivity));
                StartActivity(intent);
            }
        }
    }
}