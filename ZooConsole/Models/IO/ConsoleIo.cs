using System.Reflection;
using Zoo.Models.Animals;
using ZooConsole.Models.Enums;
using ZooConsole.Properties;

namespace ZooConsole.Models.IO
{
    internal static class ConsoleIo
    {
        internal static void Write(string text)
        {
            Console.WriteLine(text);
        }

        internal static MenuOptions GetMenuOption()
        {
            var verifyInput = (string option) =>
                Validation.IsValidEnumValue(option, typeof(MenuOptions));

            var menuOption = GetValidInput(PrintMainMenu, verifyInput);

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
                Validation.IsIntInRange(option, min: 1, max: animalTypes.Count);
            var printOptions = () => PrintAnimalTypes(animalTypes);

            var animalIndex = GetValidInput(printOptions, verifyInput);

            return animalTypes[int.Parse(animalIndex) - 1];
        }

        private static void PrintAnimalTypes(List<Type> types)
        {
            Console.WriteLine(Resources.SelectAnimalTypeToCreateMessage);

            for (int i = 0; i < types.Count; i++)
            {
                Console.WriteLine($"{i + 1} {types[i].Name}");
            }
        }

        internal static int GetEnumProperty(Type enumType)
        {
            var verifyInput = (string option) =>
                Validation.IsValidEnumValue(option, enumType);
            var printOptions = () =>
            {
                Console.WriteLine(string.Format
                    (Resources.GetPropertyUserMessage, enumType.Name));
                PrintEnumOptions(enumType);
            };

            var enumIndex = GetValidInput(printOptions, verifyInput);

            return int.Parse(enumIndex);
        }

        internal static int GetIntProperty(PropertyInfo propertyInfo)
        {
            var verifyInput = (string option) =>
                Validation.IsIntInRange(option, min: 0);
            var printOptions = () => Console.WriteLine(string.Format
                (Resources.GetPropertyUserMessage, propertyInfo.Name));

            var value = GetValidInput(printOptions, verifyInput);

            return int.Parse(value);
        }

        internal static bool GetBoolProperty(PropertyInfo propertyInfo)
        {
            var verifyInput = (string option) => Validation.IsIntInRange(option, 1, 2);
            var printOptions = () =>
            {
                Console.WriteLine(@$"{string.Format
                    (Resources.GetPropertyUserMessage, propertyInfo.Name)}" +
                    $"\n{Resources.BoolOptions}");
            };

            var value = GetValidInput(printOptions, verifyInput);

            return int.Parse(value) == 1;
        }

        internal static string GetNameProperty(PropertyInfo propertyInfo, List<Animal> animals)
        {
            var verifyInput = (string str) => Validation.IsValidString(str)
                && Validation.IsNameAvailable(str, animals);

            return GetStringProperty(propertyInfo, verifyInput);
        }

        internal static string GetStringProperty(PropertyInfo propertyInfo) =>
            GetStringProperty(propertyInfo, Validation.IsValidString);

        private static string GetStringProperty(PropertyInfo propertyInfo,
            Func<string, bool> verifyInput)
        {
            var printOptions = () => Console.WriteLine(string.Format
                (Resources.GetPropertyUserMessage, propertyInfo.Name));

            var str = GetValidInput(printOptions, verifyInput);

            return str;
        }

        internal static Animal GetAnimalToEdit(List<Animal> animals)
        {
            var verifyInput = (string option) =>
                Validation.IsIntInRange(option, min: 1, max: animals.Count);
            var printOptions = () => PrintAnimalEditList(animals);

            var animalIndex = GetValidInput(printOptions, verifyInput);

            return animals[int.Parse(animalIndex) - 1];
        }

        internal static PropertyInfo GetPropertyToEdit(Animal animal)
        {
            var propertyInfos = animal.GetType().GetProperties();

            var verifyInput = (string option) =>
                Validation.IsIntInRange(option, min: 1, max: propertyInfos.Length);
            var printOptions = () => PrintAnimalProperties(animal);

            var propertyIndex = GetValidInput(printOptions, verifyInput);

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

            var propertyInfosList = propertyInfos.Where(propertyInfo => !propertyInfo.Name.Equals("Type")).ToList();

            for (var i = 0; i < propertyInfosList.Count; i++)
            {
                PrintProperty(propertyInfos[i], obj, i);
            }
        }

        private static void PrintProperty(PropertyInfo propertyInfo, object obj, int index)
        {
            var propertyValue = propertyInfo.GetValue(obj);

            if (!Validation.IsComplexObject(propertyValue))
            {
                PrintListRecord(index, propertyInfo.Name, propertyValue?.ToString());
            }
            else
            {
                Console.WriteLine($"{index + 1}. {propertyInfo.Name}:\n" + "{");
                PrintObjectProperties(propertyValue);
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

        private static void PrintMainMenu() =>
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

        private static string GetValidInput(Action printOptions, Func<string, bool> verifyOption)
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