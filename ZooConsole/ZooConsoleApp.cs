using System.Reflection;
using Zoo;
using Zoo.Models.AnimalFamilies;
using Zoo.Models.CustomAttributes;
using ZooConsole.Data;
using ZooConsole.Enums;
using ZooConsole.Properties;

namespace ZooConsole
{
    internal class ZooConsoleApp
    {
        private Dictionary<MenuOptions, Action> MenuDictionary { get; }
        private Dictionary<Type, Action<Type, PropertyInfo, object>> CreatePropertyDictionary { get; }
        private ZooManager ZooManager { get; }

        internal ZooConsoleApp()
        {
            MenuDictionary = new Dictionary<MenuOptions, Action>
            {
                { MenuOptions.ViewAll, ViewAll },
                { MenuOptions.Create, Create },
                { MenuOptions.Edit, Edit },
                { MenuOptions.SaveZoo, SaveZoo }
            };

            CreatePropertyDictionary = new Dictionary<Type, Action<Type, PropertyInfo, object>>
            {
                {typeof(string), SetStringProperty },
                {typeof(int), SetIntProperty },
                {typeof(bool), SetBoolProperty }
            };

            ZooManager = new ZooManager();
        }

        internal void Start()
        {
            var menuOption = ConsoleIo.GetMenuOption();

            while (menuOption != MenuOptions.Exit)
            {
                TryExecuteMenuOption(menuOption);

                menuOption = ConsoleIo.GetMenuOption();
            }
        }

        private void TryExecuteMenuOption(MenuOptions menuOption)
        {
            try
            {
                MenuDictionary[menuOption].Invoke();
            } catch (Exception)
            {
                ConsoleIo.Write(Resources.ExceptionCaughtUserMessage);
            }
        }

        private void ViewAll()
        {
            ConsoleIo.PrintZoo(OrsZoo.Animals);
        }

        private void Create()
        {
            var animalTypes = typeof(Animal).Assembly.GetTypes()
                .Where(type => type.IsDefined(typeof(AnimalAttribute)) 
                && !type.IsDefined(typeof(UnSerializableAttribute)));

            var animalType = ConsoleIo.GetAnimalTypeToCreate(animalTypes.ToList());
            
            var newAnimal = CreateObject(animalType);

            OrsZoo.Animals.Add((Animal)newAnimal);
        }

        private void Edit()
        {
            var animal = ConsoleIo.GetAnimalToEdit(OrsZoo.Animals);
            var property = ConsoleIo.GetPropertyToEdit(animal);

            CreateProperty(property, animal);
        }

        private void SaveZoo()
        {
            ZooManager.SaveZoo(OrsZoo.Animals);
        }

        private object CreateObject(Type objectType)
        {
            var newObject = Activator.CreateInstance(objectType);
            var objectProperties = objectType.GetProperties()
                .Where(property => !property.Name.Equals("Type"));

            foreach (var propertyInfo in objectProperties)
            {
                CreateProperty(propertyInfo, newObject);
            }

            return newObject;
        }

        private void CreateProperty(PropertyInfo propertyInfo, object obj)
        {
            var propertyType = propertyInfo.PropertyType;

            if (CreatePropertyDictionary.ContainsKey(propertyType))
            {
                CreatePropertyDictionary[propertyType]
                    .Invoke(propertyType, propertyInfo, obj);
            }
            else if (propertyType.IsEnum)
            {
                SetEnumProperty(propertyType, propertyInfo, obj);
            }
            else
            {
                SetObjectProperty(propertyType, propertyInfo, obj);
            }
        }

        private void SetEnumProperty(Type propertyType,
            PropertyInfo propertyInfo, object newObject)
        {
            var enumValue = ConsoleIo.GetEnumProperty(propertyType);

            propertyInfo.SetValue(newObject, Enum.ToObject(propertyType, enumValue));
        }

        private void SetStringProperty(Type propertyType,
            PropertyInfo propertyInfo, object newObject)
        {
            string name;

            if (propertyInfo.Name.Equals("Name"))
            {
                name = ConsoleIo.GetNameProperty(propertyInfo, OrsZoo.Animals);
            }
            else
            {
                name = ConsoleIo.GetStringProperty(propertyInfo);
            }

            propertyInfo.SetValue(newObject, name);
        }

        private void SetIntProperty(Type propertyType,
            PropertyInfo propertyInfo, object newObject)
        {
            var value = ConsoleIo.GetIntProperty(propertyInfo);

            propertyInfo.SetValue(newObject, value);
        }

        private void SetBoolProperty(Type propertyType,
            PropertyInfo propertyInfo, object newObject)
        {
            var value = ConsoleIo.GetBoolProperty(propertyInfo);

            propertyInfo.SetValue(newObject, value);
        }

        private void SetObjectProperty(Type propertyType,
            PropertyInfo propertyInfo, object newObject)
        {
            var objectProperty = CreateObject(propertyInfo.PropertyType);

            propertyInfo.SetValue(newObject, objectProperty);
        }
    }
}