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
using ShoppingCartList.Core.Repository;

namespace ShoppingCartList.Core.Service
{
    public class ItemDataService
    {
        private static ItemRepository itemRepository = new ItemRepository();

        public List<Item> GetAllItems()
        {
            return itemRepository.GetAllItems();
        }

        public List<ItemGroup> GetGroupedItems()
        {
            return itemRepository.GetGrupedItems();
        }

        public List<Item> GetItemsForGroup(int itemGroupId)
        {
            return itemRepository.GetItemsForGroup(itemGroupId);
        }

        public Item GetItemById(int itemId)
        {
            return itemRepository.GetItemById(itemId);
        }
    }
}