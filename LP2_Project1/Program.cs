using System;
using System.Collections.Generic;

namespace LP2_Project1
{
    /// <summary>
    /// Main class initiated at the beginning of the program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Static void which is the first methods that is used. It is used 
        /// firstly to call the class ReadFile to extract the file data.
        /// Then, it launches the the class to have the properties of the args.
        /// After that, we call another class which will filter the data as
        /// the user wants to and then show it to the user via the command
        /// console.
        /// </summary>
        /// <param name="args">The arguments of the user, used as the method to 
        /// know the file and options of the reacher which the user 
        /// wants.</param>
        static void Main(string[] args)
        {

            List<Planets> planets;
            List<Stars> stars;

            // Takes the propreties from args so later on you can filter them
            Propreties propreties = Propreties.ReadArgs(args);

            // Extract data from the file the user wants
            ReadFile file = new ReadFile("pl_est.csv");

            planets = file.planets;
            stars = file.stars;

            Search search = new Search(planets, propreties);

            
            
        }
    }
}
