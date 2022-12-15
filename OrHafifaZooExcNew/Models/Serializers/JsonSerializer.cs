using OrHafifaZooExcNew.Interfaces;

namespace OrHafifaZooExcNew.Serializers
{
    internal class JsonSerializer : Serializer
    {
        private int _tabsCounter;

        internal override string Serialize(IEnumerable<ISerializableObject> objects)
        {
            _tabsCounter++;

            var jsonString = objects
                .Select(Serialize)
                .Aggregate("[\n", (current, currentObjectJsonString) =>
                    current + ($"{GetTabsAsString(_tabsCounter)}{currentObjectJsonString}\n"));

            jsonString = RemoveTrailingComma(jsonString);

            _tabsCounter--;

            return jsonString + "\n]";
        }

        internal override string Serialize(ISerializableObject serializableObject)
        {
            _tabsCounter++;

            var dictionary = serializableObject.GetProperties();

            var jsonString = dictionary.Keys.Aggregate("{\n" , (currentPairString, currentKey) =>
            {
                var propValue = dictionary[currentKey];

                currentPairString += $"{GetTabsAsString(_tabsCounter - 1)}\t\"{currentKey}\": ";

                currentPairString += SerializeProperty(propValue) + "\n";

                return currentPairString;
            });

            _tabsCounter--;

            jsonString = RemoveTrailingComma(jsonString);

            return jsonString + $"\n{GetTabsAsString(_tabsCounter)}" + "},";
        }

        internal override string Serialize(string str) => $"\"{str}\",";

        internal override string Serialize(bool value) => $"{value},";
        
        private static string RemoveTrailingComma(string text)
        {
            return text.Remove(text.Length - 2, 2);
        }

        private static string GetTabsAsString(int tabsAmount) => new('\t', tabsAmount);
    }
}