/* Created by Rhese Soemo */
/* For my Overwatch Rest Reader Project */
/* First Comitted on 2/10/2021 */
/* This is my own work */

using OverwatchRestReader_Terminal.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverwatchRestReader_Terminal.Objects.Commands
{
    /// <summary>
    /// A command object that ends the program
    /// </summary>
    internal class Command_Exit : CommandObjectModel
    {
        /// <summary>
        /// A list that stores the aliases or triggers for the command
        /// </summary>
        public List<string> CommandRootAliases { get; set; }

        /// <summary>
        /// WIP, unsure if this will be kept
        /// </summary>
        public List<CommandObjectModel> ChildCommands { get; set; }

        /// <summary>
        /// Runs the execution of the command
        /// </summary>
        /// <param name="programInstance">The instance of the program to interact with</param>
        public void Execution(ORRT_Main programInstance) 
        {
            programInstance.setKeepMainProgramRunning(false);
        }

        /// <summary>
        /// A public constructor for the command
        /// </summary>
        public Command_Exit()
        {
            CommandRootAliases = new List<string>();
            CommandRootAliases.Add("exit");
            CommandRootAliases.Add("quit");
            CommandRootAliases.Add("stop");
            CommandRootAliases.Add("end");
        }


        /// <summary>
        /// Gets the alias list for a possible match
        /// </summary>
        /// <param name="possibleAlias">The possible aplias to check for</param>
        /// <returns>Returns whether the alias is in the list</returns>
        public bool ContainsAlias(string possibleAlias)
        {
            return CommandRootAliases.Contains(possibleAlias.ToLower());
        }
    }
}
