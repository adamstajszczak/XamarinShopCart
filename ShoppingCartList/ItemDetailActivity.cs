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
using ShoppingCartList.Core.Model;
using ShoppingCartList.Core.Service;
using ShoppingCartList.Utility;

namespace ShoppingCartList.Resources.layout
{
    [Activity(Label = "Szczegóły przedmiotu")]
    public class ItemDetailActivity : Activity
    {
        private ImageView itemImageView;
        private TextView itemNameTextView;
        private TextView itemDescriptionTextView;
        private TextView itemPriceTextView;
        private EditText amountEditText;
        private Button cancelButton;
        private Button orderButton;

        private Item selectedItem;
        private ItemDataService dataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ItemDetailView);

            dataService = new ItemDataService();
            selectedItem = dataService.GetItemById(1);

            FindViews();
            BindData();
            HandleEvents();
        }

        private void FindViews()
        {
            itemImageView = FindViewById<ImageView>(Resource.Id.itemImageView);
            itemNameTextView = FindViewById<TextView>(Resource.Id.itemNameTextView);
            itemDescriptionTextView = FindViewById<TextView>(Resource.Id.itemDescriptionTextView);
            itemPriceTextView = FindViewById<TextView>(Resource.Id.itemPriceTextView);
            amountEditText = FindViewById<EditText>(Resource.Id.amountEditText);
            cancelButton = FindViewById<Button>(Resource.Id.cancelButton);
            orderButton = FindViewById<Button>(Resource.Id.orderButton);
        }

        private void BindData()
        {
            itemNameTextView.Text = selectedItem.Name;
            itemDescriptionTextView.Text = selectedItem.Description;
            itemPriceTextView.Text = "Cena: " + selectedItem.Price + "zł";

            var imageBitmap = ImageHelper.GetImageBitmapFromUrl("https://raw.githubusercontent.com/adamstajszczak/XamarinShopCart/master/ShoppingCartList/Images/" + selectedItem.ImagePath + ".jpg");

            itemImageView.SetImageBitmap(imageBitmap);
        }

        private void HandleEvents()
        {
            orderButton.Click += OrderButton_Click;
            cancelButton.Click += CancelButton_Click;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            var dialog = new AlertDialog.Builder(this);
            dialog.SetTitle("Potwierdzenie");
            dialog.SetMessage("Pomyślnie dodano "+ amountEditText.Text+ "x " + selectedItem.Name + " do koszyka!");
            dialog.Show();

            int wartosc = Int32.Parse(amountEditText.Text);
            selectedItem.itemAmount = wartosc;
            
        }
    }
}