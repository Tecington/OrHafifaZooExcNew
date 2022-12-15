using OrHafifaZooExcNew.Models.Interfaces;

namespace OrHafifaZooExcNew.Models.Animals.Otters
{
    internal class Rock : ISerializableObject
    {
        public int Weight { get; set; }

        public Dictionary<string, object> GetProperties()
        {
            return new Dictionary<string, object>
            {
                {$"{nameof(Weight)}", Weight},
            };
        }
    }
}