using Zoo.Models.Animals.AnimalFamilies;
using Zoo.Models.Attributes;
using Zoo.Models.Enums;

namespace Zoo.Models.Animals
{
    [UnSerializable, Animal]
    public class Shark : Fish
    {
        public SharkType SharkType { get; set; }
        public bool IsLawyer { get; set; }

        public Shark()
        {
            Type = GetType().Name;
        }
    }
}