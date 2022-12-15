namespace OrHafifaZooExcNew.Models.Serializers
{
    internal abstract class Serializer
    {
        internal abstract string Serialize(IEnumerable<object> objects);
        internal abstract string Serialize(object obj);
        internal abstract string Serialize(string str);
        internal abstract string Serialize(bool value);
        internal abstract string Serialize(Enum enumProperty);
        internal abstract string Serialize(int number);

        protected string SerializeProperty(object prop)
        {

            return prop switch
            {
                string text => Serialize(text),
                IEnumerable<object> list => Serialize(list),
                bool value => Serialize(value),
                int number => Serialize(number),
                Enum enumProperty => Serialize(enumProperty),
                object value => Serialize(value),
                _ => $"{prop},"
            };
        }
    }
}