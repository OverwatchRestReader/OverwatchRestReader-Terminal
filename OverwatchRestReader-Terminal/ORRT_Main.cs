/* Created by Rhese Soemo */
/* For my Overwatch Rest Reader Project */
/* First Comitted on 2/10/2021 */
/* This is my own work */

using OverwatchRestReader_Library;
using System;
using OverwatchRestReader_Terminal.Menus;
using OverwatchRestReader_Terminal.Objects.Commands;

namespace OverwatchRestReader_Terminal
{
    /// <summary>
    /// The entry point for the main program
    /// </summary>
    internal class ORRT_Main
    {
        /* =========================== */
        /* ===== CLASS VARIABLES ===== */
        /* =========================== */
        /// <summary>
        /// Stores the ORR Library for easy access for the rest of the program
        /// </summary>
        private static LibraryMain LibraryInstance;

        /// <summary>
        /// Stores the current list of accessible commands
        /// </summary>
        private static List<CommandObjectModel> CurrentCommands = new List<CommandObjectModel>();

        /// <summary>
        /// Stores the current state of debug mode
        /// </summary>
        private static Boolean DebugMode { get; set; }

        /// <summary>
        /// Stores whether to keep ORR Terminal running
        /// </summary>
        private static Boolean KeepMainProgramRunning = true;


        /* ============================= */
        /* ===== GETTERS & SETTERS ===== */
        /* ============================= */
        /// <summary>
        /// Gets LibraryInstance variable
        /// </summary>
        /// <returns>Returns Current State of LibraryInstance</returns>
        public LibraryMain getLibraryInstance() { return LibraryInstance; }

        /// <summary>
        /// Gets KeepMainProgramRunning variable
        /// </summary>
        /// <returns>Returns Current State of KeepMainProgramRunning</returns>
        public Boolean getKeepMainProgramRunning() { return KeepMainProgramRunning; }

        /// <summary>
        /// Sets the KeepMainProgramRunning variable
        /// </summary>
        /// <param name="newstatus">The new status of KeepMainProgramRunning</param>
        public void setKeepMainProgramRunning(Boolean newstatus) { KeepMainProgramRunning = newstatus; }

        /* ============================== */
        /* ===== MAIN DRIVER METHOD ===== */
        /* ============================== */
        /// <summary>
        /// The driver method for the ORR Terminal
        /// </summary>
        /// <param name="args">Any parameters passed into the method</param>
        static void Main(string[] args)
        {
            StartUp();  // A method that does the heavy lifting in loading the application
            DebugMode = true;  // Setting the debug mode to true because this is a dev branch

            // Confirming to start up and giving command suggestion for list command
            Console.WriteLine("Welcome to ORR Terminal. Type list for list of commands.");

            /* === MAIN PROGRAM LOOP ===*/
            // A while loop that keeps the looping through the command structure
            while (KeepMainProgramRunning)
            {
                String UserInput = "null";  // Creating a user input variable for this iteration of the loop
                UserInput = Console.ReadLine();  // Reading user's input
                    MessageDebug("'" + UserInput + "'");  // Messaging debug if it is enabled

                // Creating a CommandObjectModel to store the command if found
                CommandObjectModel FoundCommand = new Command_BlankPlaceholder();  // Instiates a blank placeholder temporary command with no execution

                // Searching for command based off of user input in the list holding our current commands
                for (int timesLooped = 0; timesLooped < CurrentCommands.Count; timesLooped++)
                {
                    // If the command we are currently looking at has an alias that is the same as the user input
                    if (CurrentCommands[timesLooped].ContainsAlias(UserInput.ToLower()))  // User input is cleaned on this side
                    {
                        // Storing the command that was found
                        FoundCommand = CurrentCommands[timesLooped];
                    }
                }
                
                // Building a new instance of the main which is a duplicate because the main is always static
                ORRT_Main instance = new ORRT_Main();
                FoundCommand.Execution(instance);  // Excuting command and passing the instance forward
            }

            // Echoing exit confirmation
            Console.WriteLine("Shutting down Overwatch Rest Reader Terminal...");
            Environment.Exit(0);  // Sending exit command and shutting down the application
        }


        /* ========================== */
        /* ===== HELPER METHODS ===== */
        /* ========================== */
        /// <summary>
        /// Sends a debug message if debug is set to true
        /// </summary>
        /// <param name="Message">Message to be sent to debug</param>
        private static void MessageDebug(String Message)
        {
            // If DebugMode is true
            if (DebugMode)
            {
                // Sends debug message
                Console.WriteLine("DEBUG: " + Message);
            }
        }

        /// <summary>
        /// A helper method to assist in start up
        /// </summary>
        private static void StartUp()
        {
            // Output start
            Console.WriteLine("Loading Overwatch Rest Reader Terminal...");

            /* === LOADING ORR LIBRARY === */
            Console.WriteLine("-> Loading ORR Library [PARTIALLY IMPLEMENTED]");
            LibraryInstance = new LibraryMain();

            /* === LOADING PROGRAM DATA === */
            Console.WriteLine("-> Loading Program Data [PARTIALLY IMPLEMENTED]");
            CurrentCommands.Add(new Command_Exit());

            /* === LOADING USER DATA === */
            Console.WriteLine("-> Loading User Data [UNIMPLEMENTED]");

            /* === OUTPUTTING COMPLETION === */
            Console.WriteLine("-> Completed in 0ms [UNIMPLEMENTED]");
            Console.WriteLine("Everything is loaded, we are ready to go!\n");

            /* === COUNT DOWN TO NEXT STEP === */
            for (int timesLooped = 1; timesLooped > -1; timesLooped--)
            {
                // Update the last line to the latest information
                Console.Write("\rStarting Overwatch Rest Reader Terminal in " + timesLooped);
                System.Threading.Thread.Sleep(1000);  // Sleep for a second
            }
            Console.Clear();  // Clearing console

            /* === ELUA AGREEMENT ===*/
            // ASKI Art because pretty
            Console.WriteLine("  ____  _____  _____    _______                  _             _ ");
            Console.WriteLine(" / __ \\|  __ \\|  __ \\  |__   __|                (_)           | |");
            Console.WriteLine("| |  | | |__) | |__) |    | | ___ _ __ _ __ ___  _ _ __   __ _| |");
            Console.WriteLine("| |  | |  _  /|  _  /     | |/ _ | '__| '_ ` _ \\| | '_ \\ / _` | |");
            Console.WriteLine("| |__| | | \\ \\| | \\ \\     | |  __| |  | | | | | | | | | | (_| | |");
            Console.WriteLine(" \\____/|_|  \\_|_|  \\_\\    |_|\\___|_|  |_| |_| |_|_|_| |_|\\__,_|_|\n");
            
            // Welcoming user and telling user about Elua
            Console.WriteLine("Hello! Welcome to Overwatch Rest Reader Terminal! By downloading and/or using this software you are agreeing to our lisence and EULA available on our project repository.");
            Console.WriteLine("By continuing you are agreeing to these terms.\n");
            Console.WriteLine("Press enter to agree and continue...");

            // Waiting until key is pressed by user
            Console.ReadKey(true);

            Console.Clear();  // Clearing console
            // Set up is complete
        }
    }
}