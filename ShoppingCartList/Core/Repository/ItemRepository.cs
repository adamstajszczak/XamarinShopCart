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

namespace ShoppingCartList.Core.Repository
{
    public class ItemRepository
    {
        private static List<ItemGroup> itemGroups = new List<ItemGroup>()
        {
            new ItemGroup()
            {
                ItemGroupId = 1,
                Title = "Spożywcze",
                ImagePath = "",
                Items = new List<Item>()
                {
                    new Item()
                    {
                        ItemId = 1,
                        Name = "Chleb",
                        Description = "OPIS CHLEBA",
                        ImagePath = "chlebImage",
                        Price = 2.49
                    },
                    new Item()
                    {
                        ItemId = 2,
                        Name = "Masło",
                        Description = "OPIS MASŁA",
                        ImagePath = "masloImage",
                        Price = 4.99
                    },
                    new Item()
                    {
                        ItemId = 3,
                        Name = "Kawa",
                        Description = "OPIS KAWA",
                        ImagePath = "kawaImage",
                        Price = 11.99
                    }
                }
            },
            new ItemGroup()
            {
                ItemGroupId = 2,
                Title = "Alkohole",
                ImagePath = "",
                Items = new List<Item>()
                {
                    new Item()
                    {
                        ItemId = 4,
                        Name = "Żubrówka 0.7L",
                        Description = "Wódka",
                        ImagePath = "zobrowkaImage",
                        Price = 30
                    },
                    new Item()
                    {
                        ItemId = 5,
                        Name = "Tyskie 0.5L",
                        Description = "Piwo",
                        ImagePath = "tyskieImage",
                        Price = 2.70
                    },
                    new Item()
                    {
                        ItemId = 6,
                        Name = "Proseco",
                        Description = "Wino",
                        ImagePath = "wineImage",
                        Price = 40
                    }
                }
            }
        };

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
    }
}