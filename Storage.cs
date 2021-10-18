using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiplicatoryMegaMakingMachine
{
    public class Storage
    {
        private List<IItems> Materialinstorage { get; set; }
        private List<IItems> MaterialToFactory { get; set; }
        private List<Type> RawMaterials { get; set; } = new() { typeof(Steel), typeof(Rubber) };
        public Storage()
        {
            Materialinstorage = new();
            MaterialToFactory = new();
        }

        public void populatestorage()
        {
            int minStock = 4;
            foreach (var material in RawMaterials)
            {
                while (Materialinstorage.FindAll(x => x.GetType() == material).Count < minStock)
                {
                    Materialinstorage.Add((IItems)Activator.CreateInstance(material));
                }
            }
        }

        public List<IItems> UserPicksMaterials()
        {
            populatestorage();
            MaterialToFactory.Clear();

            while (true)
            {
                Storageview();

               string Choice = Console.ReadLine();
                if (Materialinstorage.Any(x=>x.Name == Choice))
                {
                    MaterialToFactory.Add(Materialinstorage.Find(X => X.Name == Choice));
                    Materialinstorage.Remove(Materialinstorage.Find(X => X.Name == Choice));
                }
                else
                {
                    Console.WriteLine("you have not entered a valid material");
                }
                
                Console.WriteLine("if you want to deliver the inventory to the factory, write \"deliver\"");
                if (Console.ReadLine().Equals("deliver", StringComparison.OrdinalIgnoreCase))
                {
                    return MaterialToFactory;
                }
            }
        }
        private void Storageview()
        {
            Console.Clear();
            Materialinstorage = Materialinstorage.OrderBy(x => x.Name).ToList();
            MaterialToFactory = MaterialToFactory.OrderBy(x => x.Name).ToList();
            List<Type> displayedstorage = new();
            List<Type> displayedFactory = new();

            Console.WriteLine("items in storage\n");
            foreach (var item in Materialinstorage)
            {
                if (displayedstorage.Contains(item.GetType()) == false)
                {
                    Console.WriteLine($"{item.Name,-7}: {Materialinstorage.FindAll(x => x.Name == item.Name).Count}");
                    displayedstorage.Add(item.GetType());
                }
            }

            Console.WriteLine("items headed for the factory\n");
            foreach (var item in MaterialToFactory)
            {
                if (displayedFactory.Contains(item.GetType()) == false)
                {
                    Console.WriteLine($"{item.Name,-7}: {MaterialToFactory.FindAll(x => x.Name == item.Name).Count}");
                    displayedFactory.Add(item.GetType());
                }
            }
        }
        public void AddtoStorage(List<IItems> unusedmaterials) => Materialinstorage.AddRange(unusedmaterials);
    }
}
