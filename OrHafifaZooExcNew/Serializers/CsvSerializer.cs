using OrHafifaZooExcNew.Interfaces;

namespace OrHafifaZooExcNew.Serializers
{
    internal class CsvSerializer : Serializer
    {
        internal override string Serialize(IEnumerable<ISerializableObject> objects)
        {
            var csvString = objects.Select(Serialize)
                .Aggregate(string.Empty, (current, currentObjectCsvString) => 
                    current + (currentObjectCsvString + "\n"));

            return RemoveExcessFinalChar(csvString);
        }

        internal override string Serialize(ISerializableObject serializableObject)
        {
            var dictionary = serializableObject.GetProperties();

            var csvString = dictionary.Values.Aggregate(string.Empty, (current, value) => 
                current + SerializeProperty(value));

            return RemoveExcessFinalChar(csvString);
        }

        internal override string Serialize(string str) => $"{str},";

        internal override string Serialize(bool value) => $"{value.ToString().ToUpper()},";

        private static string RemoveExcessFinalChar(string str)
        {
            return str.Remove(str.Length - 1, 1);
        }
    }
}