using System.Reflection;
using System.Text.RegularExpressions;
using Zoo.Models.AnimalFamilies;
using ZooConsole.Enums;
using ZooConsole.Properties;

namespace ZooConsole
{
    internal static class ConsoleIo
    {
        internal static MenuOptions GetMenuOption()
        {
            var verifyInput = (string option) =>
                VerifyEnumValue(option, typeof(MenuOptions));

            var menuOption = GetVerifiedInput(ShowMainMenu, verifyInput);

            return (MenuOptions)int.Parse(menuOption);
        }

        internal static void PrintZoo(List<Animal> animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine($"{animal.Name} - {animal.Type}:");
                PrintObjectProperties(animal);
                Console.WriteLine();
            }
        }

        internal static Type GetAnimalTypeToCreate(List<Type> animalTypes)
        {
            var verifyInput = (string option) =>
                VerifyIndexInRange(option, animalTypes.Count);
            var printOptions = () => PrintAnimalTypes(animalTypes);

            var animalIndex = GetVerifiedInput(printOptions, verifyInput);

            return animalTypes[int.Parse(animalIndex) - 1];
        }

        private static void PrintAnimalTypes(List<Type> types)
        {
            Console.WriteLine(Resources.SelectAnimalTypeToCreateMessage);

            for(int i = 0; i < types.Count; i++)
            {
                Console.WriteLine($"{i + 1} {types[i].Name}");
            }
        }

        // Change all the getters to just a GetProperty with different params
        internal static int GetEnumProperty(Type enumType)
        {
            var verifyInput = (string option) =>
                VerifyEnumValue(option, enumType);
            var printOptions = () => PrintEnumOptions(enumType);

            var enumIndex = GetVerifiedInput(printOptions, verifyInput);

            return int.Parse(enumIndex) - 1;
        }

        internal static int GetIntProperty(string getPropertyMessage)
        {
            var printOptions = () => Console.WriteLine(getPropertyMessage);

            var intValue = GetVerifiedInput(printOptions, VerifyIntValue);

            return int.Parse(intValue);
        }

        internal static string GetNameProperty(string getNameMessage, List<Animal> animals)
        {
            var verifyInput = (string str) => VerifyString(str) 
                && VerifyNameAvailable(str, animals);

            return GetStringProperty(getNameMessage, verifyInput);
        }

        internal static string GetStringProperty(string getPropertyMessage) => 
            GetStringProperty(getPropertyMessage, VerifyString);

        private static string GetStringProperty(string getPropertyMessage, 
            Func<string, bool> verifyInput)
        {
            var printOptions = () => Console.WriteLine(getPropertyMessage);

            var str = GetVerifiedInput(printOptions, verifyInput);

            return str;
        }

        internal static Animal GetAnimalToEdit(List<Animal> animals)
        {
            var verifyInput = (string option) => 
                VerifyIndexInRange(option, animals.Count);
            var printOptions = () => PrintAnimalEditList(animals);

            var animalIndex = GetVerifiedInput(printOptions, verifyInput);

            return animals[int.Parse(animalIndex) - 1];
        }

        internal static PropertyInfo GetPropertyToEdit(Animal animal)
        {
            var propertyInfos = animal.GetType().GetProperties();

            var verifyInput = (string option) => 
                VerifyIndexInRange(option, propertyInfos.Length);
            var printOptions = () => PrintAnimalProperties(animal);

            var propertyIndex = GetVerifiedInput(printOptions, verifyInput);

            return propertyInfos[int.Parse(propertyIndex) - 1];
        }

        private static void PrintAnimalProperties(Animal animal)
        {
            Console.WriteLine($"{Resources.ChoosePropertyUserMessage}" +
                $"{animal.Name} - {animal.Type}:");
            PrintObjectProperties(animal);
        }

        private static void PrintObjectProperties(object obj)
        {
            var propertyInfos = obj.GetType().GetProperties();

            for (var i = 0; i < propertyInfos.Length; i++)
            {
                PrintProperty(propertyInfos[i], obj, i);
            }
        }

        private static void PrintProperty(PropertyInfo propertyInfo, object obj, int index)
        {
            var propValue = propertyInfo.GetValue(obj);

            if (!IsComplexObject(propValue))
            {
                PrintListRecord(index, propertyInfo.Name, propValue?.ToString());
            }
            else
            {
                Console.WriteLine($"{index + 1}. {propertyInfo.Name}:\n" + "{");
                PrintObjectProperties(propValue);
                Console.WriteLine("}");
            }
        }

        private static void PrintListRecord(int index, string name, string value)
        {
            Console.WriteLine($"{index + 1}. {name} - {value}");
        }

        private static void PrintAnimalEditList(List<Animal> animals)
        {
            Console.WriteLine(Resources.SelectAnimalToEditUserMessage);

            for (var i = 0; i < animals.Count; i++)
            {
                PrintListRecord(i, animals[i].Name, animals[i].Type);
            }
        }

        private static void ShowMainMenu() => 
            PrintEnumOptions(typeof(MenuOptions));

        private static void PrintEnumOptions(Type enumType)
        {
            Console.WriteLine(@$"{string.Format(Resources.EnumOptionsTitle, 
                enumType.Name)}");

            var names = enumType.GetEnumNames();

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {names[i]}");
            }
        }

        private static bool IsComplexObject(object obj) => 
            !obj.GetType().IsPrimitive && obj is not string && !obj.GetType().IsEnum;

        private static bool VerifyIndexInRange(string index, int length)
        {
            return int.TryParse(index, out var indexIntValue)
                   && indexIntValue > 0 && indexIntValue <= length;
        }

        private static bool VerifyIntValue(string intString)
        {
            return int.TryParse(intString, out var intValue)
                   && intValue >= 0;
        }

        private static bool VerifyEnumValue(string option, Type enumType)
        {
            return int.TryParse(option, out var optionIntValue)
                   && Enum.IsDefined(enumType, optionIntValue);
        }

        private static bool VerifyString(string str) => 
            Regex.IsMatch(str, @"^[a-zA-Z]+$");

        private static bool VerifyNameAvailable(string name, List<Animal> animals) => 
            !animals.Where(animal => animal.Name.Equals(name)).Any();

        private static string GetVerifiedInput(Action printOptions, Func<string, bool> verifyOption)
        {
            printOptions();

            var option = Console.ReadLine();

            while (!verifyOption(option))
            {
                Console.WriteLine(Resources.InvalidOptionUserMessage);
                printOptions();

                option = Console.ReadLine();
            }

            return option;
        }
    }
}