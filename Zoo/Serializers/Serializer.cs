using System.Reflection;
using Zoo.Attributes;

namespace Zoo.Serializers
{
    public abstract class Serializer
    {
        public abstract string Serialize(IEnumerable<object> objects);
        public abstract string Serialize(object obj);
        protected abstract string Serialize(string str);
        protected abstract string Serialize(bool value);
        protected abstract string Serialize(Enum enumProperty);
        protected abstract string Serialize(int number);

        protected string SerializeProperty(object property)
        {
            return property switch
            {
                string text => Serialize(text),
                IEnumerable<object> list => Serialize(list),
                bool value => Serialize(value),
                int number => Serialize(number),
                Enum enumProperty => Serialize(enumProperty),
                _ => Serialize(property),
            };
        }

        protected bool IsSerializable(object obj) =>
            obj is not null && obj.GetType().GetCustomAttribute(typeof(UnSerializableAttribute)) is null;

        protected string RemoveExcessChars(string text) => text.TrimEnd(',', '\n', '\t');
    }
}