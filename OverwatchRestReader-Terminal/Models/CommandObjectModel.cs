/* Created by Rhese Soemo */
/* For my Overwatch Rest Reader Project */
/* First Comitted on 2/10/2021 */
/* This is my own work */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverwatchRestReader_Terminal.Menus
{
    /// <summary>
    /// An interface that templates an object to store commands and their executions
    /// </summary>
    internal interface CommandObjectModel
    {
        /// <summary>
        /// A list that stores the aliases or triggers for the command
        /// </summary>
        public List<String> CommandRootAliases { get; set; }

        /// <summary>
        /// WIP, unsure if this will be kept
        /// </summary>
        public List<CommandObjectModel> ChildCommands { get; set; }

        /// <summary>
        /// Runs the execution of the command
        /// </summary>
        /// <param name="programInstance">The instance of the program to interact with</param>
        public void Execution(ORRT_Main programInstance) { }

        /// <summary>
        /// Gets the alias list for a possible match
        /// </summary>
        /// <param name="possibleAlias">The possible aplias to check for</param>
        /// <returns>Returns whether the alias is in the list</returns>
        public Boolean ContainsAlias(String possibleAlias);
    }
}
