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
        private static readonly int _minStock = 4;
        public Storage()
        {
            Materialinstorage = new();
            MaterialToFactory = new();
        }

        public void populatestorage()
        {
            foreach (var material in RawMaterials)
            {
                while (Materialinstorage.FindAll(x => x.GetType() == material).Count < _minStock)
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
                IItems choice = ParseMaterial();
                if (Materialinstorage.Contains(choice))
                {
                    MaterialToFactory.Add(Materialinstorage.Find(X => X == choice));
                    Materialinstorage.Remove(Materialinstorage.Find(X => X == choice));
                }
                Console.WriteLine("if you want to deliver the inventory to the factory, write \"deliver\"");

                if (Console.ReadLine().Equals("deliver", StringComparison.OrdinalIgnoreCase))
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
                if (Materialinstorage.Any(X => X.Name.Equals(choice, StringComparison.OrdinalIgnoreCase)))
                {
                    return Materialinstorage.Find(x => x.Name.Equals(choice, StringComparison.OrdinalIgnoreCase));
                }

                Console.WriteLine("you have not chosen a valid material, try again");
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
