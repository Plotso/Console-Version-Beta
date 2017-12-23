﻿using System.Linq;

namespace DemolitionFalcons.App.Core
{
    using System;
    using System.Collections.Generic;
    using DemolitionFalcons.App.Interfaces;
    using DemolitionFalcons.Data.ExeptionsMessages;
    using DemolitionFalcons.Data.Support;

    public class CommandEngine<T> : ICommandEngine<T>
        where T : class
    {

        public T ExecuteCommand(List<string> args)
        {

            string cmdName = args[0];

            Type commandType = Type.GetType("DemolitionFalcons.App.Commands." + cmdName + "Command");

            if (commandType == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidCommandExceptionMessage);
            }
            // Create Instance

            var cmd = (T)Activator.CreateInstance(commandType);

            return cmd;
        }
    }
}
