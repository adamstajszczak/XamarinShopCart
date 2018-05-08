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
using XamarinDBCart.DataBaseHelper;
using XamarinDBCart.Model;

namespace XamarinDBCart
{
    [Activity(Label = "AddItemActivity")]
    public class AddItemActivity : Activity
    {
        EditText itemName;
        EditText itemDesc;
        EditText itemPrice;
        Button addButton;
        Button cancelButton;
        Database db;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AddItemView);

            db = new Database();
            db.CreateDatabase();
            //db.dropTable();

            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            Log.Info("FolderBazy: ", folder);

            // Create your application here

            FindViews();
            HandleEvents();
        }

        private void HandleEvents()
        {
            addButton.Click += AddButton_Click;
            cancelButton.Click += CancelButton_Click;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MenuActivity));
            StartActivity(intent);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            bool check = db.CheckItemName(itemName.Text);            
            bool result = Double.TryParse(itemPrice.Text, out double number);
            if (result && !check)
            {
                try
                {
                    Items item = new Items()
                    {
                        Name = itemName.Text,
                        Description = itemDesc.Text,
                        ImagePath = itemName.Text.ToLower(),
                        Price = number
                    };
                    db.InsertIntoTable(item);
                    Toast.MakeText(Application.Context, "Pomyślnie dodano " + item.Name, ToastLength.Short).Show();
                }
                catch (Exception)
                {
                    Toast.MakeText(Application.Context, "Nie udało się dodać przedmiotu!", ToastLength.Short).Show();
                }
            } else if (check)
            {
                Toast.MakeText(Application.Context, "Błąd! Przedmiot istnieje już w bazie!", ToastLength.Short).Show();
            } else
            {
                Toast.MakeText(Application.Context, "Błędny format ceny!", ToastLength.Short).Show();
            }
        }

        private void FindViews()
        {
            itemName = FindViewById<EditText>(Resource.Id.itemName);
            itemDesc = FindViewById<EditText>(Resource.Id.itemDesc);
            itemPrice = FindViewById<EditText>(Resource.Id.itemPrice);
            addButton = FindViewById<Button>(Resource.Id.addButton);
            cancelButton = FindViewById<Button>(Resource.Id.cancelButton);
        }
    }
}