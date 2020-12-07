using System.Collections.Generic;

namespace LP2_Project1
{
    /// <summary>
    /// Main class initiated at the beginning of the program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Static void which is the first methods that is used. It creats the 
        /// enumerables to contain the date of the planets and starts. Then, it 
        /// calls the class Propreties to know what type of searchthe user 
        /// wants.
        /// Then it extracts the file data with Read File and adds to the
        /// Enums.
        /// After that, it do the search depending of the enums and the
        /// propreties the user wants.
        /// In the end, it shows in a table the results of the search.
        /// </summary>
        /// <param name="args">The arguments of the user, used as the method to 
        /// know the file and options of the reacher which the user 
        /// wants.</param>
        static void Main(string[] args)
        {
            // Enumerables to keep the stars and planets for the search
            IEnumerable<Stars> stars;
            IEnumerable<Planets> planets;

            // Takes the propreties from args so later on you can filter them
            Propreties propreties = Propreties.ReadArgs(args);

            // Extract data from the file the user wants
            ReadFile file = new ReadFile(propreties.File);

            // Puts the date in the Enumerables
            planets = file.p;
            stars = file.s;

            // Do the search the defined propreties and the list of stars and/or
            // planets of the file of the user
            Search search = new Search(planets, stars, propreties);

            // Actualizes the Enumerables with the search
            planets = search.planets;
            stars = search.stars;

            // Shows the what the user searched
            Interface UI = new Interface(planets, stars, propreties);
        }
    }
}
