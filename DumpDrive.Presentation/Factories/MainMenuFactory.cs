﻿using DumpDrive.Domain.Abstractions;
using DumpDrive.Domain.Actions;

namespace DumpDrive.Presentation.Factories
{
    public class MainMenuFactory
    {
        public static IList<IAction> Create()
        {
            var actions = new List<IAction>
            {
                new MyDiskAction(),
                new SharedWithMeAction(),
                new ProfileAction(),
                new ExitMenuAction()
            };

            actions.SetActionIndexes();
            return actions;
        }
    }
}
