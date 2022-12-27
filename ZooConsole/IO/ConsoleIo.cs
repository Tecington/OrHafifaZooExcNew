using System.Reflection;
using ZooConsole.Enums;
using ZooConsole.Properties;
using Zoo.Attributes;
using Zoo.Enums;

namespace ZooConsole.IO
{
    internal static class ConsoleIo
    {
        private static readonly Dictionary<Type, Action> PrintEnumDictioanry = new Dictionary<Type, Action>()
        {
            {typeof(MenuOptions), PrintMenuOptions },
            {typeof(Color), PrintColorOptions },
            {typeof(Gender), PrintGenderOptions },
            {typeof(SharkType), PrintSharkTypeOptions }
        };

        private static int tabCounter = 1;

        internal static void Write(string text = "")
        {
            Console.WriteLine(text);
        }

        internal static string Read()
        {
            var value = Console.ReadLine();
            Write();

            return value;
        }

        internal static void GreetUser()
        {
            Write(Resources.GreetUserMessage);
        }

        internal static MenuOptions GetMenuOption()
        {
            var isInputValid = (string option) =>
                Validation.IsValidEnumValue(option, typeof(MenuOptions));

            var menuOption = GetValidInput(PrintMenuOptions, isInputValid);

            return (MenuOptions)int.Parse(menuOption);
        }

        internal static void PrintList(List<string> list, string title)
        {
            Write(title);

            for (int index = 0; index < list.Count; index++)
            {
                Write($"{index + 1}. {list[index]}");
            }
        }

        internal static int GetEnumProperty(Type enumType)
        {
            var isInputValid = (string option) =>
                Validation.IsValidEnumValue(option, enumType);

            var printOptions = () =>
            {
                Write(string.Format(Resources.GetPropertyUserMessage, enumType.Name));
                PrintEnumDictioanry[enumType].Invoke();
            };

            var enumIndex = GetValidInput(printOptions, isInputValid);

            return int.Parse(enumIndex);
        }

        internal static int GetIntProperty(PropertyInfo propertyInfo)
        {
            var printOptions = () => Write(string.Format
                (Resources.GetPropertyUserMessage, propertyInfo.Name));

            var value = GetValidInput(printOptions, Validation.IsPositive);

            return int.Parse(value);
        }

        internal static bool GetBoolProperty(PropertyInfo propertyInfo)
        {
            var isInputValid = (string option) => Validation.IsIntInRange(option, 1, 2);

            var printOptions = () =>
            {
                Write(@$"{string.Format
                    (Resources.GetPropertyUserMessage, propertyInfo.Name)}" +
                    $"\n{Resources.BoolOptions}");
            };

            var value = GetValidInput(printOptions, isInputValid);

            return int.Parse(value) == 1;
        }

        internal static string GetStringProperty(PropertyInfo propertyInfo,
            Func<string, bool> isInputValid)
        {
            var printOptions = () => Write(string.Format
                (Resources.GetPropertyUserMessage, propertyInfo.Name));

            return GetValidInput(printOptions, isInputValid);
        }

        internal static int GetIndexFromList(List<string> list, string title)
        {
            var isInputValid = (string option) =>
                Validation.IsIndexInRange(option, list.Count);

            var printOptions = () => PrintList(list, title);

            var index = GetValidInput(printOptions, isInputValid);

            return int.Parse(index) - 1;
        }

        internal static PropertyInfo GetPropertyToEdit(object obj, string objTitle)
        {
            var propertyInfosList = obj.GetType().GetProperties()
                .Where(propertyInfo => propertyInfo.GetCustomAttribute(typeof(HidePrintAttribute)) is null).ToList();

            var isInputValid = (string option) =>
                Validation.IsIndexInRange(option, propertyInfosList.Count);

            var printOptions = () => PrintObjectProperties(obj, objTitle);

            var propertyIndex = int.Parse(GetValidInput(printOptions, isInputValid));

            return propertyInfosList[propertyIndex - 1];
        }

        internal static void PrintObjectProperties(object obj, string objTitle)
        {
            var propertyInfosList = obj.GetType().GetProperties()
                .Where(propertyInfo => propertyInfo
                    .GetCustomAttribute(typeof(HidePrintAttribute)) is null).ToList();

            Write($"{GetTabsAsString(tabCounter - 1)}{objTitle}");

            for (var index = 0; index < propertyInfosList.Count; index++)
            {
                PrintProperty(propertyInfosList[index], obj, index);
            }
        }

        private static void PrintProperty(PropertyInfo propertyInfo, object obj, int index)
        {
            var propertyValue = propertyInfo.GetValue(obj);

            if (!Validation.IsComplexObject(propertyValue))
            {
                Write($"{GetTabsAsString(tabCounter)}{index + 1}. {propertyInfo.Name} - {propertyValue}");
            }
            else
            {
                tabCounter++;
                PrintObjectProperties(propertyValue, $"{index + 1}. {propertyInfo.Name}:");
                tabCounter--;
            }
        }

        private static void PrintMenuOptions()
        {
            Write(string.Format(Resources.MainMenu,
                (int)MenuOptions.ViewAll,
                (int)MenuOptions.Create,
                (int)MenuOptions.Edit,
                (int)MenuOptions.SaveZoo,
                (int)MenuOptions.Exit));
        }

        private static void PrintGenderOptions()
        {
            Write(string.Format(Resources.GenderOptions,
                (int)Gender.Male,
                (int)Gender.Female));
        }

        private static void PrintColorOptions()
        {
            Write(string.Format(Resources.ColorOptions,
                (int)Color.Orange,
                (int)Color.Yellow,
                (int)Color.Blue,
                (int)Color.Red,
                (int)Color.Green));
        }

        private static void PrintSharkTypeOptions()
        {
            Write(string.Format(Resources.SharkTypeOptions,
                (int)SharkType.HammerHead,
                (int)SharkType.Loan,
                (int)SharkType.GreatWhite));
        }

        private static string GetValidInput(Action printOptions, Func<string, bool> IsInputValid)
        {
            printOptions();

            var option = Read();

            while (!IsInputValid(option))
            {
                Write(Resources.InvalidOptionUserMessage);
                printOptions();

                option = Read();
            }

            return option;
        }

        private static string GetTabsAsString(int tabsAmount) => new('\t', tabsAmount);
    }
}