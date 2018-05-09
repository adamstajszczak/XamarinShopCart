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
using XamarinDBCart.DataBaseHelper;

namespace XamarinDBCart.Model
{
    public class LoadItems
    {
        Database database = new Database();
        
        public void wczytajDane()
        {
            database.CreateDatabase();
            Items chleb = new Items()
            {
                Name = "Chleb",
                Description = "Danie na śniadanie",
                ImagePath = "chleb",
                Price = 2.99
            };
            database.InsertIntoTable(chleb);


            Items bulka = new Items()
            {
                Name = "Bułka",
                Description = "Danie na śniadanie",
                ImagePath = "bułka",
                Price = 0.49
            };
            database.InsertIntoTable(bulka);

            Items kawa = new Items()
            {
                Name = "Kawa",
                Description = "Napój wysoko-wyskokowy",
                ImagePath = "kawa",
                Price = 12.99
            };
            database.InsertIntoTable(kawa);

            Items kebab = new Items()
            {
                Name = "Kebab",
                Description = "Prawilne danie (najlepsze po alkocholu)!",
                ImagePath = "kebab",
                Price = 15
            };
            database.InsertIntoTable(kebab);

            Items kurczak = new Items()
            {
                Name = "Kurczak",
                Description = "Mięsko na obiadek",
                ImagePath = "kurczak",
                Price = 7
            };
            database.InsertIntoTable(kurczak);

            Items mieso = new Items()
            {
                Name = "Mięso",
                Description = "Mięsko na obiadek",
                ImagePath = "mięso",
                Price = 7
            };
            database.InsertIntoTable(mieso);

            Items mleko = new Items()
            {
                Name = "Mleko",
                Description = "Do picia, do sosów, do zup, do wódki",
                ImagePath = "mleko",
                Price = 2.69
            };
            database.InsertIntoTable(mleko);

            Items papier = new Items()
            {
                Name = "Papier",
                Description = "Przeważnie toaletowy",
                ImagePath = "papier",
                Price = 10
            };
            database.InsertIntoTable(papier);

            Items ryba = new Items()
            {
                Name = "Ryba",
                Description = "Polecana w piątek na obiad",
                ImagePath = "ryba",
                Price = 7
            };
            database.InsertIntoTable(ryba);

            Items ser = new Items()
            {
                Name = "Ser",
                Description = "Obkład na kanapki",
                ImagePath = "ser",
                Price = 4.39
            };
            database.InsertIntoTable(ser);

            Items szampan = new Items()
            {
                Name = "Szampan",
                Description = "Na ucczenie udanego tygodnia",
                ImagePath = "szampan",
                Price = 25
            };
            database.InsertIntoTable(szampan);

            Items wino = new Items()
            {
                Name = "Wino",
                Description = "Mięsko na obiadek",
                ImagePath = "wino",
                Price = 30
            };
            database.InsertIntoTable(wino);

            Items wodka = new Items()
            {
                Name = "Wódka",
                Description = "Na grube imprezy!",
                ImagePath = "wódka",
                Price = 50
            };
            database.InsertIntoTable(wodka);
        }
    }
}