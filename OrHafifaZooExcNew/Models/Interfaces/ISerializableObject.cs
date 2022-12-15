namespace OrHafifaZooExcNew.Models.Interfaces
{
    internal interface ISerializableObject
    {
        public Dictionary<string, object> GetProperties();
    }
}