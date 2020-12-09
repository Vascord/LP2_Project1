using System;
using System.Collections.Generic;

namespace LP2_Project1
{
    /// <summary>
    /// Class whose objective is to print out the results of the search
    /// determined by the user. It can be a normal search, a specific search,
    /// a csv format search or the help command to print out the guideline
    /// to do a search
    /// </summary>
    public class Interface
    {
        private IEnumerable<Planets> planets;
        private IEnumerable<Stars> stars;
        private Propreties propreties;

        /// <summary>
        /// Public constructor to receive the stars and planets enumerables
        /// and print out the search the user wants
        /// </summary>
        /// <param name="planets">Enumerable with the planets</param>
        /// <param name="stars">Enumerable with the stars</param>
        /// <param name="propreties">Propreties of the search</param>
        public Interface(IEnumerable<Planets> planets, IEnumerable<Stars> stars,
        Propreties propreties)
        {
            // Variables
            this.planets = planets;
            this.stars = stars;
            this.propreties = propreties;

            // Sees if csv is requested
            if(propreties.CVS == "on")
                // If it is, then it will show the desired search of the user
                // in format csv that can be printed out in a file if wanted
                if (propreties.Type == "planet")
                    PlanetCVSInterface();
                else
                    StarCVSInterface();
            // If csv is not requested, then it will show the search in a simple
            // table
            else
            {
                if (propreties.Type == "planet")
                    PlanetInterface();
                else
                    StarInterface();
            }
        }

        /// <summary>
        /// Public constructor to print out the possible inputs with
        /// HelpInterface if -- help was called
        /// </summary>
        public Interface()
        {
            HelpInterface();
        }

