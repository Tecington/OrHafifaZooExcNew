namespace OrHafifaZooExcNew.Models.Serializers
{
    internal class JsonSerializer : Serializer
    {
        private int _tabsCounter;

        public override string Serialize(IEnumerable<object> objects)
        {
            _tabsCounter++;

            var jsonString = FilterUnSerializable(objects).Select(Serialize)
                .Aggregate("[\n", (current, currentObjectJsonString) => 
                    $"{current}{GetTabsAsString(_tabsCounter)}{currentObjectJsonString}\n");

            jsonString = RemoveExcessChars(jsonString);

            _tabsCounter--;

            return $"{jsonString}\n]";
        }

        public override string Serialize(object? obj)
        {
            if (!IsValidObject(obj))
            {
                return string.Empty;
            }

            _tabsCounter++;

            var propertyInfos = obj.GetType().GetProperties();

            var jsonString = propertyInfos.Aggregate("{\n", (currentPairString, currentInfo) =>
            {
                var propValue = currentInfo.GetValue(obj);

                currentPairString += $"{GetTabsAsString(_tabsCounter - 1)}\t\"{currentInfo.Name}\": ";

                currentPairString += $"{SerializeProperty(propValue)}\n";

                return currentPairString;
            });

            _tabsCounter--;

            jsonString = RemoveExcessChars(jsonString);

            return jsonString + $"\n{GetTabsAsString(_tabsCounter)}" + "},";
        }

        public override string Serialize(string str) => $"\"{str}\",";

        public override string Serialize(bool value) => $"{value},";

        public override string Serialize(Enum enumProperty) => $"{Convert.ToInt32(enumProperty)},";

        public override string Serialize(int number) => $"{number},";

        private static string GetTabsAsString(int tabsAmount) => new('\t', tabsAmount);
    }
}