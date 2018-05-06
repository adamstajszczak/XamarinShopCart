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
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace ShoppingCartList.Core.Repository
{
    public class ItemRepository
    {
        private static List<ItemGroup> itemGroups = new List<ItemGroup>();

        string url  = "https://api.myjson.com/bins/1fhe27";

        public ItemRepository()
        {
            Task.Run(() => this.LoadDataAsync(url)).Wait();
        }

        private async Task LoadDataAsync(string uri)
        {
            if (itemGroups != null)
            {
                string responseJSONString = null;

                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        Task<HttpResponseMessage> getResponse = httpClient.GetAsync(uri);

                        HttpResponseMessage respose = await getResponse;

                        responseJSONString = await respose.Content.ReadAsStringAsync();

                        itemGroups = JsonConvert.DeserializeObject<List<ItemGroup>>(responseJSONString);
                    } catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
        }

        public List<Item> GetAllItems()
        {
            IEnumerable<Item> items =
                from itemGroup in itemGroups
                from item in itemGroup.Items

                select item;
            return items.ToList<Item>();
        }

        public Item GetItemById(int itemId)
        {
            IEnumerable<Item> items =
                from itemGroup in itemGroups
                from item in itemGroup.Items
                where item.ItemId == itemId
                select item;

            return items.FirstOrDefault();
        }

        public List<ItemGroup> GetGrupedItems()
        {
            return itemGroups;
        }

        public List<Item> GetItemsForGroup(int itemGroupId)
        {
            var group = itemGroups.Where(h => h.ItemGroupId == itemGroupId).FirstOrDefault();

            if (group != null)
            {
                return group.Items;
            }
            return null;
        }

        public List<Item> GetCartItems()
        {
            IEnumerable<Item> items =
                from itemGroup in itemGroups
                from item in itemGroup.Items
                where item.itemAmount > 0

                select item;
            return items.ToList<Item>();
        }
    }
}