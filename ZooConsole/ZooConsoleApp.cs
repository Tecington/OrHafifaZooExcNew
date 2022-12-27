using System.Reflection;
using Zoo;
using Zoo.Attributes;
using Zoo.Models.Animals;
using ZooConsole.Data;
using ZooConsole.Enums;
using ZooConsole.IO;
using ZooConsole.Properties;
using ZooConsole.Exceptions;
using Logger.Loggers;

namespace ZooConsole
{
    internal class ZooConsoleApp
    {
        private Dictionary<MenuOptions, Action> MenuDictionary { get; set; }
        private Dictionary<Type, Action<Type, PropertyInfo, object>> CreatePrimitiveDictionary { get; set; }
        private ZooManager ZooManager { get; }
        private OrsLogger Logger { get; }

        internal ZooConsoleApp()
        {
            InitializeDictionarys();

            ZooManager = new ZooManager();
            Logger = new OrsLogger();
        }

        private void InitializeDictionarys()
        {
            MenuDictionary = new Dictionary<MenuOptions, Action>
            {
                { MenuOptions.ViewAll, ViewAll },
                { MenuOptions.Create, Create },
                { MenuOptions.Edit, Edit },
                { MenuOptions.SaveZoo, SaveZoo },
                { MenuOptions.Exit, Exit }
            };

            CreatePrimitiveDictionary = new Dictionary<Type, Action<Type, PropertyInfo, object>>
            {
                { typeof(string), SetStringProperty },
                { typeof(int), SetIntProperty },
                { typeof(bool), SetBoolProperty }
            };
        }

        internal void Start()
        {
            ConsoleIo.Write(Resources.GreetUserMessage);

            var menuOption = (MenuOptions)ConsoleIo.GetEnumProperty(typeof(MenuOptions));

            while (menuOption != MenuOptions.Exit)
            {
                TryExecuteMenuOption(menuOption);

                menuOption = (MenuOptions)ConsoleIo.GetEnumProperty(typeof(MenuOptions));
            }

            Logger.Log(LoggerResources.ExitLogMessage);
        }

        private void TryExecuteMenuOption(MenuOptions menuOption)
        {
            try
            {
                MenuDictionary[menuOption].Invoke();
            } catch (Exception exception)
            {
                ConsoleIo.Write(Resources.ExceptionCaughtUserMessage);
                Logger.Log(string.Format(LoggerResources.ExceptionCaughtLogMessage, 
                    exception.GetType(), exception.StackTrace));
            }
        }

        private void ViewAll()
        {
            Logger.Log(LoggerResources.ViewAllLogMessage);

            if (OrsZoo.Animals.Count == 0)
            {
                ConsoleIo.Write(Resources.ZooEmptyUserMessage);
            }
            else
            {
                OrsZoo.Animals.ForEach(animal =>
                {
                    ConsoleIo.PrintObjectProperties(animal, 
                        $"{animal.Name} - {animal.Type}:");
                    ConsoleIo.Write();
                });
            }
        }

        private void Create()
        {
            Logger.Log(LoggerResources.CreateLogMessage);

            var animalTypes = GetSerializableAnimalTypes();

            var typesStrings = animalTypes.Select(type => type.Name).ToList();

            var animalType = animalTypes[ConsoleIo.GetIndexFromList(typesStrings,
                Resources.SelectAnimalTypeUserMessage)];

            var newAnimal = (Animal)CreateObject(animalType);

            OrsZoo.Animals.Add(newAnimal);
        }

        private List<Type> GetSerializableAnimalTypes()
        {
            return typeof(Animal).Assembly.GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract
                && type.IsSubclassOf(typeof(Animal))
                && !type.IsDefined(typeof(UnSerializableAttribute))).ToList();
        }

        private void Edit()
        {
            Logger.Log(LoggerResources.EditLogMessage);

            var animalsStrings = OrsZoo.Animals.Select(animal =>
                $"{animal.Name} - {animal.Type}").ToList();

            var chosenAnimal = OrsZoo.Animals[ConsoleIo.GetIndexFromList(animalsStrings, 
                Resources.SelectAnimalToEditUserMessage)];

            var editAnimalTitle = $"{Resources.ChoosePropertyUserMessage}" +
                $"{Environment.NewLine}{chosenAnimal.Name} - {chosenAnimal.Type}:";

            var chosenProperty = ConsoleIo.GetPropertyToEdit(chosenAnimal, editAnimalTitle);
            
            object objectToEdit = chosenAnimal;

            while (Validation.IsComplexObject(chosenProperty.GetValue(objectToEdit)))
            {
                objectToEdit = chosenProperty.GetValue(objectToEdit);

                chosenProperty = objectToEdit is Animal
                    ? ConsoleIo.GetPropertyToEdit(objectToEdit, editAnimalTitle)
                    : ConsoleIo.GetPropertyToEdit(objectToEdit, 
                        $"{Resources.ChoosePropertyUserMessage}" +
                        $"{Environment.NewLine}{objectToEdit.GetType().Name}:");
            }

            CreateProperty(chosenProperty, objectToEdit);
        }

        private void SaveZoo()
        {
            Logger.Log(LoggerResources.SaveLogMessage);

            ZooManager.SaveZoo(OrsZoo.Animals);
        }

        private void Exit()
        {
            Logger.Log(LoggerResources.ExitLogMessage);
        }

        private object CreateObject(Type objectType)
        {
            var newObject = Activator.CreateInstance(objectType);

            objectType.GetProperties().Where(property => 
                property.GetCustomAttribute(typeof(HidePrintAttribute)) is null)
                    .ToList().ForEach(propertyInfo => CreateProperty(propertyInfo, newObject));

            return newObject;
        }

        private void CreateProperty(PropertyInfo propertyInfo, object obj)
        {
            var propertyType = propertyInfo.PropertyType;

            if (CreatePrimitiveDictionary.ContainsKey(propertyType))
            {
                CreatePrimitiveDictionary[propertyType]
                    .Invoke(propertyType, propertyInfo, obj);
            }
            else if (propertyType.IsEnum)
            {
                SetEnumProperty(propertyType, propertyInfo, obj);
            } 
            else
            {
                throw new UnhandledPropertyTypeException();
            }
        }

        private void SetEnumProperty(Type propertyType,
            PropertyInfo propertyInfo, object newObject)
        {
            propertyInfo.SetValue(newObject, Enum.ToObject(propertyType, 
                ConsoleIo.GetEnumProperty(propertyType)));
        }

        private void SetStringProperty(Type propertyType,
            PropertyInfo propertyInfo, object newObject)
        {
            string stringPropertyValue;

            if (propertyInfo.Name.Equals("Name"))
            {
                stringPropertyValue = ConsoleIo.GetStringProperty(propertyInfo, 
                    (string str) => Validation.IsLettersOnly(str) && 
                    Validation.IsNameAvailable(str, OrsZoo.Animals));
            }
            else
            {
                stringPropertyValue = ConsoleIo.GetStringProperty(propertyInfo, Validation.IsLettersOnly); ;
            }

            propertyInfo.SetValue(newObject, stringPropertyValue);
        }

        private void SetIntProperty(Type propertyType,
            PropertyInfo propertyInfo, object newObject)
        {
            propertyInfo.SetValue(newObject, ConsoleIo.GetIntProperty(propertyInfo));
        }

        private void SetBoolProperty(Type propertyType,
            PropertyInfo propertyInfo, object newObject)
        {
            propertyInfo.SetValue(newObject, ConsoleIo.GetBoolProperty(propertyInfo));
        }
    }
}