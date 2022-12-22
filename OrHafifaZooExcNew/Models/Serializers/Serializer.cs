using OrHafifaZooExcNew.Models.CustomAttributes;
using System.Reflection;

namespace OrHafifaZooExcNew.Models.Serializers
{
    public abstract class Serializer
    {
        public abstract string Serialize(IEnumerable<object> objects);
        public abstract string Serialize(object obj);
        public abstract string Serialize(string str);
        public abstract string Serialize(bool value);
        public abstract string Serialize(Enum enumProperty);
        public abstract string Serialize(int number);

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

        protected IEnumerable<object> FilterUnSerializable(IEnumerable<object> objects) => objects.Where(IsSerializable);

        protected bool IsSerializable(object obj) => 
            obj.GetType().GetCustomAttribute(typeof(UnSerializableAttribute)) is null;

        protected string RemoveExcessChars(string text) => text.TrimEnd(',', '\n', '\t');

        protected bool IsValidObject(object? obj) => obj is not null && IsSerializable(obj);
    }
}