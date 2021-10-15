using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiplicatoryMegaMakingMachine
{
    public class Storage
    {
        private List<Inventory_Item> MaterialInStorage { get; set; }
         List<Inventory_Item> MaterialToFactory { get; set; }
        public Storage()
        {
            MaterialInStorage = new();
            MaterialToFactory = new();
        }
        public void PopulateItemsinstorage()
        {
            Steel steel = new();
            Rubber rubber = new();
            for (int i = 0; i < 4; i++)
            {
                if (MaterialInStorage.FindAll(X=>X ==steel).Count < 4)
                { MaterialInStorage.Add(steel);}
                if (MaterialInStorage.FindAll(X => X == rubber).Count < 4)
                { MaterialInStorage.Add(rubber);}
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
                if (MaterialInStorage.Contains(choice))
                {
                    MaterialToFactory.Add(MaterialInStorage.Find(X=>X ==choice));
                    MaterialInStorage.Remove(MaterialInStorage.Find(X=>X ==choice));
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
                if (MaterialInStorage.FindAll(X => X.Name.ToLower() == choice).Count >0)
                {
                    return MaterialInStorage.Find(x => x.Name.ToLower() == choice);
                }
                Console.WriteLine("you have not chosen a valid material, try again");
            }
        }
        private void Storageview()
        {
            Console.Clear();

            MaterialInStorage = MaterialInStorage.OrderBy(x => x.Name).ToList();
            MaterialToFactory = MaterialToFactory.OrderBy(x => x.Name).ToList();

            Console.WriteLine("items in storage");
            for (int i = 0; i < MaterialInStorage.Count; i++)
            { Console.WriteLine(MaterialInStorage[i].Name); }

            Console.WriteLine("\nThese are the items headed for the factory");
            for (int i = 0; i < MaterialToFactory.Count; i++)
            { Console.WriteLine(MaterialToFactory[i].Name); }
        }
        public void AddtoStorage(List<Inventory_Item> unusedmaterials) => MaterialInStorage.AddRange(unusedmaterials);
    }
}
