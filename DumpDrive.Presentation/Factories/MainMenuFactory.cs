using DumpDrive.Data.Entities.Models;
using DumpDrive.Domain.Factories;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Abstractions;
using DumpDrive.Presentation.Actions;
using DumpDrive.Presentation.Extensions;
using DumpDrive.Presentation.Helpers;

namespace DumpDrive.Presentation.Factories
{
    public class MainMenuFactory
    {
        public IList<IAction> Create(User user)
        {
            var actions = new List<IAction>
            {
                new DriveActions(RepositoryFactory.Create<SharedItemRepository>() ,RepositoryFactory.Create<ItemRepository>(), new FolderContext(), RepositoryFactory.Create<CommentRepository>(),RepositoryFactory.Create<FolderRepository>(),RepositoryFactory.Create<FileRepository>(),new Stack<Folder?>(), RepositoryFactory.Create<UserRepository>(),user),
                new SharedItemsActions(RepositoryFactory.Create<FileRepository>(), RepositoryFactory.Create<ItemRepository>(), RepositoryFactory.Create<CommentRepository>(), RepositoryFactory.Create<UserRepository>(), RepositoryFactory.Create<SharedItemRepository>(), user),
                new ChangeProfileSettingsActions(user),
                new ExitMenuAction()
            };

            actions.SetActionIndexes();
            return actions;
        }
    }
}
