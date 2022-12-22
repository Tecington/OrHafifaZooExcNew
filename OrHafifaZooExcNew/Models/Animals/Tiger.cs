﻿using OrHafifaZooExcNew.Models.AnimalFamilies;
using OrHafifaZooExcNew.Models.CustomAttributes;

namespace OrHafifaZooExcNew.Models.Animals
{
    [IsSerializable(true)]
    internal class Tiger : Mammal
    {
        public int Stripes { get; set; }
        public int HumansEaten { get; set; }

        public Tiger()
        {
            Type = GetType().Name;
        }
    }
}