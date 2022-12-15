using OrHafifaZooExcNew.Models.Interfaces;

namespace OrHafifaZooExcNew.Models.Serializers
{
    internal abstract class Serializer
    {
        internal abstract string Serialize(IEnumerable<ISerializableObject> objects);
        internal abstract string Serialize(ISerializableObject obj);
        internal abstract string Serialize(string str);
        internal abstract string Serialize(bool value);

        protected string SerializeProperty(object prop)
        {

            return prop switch
            {
                ISerializableObject value => Serialize(value),
                string text => Serialize(text),
                IEnumerable<ISerializableObject> list => Serialize(list),
                bool value => Serialize(value),
                _ => $"{(int)prop},"
            };
        }
    }
}