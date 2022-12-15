using OrHafifaZooExcNew.Models.Enums;
using OrHafifaZooExcNew.Models.Interfaces;

namespace OrHafifaZooExcNew.Models.AnimalFamilies
{
    internal abstract class Animal : ISerializableObject
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string FavoriteHumanName { get; set; }

        public virtual Dictionary<string, object> GetProperties()
        {
            return new Dictionary<string, object>()
            {
                {"type", ""},
                { $"{nameof(Name)}", Name },
                { $"{nameof(Age)}", Age },
                { $"{nameof(Gender)}", Gender },
                { $"{nameof(FavoriteHumanName)}", FavoriteHumanName }
            };
        }
    }
}