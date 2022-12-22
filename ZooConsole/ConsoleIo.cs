using System.Reflection;
using Zoo.Models.AnimalFamilies;
using ZooConsole.Enums;
using ZooConsole.Properties;

namespace ZooConsole
{
    internal static class ConsoleIo
    {
        internal static void PrintZoo(List<Animal> animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine($"{animal.Name} - {animal.Type}:");
                PrintObjectProperties(animal);
                Console.WriteLine();
            }
        }

        internal static MenuOptions GetMenuOption()
        {
            ShowMainMenu();

            var menuOption = Console.ReadLine();

            while (!VerifyMenuOption(menuOption))
            {
                Console.WriteLine(Resources.InvalidOptionUserMessage);
                ShowMainMenu();

                menuOption = Console.ReadLine();
            }

            return (MenuOptions)int.Parse(menuOption);
        }

        private static void ShowMainMenu()
        {
            Console.WriteLine(@$"{string.Format(Resources.MainMenu,
                (int)MenuOptions.ViewAll,
                (int)MenuOptions.Create,
                (int)MenuOptions.Edit,
                (int)MenuOptions.SaveZoo,
                (int)MenuOptions.Exit)}");
        }

        private static bool VerifyMenuOption(string option)
        {
            return int.TryParse(option, out var optionIntValue)
                   && Enum.IsDefined(typeof(MenuOptions), optionIntValue);
        }

        internal static Animal GetAnimalToEdit(List<Animal> animals)
        {
            PrintAnimalEditList(animals);

            var animalIndex = Console.ReadLine();

            while (!VerifyIndexInRange(animalIndex, animals.Count))
            {
                Console.WriteLine(Resources.InvalidOptionUserMessage);
                PrintAnimalEditList(animals);

                animalIndex = Console.ReadLine();
            }

            return animals[int.Parse(animalIndex) - 1];
        }

        private static void PrintAnimalEditList(List<Animal> animals)
        {
            Console.WriteLine(Resources.SelectAnimalToEditUserMessage);

            for (var i = 0; i < animals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {animals[i].Name} - {animals[i].Type}");
            }
        }

        internal static PropertyInfo GetAnimalPropertyToEdit(Animal animal)
        {
            var propertyInfos = animal.GetType().GetProperties();

            PrintAnimalWithProperties(animal);

            var propertyIndex = Console.ReadLine();

            while (!VerifyIndexInRange(propertyIndex, propertyInfos.Length))
            {
                Console.WriteLine(Resources.InvalidOptionUserMessage);
                PrintAnimalWithProperties(animal);

                propertyIndex = Console.ReadLine();
            }

            return propertyInfos[int.Parse(propertyIndex) - 1];
        }

        private static void PrintAnimalWithProperties(Animal animal)
        {
            Console.WriteLine($"{Resources.ChoosePropertyUserMessage}{animal.Name} - {animal.Type}:");
            PrintObjectProperties(animal);
        }

        internal static void PrintObjectProperties(object obj)
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

            if (IsInnerObject(propValue))
            {
                Console.WriteLine($"{index + 1}. {propertyInfo.Name}:\n" + "{");
                PrintObjectProperties(propValue);
                Console.WriteLine("}");
            }
            else
            {
                Console.WriteLine($"{index + 1}. {propertyInfo.Name} - {propValue}");
            }
        }

        internal static bool IsInnerObject(object obj) => 
            !obj.GetType().IsPrimitive && obj is not string && !obj.GetType().IsEnum;

        private static bool VerifyIndexInRange(string option, int length)
        {
            return int.TryParse(option, out var optionIntValue)
                   && optionIntValue > 0 && optionIntValue <= length;
        }
    }
}