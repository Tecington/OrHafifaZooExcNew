using System.Text.RegularExpressions;
using Zoo.Models.Animals;

namespace ZooConsole.IO
{
    internal static class Validation
    {
        internal static bool IsComplexObject(object obj) =>
            !obj.GetType().IsPrimitive && obj is not string && !obj.GetType().IsEnum;

        internal static bool IsPositive(string intString) =>
            IsIntInRange(intString, min: 0);

        internal static bool IsIndexInRange(string intString, int length) =>
            IsIntInRange(intString, min: 1, max: length);

        internal static bool IsIntInRange(string intString,
            int min = int.MinValue, int max = int.MaxValue)
        {
            return int.TryParse(intString, out var intValue)
                   && intValue >= min && intValue <= max;
        }

        internal static bool IsValidEnumValue(string option, Type enumType)
        {
            return int.TryParse(option, out var optionIntValue)
                   && Enum.IsDefined(enumType, optionIntValue);
        }

        internal static bool IsLettersOnly(string str) =>
            Regex.IsMatch(str, @"^[a-zA-Z]+$");

        internal static bool IsNameAvailable(string name, List<Animal> animals) =>
            !animals.Where(animal => animal.Name.Equals(name)).Any();
    }
}
