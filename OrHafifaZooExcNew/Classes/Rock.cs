using OrHafifaZooExcNew.Interfaces;

namespace OrHafifaZooExcNew.Classes
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