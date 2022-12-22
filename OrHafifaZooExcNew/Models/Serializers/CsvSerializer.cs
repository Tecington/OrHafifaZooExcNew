namespace OrHafifaZooExcNew.Models.Serializers
{
    internal class CsvSerializer : Serializer
    {
        public override string Serialize(IEnumerable<object> objects)
        {
            var csvString = FilterUnSerializable(objects).Select(Serialize)
                .Aggregate(string.Empty, (current, currentObjectCsvString) => 
                    $"{current}{currentObjectCsvString}\n");

            return RemoveExcessChars(csvString);
        }

        public override string Serialize(object? obj)
        {
            if (!IsValidObject(obj))
            {
                return string.Empty;
            }

            var propertyInfos = obj.GetType().GetProperties();

            var csvString = propertyInfos.Aggregate(string.Empty, (serializedString, currentInfo) => 
                $"{serializedString}{SerializeProperty(currentInfo.GetValue(obj))}");

            //TODO: Deletes , when object within object (the 3 from rock in otter doesn't have ,)

            return RemoveExcessChars(csvString);
        }

        public override string Serialize(string str) => $"{str},";

        public override string Serialize(bool value) => $"{value.ToString().ToUpper()},";

        public override string Serialize(Enum enumProperty) => $"{Convert.ToInt32(enumProperty)},";
        public override string Serialize(int number) => $"{number},";
    }
}