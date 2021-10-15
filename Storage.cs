using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiplicatoryMegaMakingMachine
{
    public class Storage
    {
        private List<Inventory_Item> Materialinstorage { get; set; }
        private List<Inventory_Item> MaterialToFactory { get; set; }
        public Storage()
        {
            Materialinstorage = new();
            MaterialToFactory = new();
        }
        public void PopulateItemsinstorage()
        {
            Steel steel = new();
            Rubber rubber = new();

            int amounttoincrease = 4;
            int minimumamount = 3;
            for (int i = 0; i < amounttoincrease; i++)
            {
                if (Materialinstorage.FindAll(X => X.GetType() == typeof(Steel)).Count <= minimumamount)
                { Materialinstorage.Add(steel); }
                int rubbernumber = Materialinstorage.FindAll(X => X == steel).Count;
                if (Materialinstorage.FindAll(X => X.GetType() == typeof(Rubber)).Count <= minimumamount)
                { Materialinstorage.Add(rubber); }
            }
        }
        public List<Inventory_Item> UserPicksMaterials()
        {
            PopulateItemsinstorage();
            MaterialToFactory.Clear();

            while (true)
            {
                Storageview();
                Inventory_Item choice = ParseMaterial();
                if (Materialinstorage.Contains(choice))
                {
                    MaterialToFactory.Add(Materialinstorage.Find(X => X == choice));
                    Materialinstorage.Remove(Materialinstorage.Find(X => X == choice));
                }
                else
                {
                    Console.WriteLine(" The material you selected does not exist in the inventory");
                }

                Console.WriteLine("\nif you want to proceed to the factory, write \"deliver\", else press enter");
                if (Console.ReadLine().ToLower() == "deliver")
                { break; }
            }
            return MaterialToFactory;
        }
        private Inventory_Item ParseMaterial()
        {
            Console.WriteLine("\nchoose material\n");
            while (true)
            {
                string choice = Console.ReadLine().ToLower();
                if (Materialinstorage.Find(X => X.Name.ToLower() == choice) !=null)
                {
                    return Materialinstorage.Find(x => x.Name.ToLower() == choice);
                }
                Console.WriteLine("you have not chosen a valid material, try again");
            }
        }
        private void Storageview()
        {
            Console.Clear();
            Materialinstorage = Materialinstorage.OrderBy(x => x.Name).ToList();
            MaterialToFactory = MaterialToFactory.OrderBy(x => x.Name).ToList();

            Console.WriteLine("items in storage");
            for (int i = 0; i < Materialinstorage.Count; i++)
            { Console.WriteLine(Materialinstorage[i].Name); }

            Console.WriteLine("\nThese are the items headed for the factory");
            for (int i = 0; i < MaterialToFactory.Count; i++)
            { Console.WriteLine(MaterialToFactory[i].Name); }
        }
        public void AddtoStorage(List<Inventory_Item> unusedmaterials) => Materialinstorage.AddRange(unusedmaterials);
    }
}
