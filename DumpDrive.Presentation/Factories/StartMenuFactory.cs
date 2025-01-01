using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Abstractions;
using DumpDrive.Presentation.Actions;
using DumpDrive.Presentation.Extensions;

namespace DumpDrive.Presentation.Factories
{
    public class StartMenuFactory
    {
        private readonly UserRepository _userRepository;
        private readonly MainMenuFactory _mainMenuFactory;

        public StartMenuFactory(UserRepository userRepository, MainMenuFactory mainMenuFactory)
        {
            _userRepository = userRepository;
            _mainMenuFactory = mainMenuFactory;
        }

        public void DisplayStartMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to DumpDrive!\n");

            var actions = Create();

            actions.PrintActionsAndOpen();
        }

        public IList<IAction> Create()
        {
            var login = new LoginAction(_mainMenuFactory, _userRepository);
            var register = new RegisterAction(_mainMenuFactory);

            var actions = new List<IAction>
                {
                    login,
                    register,
                    new ExitMenuAction()
                };

            actions.SetActionIndexes();
            return actions;
        }
    }
}