        /// <summary>
        /// Private Method to show the data of the search of planets in a table
        /// </summary>
        private void PlanetInterface()
        {
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20} {6,-20} {7,-20}", 
                "Planet Name", "Star Name", "Disc. Method", "Disc.Year", "Orbital", "Radius"
                , "Mass", "Eq. Temp.");
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20} {6,-20} {7,-20}", 
                "", "", "", "", "Period (days)", "(vs Earth)"
                , "(vs Earth)", "(Kelvin)");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------");
            foreach(Planets l in planets)
            {
                // For each value of the planet, it checks if it is null or not.
                // If it is, then it shows N/A, else it shows the value that
                // can be shorten by the method Truncate if necessary.
                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20} {6,-20} {7,-20}",
                String.IsNullOrEmpty(l.pl_name)? "N/A" : Truncate(l.pl_name),
                String.IsNullOrEmpty(l.hostname)? "N/A" : Truncate(l.hostname),
                String.IsNullOrEmpty(l.discoverymethod)? "N/A" : 
                    Truncate(l.discoverymethod),
                String.IsNullOrEmpty(l.disc_year)? "N/A" : 
                    Truncate(l.disc_year),
                String.IsNullOrEmpty(l.pl_orbper)? "N/A" : 
                    Truncate(l.pl_orbper),
                String.IsNullOrEmpty(l.pl_rade)? "N/A" : Truncate(l.pl_rade),
                String.IsNullOrEmpty(l.pl_masse)? "N/A" : Truncate(l.pl_masse),
                String.IsNullOrEmpty(l.pl_eqt)? "N/A" : Truncate(l.pl_eqt));
            }
        }

        /// <summary>
        /// Private Method to show the data of the search of stars in a table
        /// </summary>
        private void StarInterface()
        {
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20} {6,-20} {7,-20} {8,-20}", 
                "Star Name", "Star Temp.", "Radius", "Mass", "Age", "Rot. Vel."
                , "Rot.  Pre.", "Distance", "Numb. Planets");
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20} {6,-20} {7,-20} {8,-20}", 
                "", "Kelvins", "(vs Sun)", "(vs Sun)", "Giga-years", "km/s"
                , "Period (days)", "Parsecs", "");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            foreach(Stars l in stars)
            {
                // For each value of the star, it checks if it is null or not.
                // If it is, then it shows N/A, else it shows the value that
                // can be shorten by the method Truncate if necessary.
                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20} {6,-20} {7,-20} {8,-20}",
                String.IsNullOrEmpty(l.st_name)? "N/A" : Truncate(l.st_name), 
                String.IsNullOrEmpty(l.st_teff)? "N/A" : Truncate(l.st_teff),
                String.IsNullOrEmpty(l.st_rad)? "N/A" : Truncate(l.st_rad), 
                String.IsNullOrEmpty(l.st_mass)? "N/A" : Truncate(l.st_mass), 
                String.IsNullOrEmpty(l.st_age)? "N/A" : Truncate(l.st_age), 
                String.IsNullOrEmpty(l.st_vsin)? "N/A" : Truncate(l.st_vsin),
                String.IsNullOrEmpty(l.st_rotp)? "N/A" : Truncate(l.st_rotp), 
                String.IsNullOrEmpty(l.sy_dist)? "N/A" : Truncate(l.sy_dist), 
                String.IsNullOrEmpty(l.st_pls)? "N/A" : Truncate(l.st_pls));
            }
        }

        /// <summary>
        /// Private Method to show the data of the search of planets in
        /// csv format
        /// </summary>
        private void PlanetCVSInterface()
        {
            Console.WriteLine();
            Console.WriteLine("pl_name,hostname,discoverymethod,disc_year,pl_orbper,pl_rade,pl_masse,pl_eqt");
            foreach(Planets l in planets)
            {
                Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7}",
                l.pl_name, l.hostname, l.discoverymethod, l.disc_year, 
                l.pl_orbper, l.pl_rade, l.pl_masse, l.pl_eqt);
            }
        }

        /// <summary>
        /// Private Method to show the data of the search of stars in
        /// csv format
        /// </summary>
        private void StarCVSInterface()
        {
            Console.WriteLine();
            Console.WriteLine("st_name,st_teff,st_rad,st_mass,st_age,st_vsin,st_rotp,sy_dist,st_pls");
            foreach(Stars l in stars)
            {
                Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                l.st_name, l.st_teff, l.st_rad, l.st_mass, l.st_age, l.st_vsin,
                l.st_rotp, l.sy_dist, l.st_pls);
            }
        }

        /// <summary>
        /// Private Method to show the inputs to the user
        /// </summary>
        private void HelpInterface()
        {
            Console.WriteLine("\n\nHow to search planets :");
            Console.WriteLine("First argument : -- search-planets");
            Console.WriteLine("Essential argument : --file name_of_file");

            Console.WriteLine("\nHow to search stars :");
            Console.WriteLine("First argument : -- search-stars");
            Console.WriteLine("Essential argument : --file name_of_file");

            Console.Write("\nSearch arguments :");
            Console.Write("--discmethod name_of_method_applied_to_disc  |  ");
            Console.WriteLine("--hostname stars_with_that_name  |  --eqt-min/--eqt-max equilibrium_temperature_value_of_a_planet  |");
            Console.WriteLine("--pl_name planets_with_that_name  |  --masse-min/--masse-max mass_value_of_planets  |  --rade-min/--rade-max radius_value_of_planets  |");
            Console.WriteLine("--orbper-min/--orbper-max orbital_period_value_of_planets  |  --discyear-min/--discyear-max discovery_year_value_of_planets  |");
            Console.WriteLine("--teff-min/--teff-max effective_temperature_value_of_stars  |  --rad-min/rad-max radius_value_of_stars  |");
            Console.WriteLine("--mass-min/--mass-max mass_value_of_stars  |  --vsin-min/--vsin-max rotation_velocity_of_stars  |");
            Console.WriteLine("--rotp-min/--rotp-max value_of_star_rot  |  --dist-min/--dist-max distance_between_our_Sun_and_the_stars_value  |");
            Console.WriteLine("--age-min/--age-max age_value_of_stars  |  --pls-min/--pls-max number_of_planets_value_of_stars");

            Console.WriteLine("\nHow to search specific planet :");
            Console.WriteLine("First argument : -- planet-info");
            Console.WriteLine("Essential argument : --file name_of_file");
            Console.WriteLine("Search arguments : --pl_name name_of_planet");

            Console.WriteLine("\nHow to search specific star :");
            Console.WriteLine("First argument : -- star-info");
            Console.WriteLine("Essential argument : --file name_of_file");
            Console.WriteLine("Search arguments : --st_name name_of_star");

            Console.WriteLine("\nCSV argument : --csv on (to show search in csv)");
            Console.WriteLine("Order arguments : --dr_order value_or_name_to_decreasing_order |  --cr_order value_or_name_to_increasing_order");
            Console.Write("Names for ordering for planets : pl_name | hostname | ");
            Console.WriteLine("discoverymethod | disc_year | pl_orbper | pl_rade | pl_masse | pl_eqt");
            Console.Write("Names for ordering for stars : hostname | st_teff | ");
            Console.WriteLine("st_rad | st_mass | st_age | st_vsin | st_rotp | sy_dist | st_pls");
        }

        /// <summary>
        /// Private Method which substrings a string if it's too long 
        /// (+20 characters)
        /// </summary>
        /// <param name="s">String which will, or not, be reduced</param>
        /// <return> The now shorthen, or not, string </return>
        private string Truncate(string s)
        {
            // Sees if the string is above 20 characters. If it is, then it's
            // shorthen. Else, it just returns the string normally.
            s = s.Length <= 20? s : s.Substring(0, 17) + "...";
            return s;
        }
    }
}