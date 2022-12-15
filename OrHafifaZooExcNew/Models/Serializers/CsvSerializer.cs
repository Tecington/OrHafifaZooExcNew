namespace OrHafifaZooExcNew.Models.Serializers
{
    internal class CsvSerializer : Serializer
    {
        internal override string Serialize(IEnumerable<object> objects)
        {
            var csvString = objects.Select(Serialize)
                .Aggregate(string.Empty, (current, currentObjectCsvString) => 
                    current + (currentObjectCsvString + "\n"));

            return RemoveExcessFinalChar(csvString);
        }

        internal override string Serialize(object serializableObject)
        {
            var propertyInfos = serializableObject.GetType().GetProperties();

            var csvString = propertyInfos.Aggregate(string.Empty, (serializedString, currentInfo) => 
                $"{serializedString}{SerializeProperty(currentInfo.GetValue(serializableObject, null))}");

            return RemoveExcessFinalChar(csvString);
        }

        internal override string Serialize(string str) => $"{str},";

        internal override string Serialize(bool value) => $"{value.ToString().ToUpper()},";

        internal override string Serialize(Enum enumProperty) => $"{enumProperty},";

        private static string RemoveExcessFinalChar(string str)
        {
            return str.TrimEnd(',');
        }
    }
}