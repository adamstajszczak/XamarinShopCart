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

namespace XamarinDBCart
{
    [Activity(Label = "AboutActivity")]
    public class AboutActivity : Activity
    {
        private TextView phoneNumberTextView;
        private Button menuButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AboutView);

            FindViews();
            HandleEvents();
        }

        private void HandleEvents()
        {
            phoneNumberTextView.Click += PhoneNumberTextView_Click;
            menuButton.Click += MenuButton_Click;

        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MenuActivity));
            StartActivity(intent);
        }

        private void PhoneNumberTextView_Click(object sender, EventArgs e)
        {
            var intent = new Intent(Intent.ActionCall);
            intent.SetData(Android.Net.Uri.Parse("tel:" + phoneNumberTextView.Text));
            StartActivity(intent);
        }

        private void FindViews()
        {
            phoneNumberTextView = FindViewById<TextView>(Resource.Id.phoneNumberTextView);
            menuButton = FindViewById<Button>(Resource.Id.menuButton);
        }
    }
}