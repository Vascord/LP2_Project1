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
                CVSInterface();
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
                "Planet Name", "Star Name", "Disc. Method", "Year", "Orbital", "Radius"
                , "Mass", "Eq. Temp.");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------");
            foreach(Planets l in planets)
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20} {6,-20} {7,-20}",
                l.pl_name, l.hostname, l.discoverymethod, l.disc_year, l.pl_orbper, l.pl_rade,
                l.pl_masse, l.pl_eqt);
            }
        }
        private void StarInterface()
        {
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20} {6,-20} {7,-20}", 
                "Star Name", "Star Temp.", "Radius", "Mass", "Age", "Rot. Vel."
                , "Rot.  Pre.", "Distance");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------");
            foreach(Stars l in stars)
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20} {6,-20} {7,-20}",
                l.st_name, l.st_teff, l.st_rad, l.st_mass, l.st_age, l.st_vsin,
                l.st_rotp, l.sy_dist);
            }
        }

        private void CVSInterface()
        {
            Console.WriteLine();
            Console.WriteLine("pl_name,hostname,discoverymethod,disc_year,pl_orbper,pl_rade,pl_masse,pl_eqt");
            foreach(Planets l in planets)
            {
                Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7}",
                l.pl_name, l.hostname, l.discoverymethod, l.disc_year, l.pl_orbper, l.pl_rade,
                l.pl_masse, l.pl_eqt);
            }
        }

        private void HelpInterface()
        {
            Console.WriteLine("WIP");
        }
    }
}