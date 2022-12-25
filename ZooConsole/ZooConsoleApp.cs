using Zoo;
using ZooConsole.Enums;

namespace ZooConsole
{
    internal class ZooConsoleApp
    {
        private Dictionary<MenuOptions, Action> Dictionary { get; }
        private ZooManager ZooManager { get; }

        internal ZooConsoleApp()
        {
            Dictionary = new Dictionary<MenuOptions, Action>
            {
                { MenuOptions.ViewAll, ViewAll },
                { MenuOptions.Create, Create },
                { MenuOptions.Edit, Edit },
                { MenuOptions.SaveZoo, SaveZoo }
            };

            ZooManager = new ZooManager();
        }

        internal void Start()
        {
            var menuOption = ConsoleIo.GetMenuOption();

            while (menuOption != MenuOptions.Exit)
            {
                Dictionary[menuOption].Invoke();

                menuOption = ConsoleIo.GetMenuOption();
            }
        }

        private void ViewAll()
        {
            ConsoleIo.PrintZoo(OrsZoo.Animals);
        }

        private void Create()
        {
            var animalType = ConsoleIo.GetAnimalTypeToCreate(AnimalTypes.Types);
        }

        private void Edit()
        {

        }

        private void SaveZoo()
        {
            ZooManager.SaveZoo(OrsZoo.Animals);
        }
    }
}