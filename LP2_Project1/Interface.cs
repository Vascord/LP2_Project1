using System;
using System.Collections.Generic;

namespace LP2_Project1
{
    public class Interface
    {
        private IEnumerable<Planets> planets;
        private IEnumerable<Stars> stars;
        private Propreties propreties;

        public Interface(IEnumerable<Planets> planets, IEnumerable<Stars> stars, Propreties propreties)
        {
            this.planets = planets;
            this.stars = stars;
            this.propreties = propreties;

            if(propreties.CVS == "on")
                if (propreties.Type == "planet")
                    PlanetCVSInterface();
                else
                    StarCVSInterface();
            else
            {
                if (propreties.Type == "planet")
                    PlanetInterface();
                else
                    StarInterface();
            }
        }

        public Interface()
        {
            HelpInterface();
        }

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
                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20} {6,-20} {7,-20}",
                String.IsNullOrEmpty(l.pl_name)? "N/A" : Truncate(l.pl_name),
                String.IsNullOrEmpty(l.hostname)? "N/A" : Truncate(l.hostname),
                String.IsNullOrEmpty(l.discoverymethod)? "N/A" : Truncate(l.discoverymethod),
                String.IsNullOrEmpty(l.disc_year)? "N/A" : Truncate(l.disc_year),
                String.IsNullOrEmpty(l.pl_orbper)? "N/A" : Truncate(l.pl_orbper),
                String.IsNullOrEmpty(l.pl_rade)? "N/A" : Truncate(l.pl_rade),
                String.IsNullOrEmpty(l.pl_masse)? "N/A" : Truncate(l.pl_masse),
                String.IsNullOrEmpty(l.pl_eqt)? "N/A" : Truncate(l.pl_eqt));
            }
        }
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

        private void HelpInterface()
        {
            Console.WriteLine("\n\nHow to search planets :");
            Console.WriteLine("First argument : -- search_planets");
            Console.WriteLine("Essential argument : --file name_of_file");
            Console.Write("Search arguments :");
            Console.Write("--discmethod name_of_method_applied_to_disc  |  ");
            Console.WriteLine("--hostname name_of_star  |  --eqt-min/--eqt-max value_of_eqt  |  --pl_name planets_with_that_name  |  ");
            Console.Write("--masse-min/--masse-max value_of_mass  |  --rade-min/--rade-max value_of_rad  |  ");
            Console.WriteLine("--orbper-min/--orbper-max value_of_orbper  |  --discyear-min/--discyear-max value_of_discyear");

            Console.WriteLine("\nHow to search stars :");
            Console.WriteLine("First argument : -- search_stars");
            Console.WriteLine("Essential argument : --file name_of_file");
            Console.Write("Search arguments :");
            Console.Write("--teff-min/--teff-max value_of_temperature  |  ");
            Console.WriteLine("--rad-min/rad-max value_of_rad  |  --mass-min/--mass-max value_of_mass  |  --st_name stars_with_that_name  |  ");
            Console.Write("--vsin-min/--vsin-max value_of_rot_velocity  |  --rotp-min/--rotp-max value_of_star_rot  |  ");
            Console.WriteLine("--dist-min/--dist-max value_of_dist  |  --age-min/--age-max value_of_age  |  --pls-min/--pls-max number_of_planets");

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
            Console.Write("Names for ordering for stars : st_name | st_teff | ");
            Console.WriteLine("st_rad | st_mass | st_age | st_vsin | st_rotp | sy_dist | st_pls");
        }
        private string Truncate(string s)
        {
            s = s.Length <= 17? s : s.Substring(0, 17) + "...";
            return s;
        }
    }
}