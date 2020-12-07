using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

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

            switch(propreties.Search)
            {
                case "info":
                    Planet_Star_Info();
                    break;
                case "search":
                    Planet_Star_search();
                    break;
            }
        }

        private void Planet_Star_Info()
        {
            Console.WriteLine(propreties.Name);
            p = planets.Where( pl => pl.pl_name == propreties.Name);  

            Interface UI = new Interface(p, propreties.CVS);     
        }
        private void Planet_Star_search()
        {
            p = planets;

            PropertyInfo[] prop = typeof(Propreties).GetProperties();

            foreach (PropertyInfo pr in prop)
            {
                if (pr.GetValue(propreties) != null)
                {
                    switch(pr.Name)
                    {
                        case "DiscoveryMethod":
                            p = p.Where( pl => pl.discoverymethod == 
                                propreties.DiscoveryMethod);
                            break;
                        case "DiscYear":
                            SearchFloats(propreties.DiscYear, "disc_year");
                            break;

                        case "PlOrbper":
                            SearchFloats(propreties.PlOrbper, "pl_orbper");
                            break;

                        case "PlRade":
                            SearchFloats(propreties.PlRade, "pl_rade");
                            break;

                        case "PlMasse":
                            SearchFloats(propreties.PlMasse, "pl_masse");
                            break;

                        case "PlEqt":
                            SearchFloats(propreties.PlEqt, "pl_eqt");
                            break;
                    }
                }
            }

            if(propreties.CrOrder != null)
            {
                CrOrdering(propreties.CrOrder);
            }
            else if(propreties.DrOrder != null)
            {
                DrOrdering(propreties.DrOrder);
            }

            Interface UI = new Interface(p, propreties.CVS);
            
        }

        private float? ToNullableFloat(string s)
        {
            float i;
            if (float.TryParse(s, out i)) return i;
            return null;
        }

        private void SearchFloats(string[] minmax, string value)
        {
            PropertyInfo[] properties = typeof(Planets).GetProperties();

            if (ToNullableFloat(minmax[0]) != null)
            {
                p = p.Where(pl => ToNullableFloat(Convert.
                ToString(pl.GetType().GetProperty(value).GetValue(pl, null))) 
                    >= ToNullableFloat(minmax[0]));

            }
            if (ToNullableFloat(minmax[1]) != null)
            {
                p = p.Where(pl => ToNullableFloat(Convert.
                ToString(pl.GetType().GetProperty(value).GetValue(pl, null))) 
                    <= ToNullableFloat(minmax[1]));
            }
        }

        private void CrOrdering(string order)
        {
            p = p.OrderBy
                (pl => (pl.GetType().GetProperty(order).GetValue(pl, null)));
        }

        private void DrOrdering(string order)
        {
            p = p.OrderByDescending
                (pl => (pl.GetType().GetProperty(order).GetValue(pl, null)));
        }
    }
}