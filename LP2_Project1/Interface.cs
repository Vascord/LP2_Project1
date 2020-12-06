using System;
using System.Collections;
using System.Collections.Generic;

namespace LP2_Project1
{
    public class Interface
    {
        private IEnumerable<Planets> p;

        public Interface(IEnumerable<Planets> planets, string cvs)
        {
            this.p = planets;

            if(cvs == "on")
            {
                CVSInterface();
            }
            else
            {
                NormalInterface();
            }
        }

        public Interface()
        {
            HelpInterface();
        }

        private void NormalInterface()
        {
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20} {6,-20} {7,-20}", 
                "Planet Name", "Star Name", "Disc. Method", "Year", "Orbital", "Radius"
                , "Mass", "Eq. Temp.");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------");
            foreach(Planets l in p)
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20} {6,-20} {7,-20}",
                l.pl_name, l.hostname, l.discoverymethod, l.disc_year, l.pl_orbper, l.pl_rade,
                l.pl_masse, l.pl_eqt);
            }
        }

        private void CVSInterface()
        {
            Console.WriteLine();
            Console.WriteLine("pl_name,hostname,discoverymethod,disc_year,pl_orbper,pl_rade,pl_masse,pl_eqt");
            foreach(Planets l in p)
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