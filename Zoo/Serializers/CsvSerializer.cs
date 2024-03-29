﻿namespace Zoo.Serializers
{
    internal class CsvSerializer : Serializer
    {
        public override string Serialize(IEnumerable<object> objects)
        {
            var csvString = objects.Where(IsSerializable).Select(Serialize)
                .Aggregate(string.Empty, (current, currentObjectCsvString) =>
                    $"{current}{currentObjectCsvString}{Environment.NewLine}");

            return RemoveExcessChars(csvString);
        }

        public override string Serialize(object? obj)
        {
            if (!IsSerializable(obj))
            {
                return string.Empty;
            }

            var propertyInfos = obj.GetType().GetProperties();

            var csvString = propertyInfos.Aggregate(string.Empty, (serializedString, currentInfo) =>
                $"{serializedString}{SerializeProperty(currentInfo.GetValue(obj))}");

            return RemoveExcessChars(csvString);
        }

        protected override string Serialize(string str) => $"{str},";

        protected override string Serialize(bool value) => $"{value.ToString().ToUpper()},";

        protected override string Serialize(Enum enumProperty) => $"{Convert.ToInt32(enumProperty)},";

        protected override string Serialize(int number) => $"{number},";
    }
}