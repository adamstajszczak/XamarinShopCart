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
using XamarinDBCart.Model;
using XamarinDBCart.Utility;

namespace XamarinDBCart.Adapters
{
    class ItemListViewAdapter : BaseAdapter<Items>
    {
        List<Items> items;
        Activity context;

        public ItemListViewAdapter(Activity context, List<Items> items)
        {
            this.items = items;
            this.context = context;
        }

        public override Items this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            var imageBitmap = ImageHelper.GetImageBitmapFromUrl(
                "https://raw.githubusercontent.com/adamstajszczak/XamarinShopCart/master/XamarinDBCart/Images/" + item.ImagePath + ".png");

            if (convertView == null)
            {
                convertView =
                    context.LayoutInflater
                    .Inflate(Resource.Layout.ItemRowView, null);
            }
            convertView.FindViewById<TextView>(Resource.Id.itemNameTextView).Text = item.Name;
            convertView.FindViewById<TextView>(Resource.Id.itemPriceTextView).Text = item.Price + " zł";
            convertView.FindViewById<ImageView>(Resource.Id.itemImageView)
                .SetImageBitmap(imageBitmap);
            return convertView;
        }
    }
}