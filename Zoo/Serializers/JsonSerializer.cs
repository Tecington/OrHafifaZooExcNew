namespace Zoo.Serializers
{
    internal class JsonSerializer : Serializer
    {
        private int _tabsCounter;

        public override string Serialize(IEnumerable<object> objects)
        {
            _tabsCounter++;

            var jsonString = objects.Where(IsSerializable).Select(Serialize)
                .Aggregate($"[{Environment.NewLine}", (current, currentObjectJsonString) =>
                    $"{current}{GetTabsAsString(_tabsCounter)}" +
                    $"{currentObjectJsonString}{Environment.NewLine}");

            jsonString = RemoveExcessChars(jsonString);

            _tabsCounter--;

            return $"{jsonString}{Environment.NewLine}]";
        }

        public override string Serialize(object? obj)
        {
            if (!IsValidObject(obj))
            {
                return string.Empty;
            }

            _tabsCounter++;

            var propertyInfos = obj.GetType().GetProperties();

            var jsonString = propertyInfos.Aggregate("{" + $"{Environment.NewLine}", 
                (currentPairString, currentInfo) =>
            {
                var propValue = currentInfo.GetValue(obj);

                currentPairString += $"{GetTabsAsString(_tabsCounter - 1)}\t\"{currentInfo.Name}\": ";

                currentPairString += $"{SerializeProperty(propValue)}{Environment.NewLine}";

                return currentPairString;
            });

            _tabsCounter--;

            jsonString = RemoveExcessChars(jsonString);

            return jsonString + $"{Environment.NewLine}{GetTabsAsString(_tabsCounter)}" + "},";
        }

        public override string Serialize(string str) => $"\"{str}\",";

        public override string Serialize(bool value) => $"{value},";

        public override string Serialize(Enum enumProperty) => $"{Convert.ToInt32(enumProperty)},";

        public override string Serialize(int number) => $"{number},";

        private static string GetTabsAsString(int tabsAmount) => new('\t', tabsAmount);
    }
}