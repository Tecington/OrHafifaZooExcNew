﻿using Zoo.Attributes;

namespace Zoo.Models.Animals.Fish.Species.Sharks
{
    [UnSerializable]
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