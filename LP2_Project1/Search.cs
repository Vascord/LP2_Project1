using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LP2_Project1
{
    public class Search
    {
        private List<Planets> planets;

        //private List<Stars> Stars;

        private Propreties propreties;

        private IEnumerable<Planets> p;

        //private IEnumerable<Stars> s;
        public Search(List<Planets> planets, Propreties propreties)
        {
            this.planets = planets;
            //this.Stars = Stars;
            this.propreties = propreties;
            Planet_Info();
        }

        private void Planet_Info()
        {
            p = planets.Where( pl => pl.pl_name == propreties.Name);
            foreach(Planets l in p)
            {
                Console.WriteLine(l.pl_name);
                Console.WriteLine(l.disc_year);
                Console.WriteLine(l.discoverymethod);
                Console.WriteLine(l.pl_eqt);
            }
        }
        private void Search_planets_and_Stars()
        {
            p = planets.Where(pl => ToNullableInt(pl.pl_eqt) > 1000);
            
            foreach(Planets l in p)
            {
                Console.WriteLine(l.pl_eqt);
            }
        }
        private int? ToNullableInt(string s)
        {
            int i;
            if (int.TryParse(s, out i)) return i;
            return null;
        }

        private float? ToNullableFloat(string s)
        {
            float i;
            if (float.TryParse(s, out i)) return i;
            return null;
        }
    }
}