using System.Reflection;
using System.Text.RegularExpressions;
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
            var isInputValid = (string option) =>
                Validation.IsValidEnumValue(option, typeof(MenuOptions));

            var menuOption = GetValidInput(PrintMainMenu, isInputValid);

            return (MenuOptions)int.Parse(menuOption);
        }

        internal static void PrintZoo(List<Animal> animals)
        {
            animals.ForEach(animal =>
            {
                Console.WriteLine($"{animal.Name} - {animal.Type}:");
                PrintObjectProperties(animal);
                Console.WriteLine();
            });
        }

        internal static Type GetAnimalTypeToCreate(List<Type> animalTypes)
        {
            var isInputValid = (string option) =>
                Validation.IsIntInRange(option, min: 1, max: animalTypes.Count);
            var printOptions = () => PrintAnimalTypes(animalTypes);

            var animalIndex = GetValidInput(printOptions, isInputValid);

            return animalTypes[int.Parse(animalIndex) - 1];
        }

        private static void PrintAnimalTypes(List<Type> types)
        {
            Console.WriteLine(Resources.SelectAnimalTypeToCreateMessage);

            for (int index = 0; index < types.Count; index++)
            {
                Console.WriteLine($"{index + 1} {types[index].Name}");
            }
        }

        internal static int GetEnumProperty(Type enumType)
        {
            var isInputValid = (string option) =>
                Validation.IsValidEnumValue(option, enumType);
            var printOptions = () =>
            {
                Console.WriteLine(string.Format
                    (Resources.GetPropertyUserMessage, enumType.Name));
                PrintEnumOptions(enumType);
            };

            var enumIndex = GetValidInput(printOptions, isInputValid);

            return int.Parse(enumIndex);
        }

        internal static int GetIntProperty(PropertyInfo propertyInfo)
        {
            var isInputValid = (string option) =>
                Validation.IsIntInRange(option, min: 0);
            var printOptions = () => Console.WriteLine(string.Format
                (Resources.GetPropertyUserMessage, propertyInfo.Name));

            var value = GetValidInput(printOptions, isInputValid);

            return int.Parse(value);
        }

        internal static bool GetBoolProperty(PropertyInfo propertyInfo)
        {
            var isInputValid = (string option) => Validation.IsIntInRange(option, 1, 2);
            var printOptions = () =>
            {
                Console.WriteLine(@$"{string.Format
                    (Resources.GetPropertyUserMessage, propertyInfo.Name)}" +
                    $"\n{Resources.BoolOptions}");
            };

            var value = GetValidInput(printOptions, isInputValid);

            return int.Parse(value) == 1;
        }

        internal static string GetNameProperty(PropertyInfo propertyInfo, List<Animal> animals)
        {
            var isInputValid = (string str) => Validation.IsValidString(str)
                && Validation.IsNameAvailable(str, animals);

            return GetStringProperty(propertyInfo, isInputValid);
        }

        internal static string GetStringProperty(PropertyInfo propertyInfo) =>
            GetStringProperty(propertyInfo, Validation.IsValidString);

        private static string GetStringProperty(PropertyInfo propertyInfo,
            Func<string, bool> isInputValid)
        {
            var printOptions = () => Console.WriteLine(string.Format
                (Resources.GetPropertyUserMessage, propertyInfo.Name));

            var str = GetValidInput(printOptions, isInputValid);

            return str;
        }

        internal static Animal GetAnimalToEdit(List<Animal> animals)
        {
            var isInputValid = (string option) =>
                Validation.IsIntInRange(option, min: 1, max: animals.Count);
            var printOptions = () => PrintAnimalToEditList(animals);

            var animalIndex = GetValidInput(printOptions, isInputValid);

            return animals[int.Parse(animalIndex) - 1];
        }

        internal static PropertyInfo GetPropertyToEdit(Animal animal)
        {
            var propertyInfosList = animal.GetType().GetProperties().Where(propertyInfo => !propertyInfo.Name.Equals("Type")).ToList();

            var isInputValid = (string option) =>
                Validation.IsIntInRange(option, min: 1, max: propertyInfosList.Count);
            var printOptions = () => PrintAnimalProperties(animal);

            var propertyIndex = GetValidInput(printOptions, isInputValid);

            return propertyInfosList[int.Parse(propertyIndex) - 1];
        }

        private static void PrintAnimalProperties(Animal animal)
        {
            Console.WriteLine($"{Resources.ChoosePropertyUserMessage}" +
                $"{animal.Name} - {animal.Type}:");

            PrintObjectProperties(animal);
        }

        private static void PrintObjectProperties(object obj)
        {  
            var propertyInfosList = obj.GetType().GetProperties()
                .Where(propertyInfo => !propertyInfo.Name.Equals("Type")).ToList();

            for (var i = 0; i < propertyInfosList.Count; i++)
            {
                PrintProperty(propertyInfosList[i], obj, i);
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

        private static void PrintAnimalToEditList(List<Animal> animals)
        {
            Console.WriteLine(Resources.SelectAnimalToEditUserMessage);

            for (var i = 0; i < animals.Count; i++)
            {
                PrintListRecord(i, animals[i].Name, animals[i].Type);
            }
        }

        private static void PrintListRecord(int index, string name, string value)
        {
            Console.WriteLine($"{index + 1}. {name} - {value}");
        }

        private static void PrintMainMenu()
        {
            Console.WriteLine(string.Format(Resources.MainMenu,
                (int)MenuOptions.ViewAll,
                (int)MenuOptions.Create,
                (int)MenuOptions.Edit,
                (int)MenuOptions.SaveZoo,
                (int)MenuOptions.Exit));
        }

        private static void PrintEnumOptions(Type enumType)
        {
            Console.WriteLine($"{enumType.Name}:");

            var names = enumType.GetEnumNames();

            for (int index = 0; index < names.Length; index++)
            {
                Console.WriteLine($"{index + 1}. {names[index]}");
            }
        }

        private static string GetValidInput(Action printOptions, Func<string, bool> IsInputValid)
        {
            printOptions();

            var option = Console.ReadLine();

            while (!IsInputValid(option))
            {
                Console.WriteLine(Resources.InvalidOptionUserMessage);
                printOptions();

                option = Console.ReadLine();
            }

            return option;
        }
    }
}