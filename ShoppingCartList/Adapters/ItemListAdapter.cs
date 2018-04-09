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
using ShoppingCartList.Utility;

namespace ShoppingCartList.Adapters
{
    public class ItemListAdapter : BaseAdapter<Item>
    {
        List<Item> items;
        Activity context;

        public ItemListAdapter(Activity context, List<Item> items)
        {
            this.items = items;
            this.context = context;
        }

        public override Item this[int position]
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
                "https://raw.githubusercontent.com/adamstajszczak/XamarinShopCart/master/ShoppingCartList/Images/" + item.ImagePath + ".jpg");

            if(convertView == null)
            {
                convertView =
                    context.LayoutInflater
                    .Inflate(Android.Resource.Layout.ActivityListItem, null);
            }
            convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text =
                item.Name;
            convertView.FindViewById<ImageView>(Android.Resource.Id.Icon)
                .SetImageBitmap(imageBitmap);
            return convertView;

            return convertView;
        }
    }
}