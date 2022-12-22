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

        protected string SerializeProperty(object property)
        {
            //Dictionary<Type, Func<object, string>> dictionary = new ()
            //{
            //    {typeof(string), Serialize}
            //};

            return property switch
            {
                string text => Serialize(text),
                IEnumerable<object> list => Serialize(list),
                bool value => Serialize(value),
                int number => Serialize(number),
                Enum enumProperty => Serialize(enumProperty), // Cant use Enum like that?
                _ => Serialize(property),
            };
        }
    }
}