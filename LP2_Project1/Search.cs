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

        private List<Stars> Stars;

        private Propreties propreties;

        private IEnumerable<Planets> p;

        private IEnumerable<Stars> s;
        public Search(List<Planets> planets, List<Stars> Stars, Propreties propreties)
        {
            this.planets = planets;
            this.Stars = Stars;
            this.propreties = propreties;
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
    }
}