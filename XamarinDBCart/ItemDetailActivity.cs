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
using XamarinDBCart.Utility;

namespace XamarinDBCart
{
    [Activity(Label = "ItemDetailActivity")]
    public class ItemDetailActivity : Activity
    {
        private ImageView itemImageView;
        private TextView itemNameTextView;
        private TextView itemDescriptionTextView;
        private TextView itemPriceTextView;
        private Button orderButton;

        private List<Items> testList;
        private Items selectedItem;
        Database db;
        DatabaseCart cartDb;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ItemDetailView);

            db = new Database();
            db.CreateDatabase();

            cartDb = new DatabaseCart();
            cartDb.CreateDatabase();

            var selectedItemId = Intent.Extras.GetInt("selectedItemId");

            testList = db.SelectOneItem(selectedItemId);
            selectedItem = testList.FirstOrDefault();

            FindViews();
            BindData();
            HandleEvents();

            // Create your application here
        }

        private void HandleEvents()
        {
            orderButton.Click += OrderButton_Click;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ItemMenuActivity));
            StartActivity(intent);
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            bool result = cartDb.CheckItemName(selectedItem.Name);
            if (result)
            {
                Toast.MakeText(Application.Context, "Błąd! Przedmiot znajduje się już w koszyku", ToastLength.Short).Show();
            }
            else
            {
                try
                {
                    Items item = new Items()
                    {
                        Name = selectedItem.Name,
                        ImagePath = selectedItem.ImagePath,
                        Price = selectedItem.Price
                    };
                    cartDb.InsertIntoTable(item);
                    Toast.MakeText(Application.Context, "Pomyślnie dodano " + selectedItem.Name + " do koszyka!", ToastLength.Short).Show();
                }
                catch (Exception)
                {
                    Toast.MakeText(Application.Context, "Nie można dodać przedmiotu do koszyka!", ToastLength.Short).Show();
                }
            }

        }

        private void BindData()
        {
            itemNameTextView.Text = selectedItem.Name;
            itemDescriptionTextView.Text = selectedItem.Description;
            itemPriceTextView.Text = "Cena: " + selectedItem.Price + "zł";

            var imageBitmap = ImageHelper.GetImageBitmapFromUrl(
                "https://raw.githubusercontent.com/adamstajszczak/XamarinShopCart/master/XamarinDBCart/Images/" + selectedItem.ImagePath + "_big.png");

            itemImageView.SetImageBitmap(imageBitmap);
        }

        private void FindViews()
        {
            itemImageView = FindViewById<ImageView>(Resource.Id.itemImageView);
            itemNameTextView = FindViewById<TextView>(Resource.Id.itemNameTextView);
            itemDescriptionTextView = FindViewById<TextView>(Resource.Id.itemDescriptionTextView);
            itemPriceTextView = FindViewById<TextView>(Resource.Id.itemPriceTextView);
            orderButton = FindViewById<Button>(Resource.Id.orderButton);
        }
    }
}