using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicatoryMegaMakingMachine
{
    class Workshop
    {
        public SelfCreatedItem CreateItemblueprint()
        {
            Dictionary<string, int> requirements = new();
            Console.WriteLine("what do you want to call your item?");
            string name = Console.ReadLine();

            Console.WriteLine("do you want the item to require steel?\n Yes/No");
            if (Console.ReadLine().Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(" how many ingots of steel do you want the item to Require=");
                requirements.Add("Steel", Tryparse());
            }

            Console.WriteLine("do you want the item to require rubber?\n Yes/No");
            if (Console.ReadLine().Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(" how many units of rubber do you want the item to Require=");
                requirements.Add("Rubber", Tryparse());
            }
            Console.WriteLine("do you want the item to require Wheels?\n Yes/No");
            if (Console.ReadLine().Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(" how many Wheels do you want the item to Require=");
                requirements.Add("Wheel", Tryparse());
            }
            SelfCreatedItem selfcreateditem = new(name, requirements);
            return selfcreateditem;
        }
        private int Tryparse()
        {
            int output;
            while (int.TryParse(Console.ReadLine(), out output) == false)
            {
                Console.WriteLine(" you have not submitted a valid integer");
            }
            return output;
        }


    }


}
}
}
