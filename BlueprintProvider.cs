using System.Collections.Generic;

namespace MultiplicatoryMegaMakingMachine
{
    class BlueprintProvider
    {
        public List<ICraftable_Items> ProvideBlueprints()
        {
            return new List<ICraftable_Items> { new Car(), new Toaster(), new Wheel() };
        }
    }
}
