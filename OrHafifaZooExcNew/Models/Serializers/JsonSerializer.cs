using System.Reflection;
using OrHafifaZooExcNew.Models.CustomAttributes;

namespace OrHafifaZooExcNew.Models.Serializers
{
    internal class JsonSerializer : Serializer
    {
        private int _tabsCounter;

        internal override string Serialize(IEnumerable<object> objects)
        {
            _tabsCounter++;

            var jsonString = FilterSerializable(objects).Select(Serialize)
                .Aggregate("[\n", (current, currentObjectJsonString) =>
                    current + ($"{GetTabsAsString(_tabsCounter)}{currentObjectJsonString}\n"));

            jsonString = RemoveTrailingComma(jsonString);

            _tabsCounter--;

            return $"{jsonString}\n]";
        }

        private IEnumerable<object> FilterSerializable(IEnumerable<object> objects)
        {
            return objects.Where(obj =>
            {
                var attributes = obj.GetType().GetCustomAttributes();

                return attributes.OfType<IsSerializableAttribute>().Select(attribute =>
                    attribute.IsSerializable).FirstOrDefault(); 
            });
        }

        internal override string Serialize(object serializableObject)
        {
            _tabsCounter++;

            var propertyInfos = serializableObject.GetType().GetProperties();

            var jsonString = propertyInfos.Aggregate("{\n" , (currentPairString, currentInfo) =>
            {
                var propValue = currentInfo.GetValue(serializableObject, null);

                currentPairString += $"{GetTabsAsString(_tabsCounter - 1)}\t\"{currentInfo.Name}\": ";

                currentPairString += SerializeProperty(propValue) + "\n";

                return currentPairString;
            });

            _tabsCounter--;

            jsonString = RemoveTrailingComma(jsonString);

            return jsonString + $"\n{GetTabsAsString(_tabsCounter)}" + "},";
        }

        internal override string Serialize(string str) => $"\"{str}\",";

        internal override string Serialize(bool value) => $"{value},";

        internal override string Serialize(Enum enumProperty) => $"{enumProperty},";
        internal override string Serialize(int number) => $"{number},";

        private static string RemoveTrailingComma(string text)
        {
            return text.Remove(text.Length - 2, 2);
        }

        private static string GetTabsAsString(int tabsAmount) => new('\t', tabsAmount);
    }
}