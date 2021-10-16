using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiplicatoryMegaMakingMachine
{
    public class Storage
    {
        private List<IItems> Materialinstorage { get; set; }
        private List<IItems> MaterialToFactory { get; set; }
        private static readonly int _minStock = 4;
        public Storage()
        {
            Materialinstorage = new();
            MaterialToFactory = new();
        }
        
        public void CheckStorage()
        {
   
            PopulateStorage(typeof(Steel));
            PopulateStorage(typeof(Rubber));

        }
        private void PopulateStorage(Type t)
        {
            while (Materialinstorage.FindAll(x=>x.GetType()== t).Count<_minStock)
            {
                Materialinstorage.Add((IItems)Activator.CreateInstance(t));
            }
       
        }

        public List<IItems> UserPicksMaterials()
        {
            CheckStorage();
            MaterialToFactory.Clear();

            while (true)
            {
                Storageview();
                IItems choice = ParseMaterial();
                if (Materialinstorage.Contains(choice))
                {
                    MaterialToFactory.Add(Materialinstorage.Find(X => X == choice));
                    Materialinstorage.Remove(Materialinstorage.Find(X => X == choice));
                }
                Console.WriteLine("if you want to deliver the inventory to the factory, write \"deliver\"");
                if (Console.ReadLine().Equals("deliver",StringComparison.OrdinalIgnoreCase))
                {
                    return MaterialToFactory;
                }
                else
                {
                    Console.WriteLine(" The material you selected does not exist in the inventory");
                }             
            }
            
        }
        private IItems ParseMaterial()
        {
            Console.WriteLine("\nchoose material\n");
            while (true)
            {
                string choice = Console.ReadLine();
                if (Materialinstorage.Any(X => X.Name.Equals(choice,StringComparison.OrdinalIgnoreCase)))
                {
                    return Materialinstorage.Find(x => x.Name.Equals(choice,StringComparison.OrdinalIgnoreCase));
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
            Console.WriteLine("\nif you want to proceed to the factory, write \"deliver\", else press enter");
        }
        public void AddtoStorage(List<IItems> unusedmaterials) => Materialinstorage.AddRange(unusedmaterials);
    }
}
