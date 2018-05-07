﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinDBCart
{
    [Activity(Label = "MenuActivity", MainLauncher = true)]
    public class MenuActivity : Activity
    {
        private Button orderButton;
        private Button cartButton;
        private Button aboutButton;
        private Button addItem;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainMenu);

            FindViews();
            HandleEvents();
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
            var intent = new Intent(this, typeof(ItemMenuActivity));
            StartActivity(intent);
        }
    }
}