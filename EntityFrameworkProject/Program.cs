using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WTE_Restaurants item = new WTE_Restaurants()
            {
                ID = 1,
                Name = "Burger King",
                Tags = "Fastfood, Cheap, Unhealthy",
                Pricing = "$"
            };

            AddItemToDataBase(item);
            var newItem = new WTE_Restaurants
            {
                ID = 1,
                Name = "KFC",
                Tags = "Fastfood, Cheap, Unhealthy",
                Pricing = "$"
            };
            UpdateItemInDataBase(item, newItem);
            DeleteItemFromDataBase(item.ID);
        }

        private static void AddItemToDataBase(WTE_Restaurants whatToEatItem)
        {
            using (var context = new WhatToEatEntities())
            {
                context.WTE_Restaurants.Add(whatToEatItem);
                context.SaveChanges();
            }
        }

        private static void DeleteItemFromDataBase(int ID)
        {
            using (var context = new WhatToEatEntities())
            {
                context.WTE_Restaurants.Remove(context.WTE_Restaurants.First(x => x.ID == ID));
                context.SaveChanges();
            }
        }

        private static void UpdateItemInDataBase(WTE_Restaurants itemToUpdate, WTE_Restaurants newItemProperties)
        {
            using (var context = new WhatToEatEntities())
            {
                var item = context.WTE_Restaurants.First(x => x.ID == itemToUpdate.ID);
                item.Name = newItemProperties.Name;
                item.Pricing = newItemProperties.Pricing;
                item.Tags = newItemProperties.Tags;
                context.SaveChanges();
            }
        }
    }
}
