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

namespace ShoppingCartList.Core.Model
{
    public class Item
    {
        public int ItemId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string ImagePath
        {
            get;
            set;
        }

        public double Price
        {
            get;
            set;
        }

        public string GroupName
        {
            get;
            set;
        }

        public int itemAmount
        {
            get;
            set;
        }
    }
}