using System.Collections.Generic;

namespace MultiplicatoryMegaMakingMachine
{
    class BlueprintProvider
    {
        public List<ICraftable_Items> ProvideBlueprints() {
            Car car = new();
            Toaster toaster = new();
            Wheel wheel = new();

            return new List<ICraftable_Items> { car, toaster, wheel };
        }
    }
}
