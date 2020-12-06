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
            p = planets.Where( pl => pl.pl_name == propreties.Name);
            output();
            
        }
        private void Planet_Star_search()
        {
            p = planets;

            PropertyInfo[] prop = typeof(Propreties).GetProperties();

            foreach (PropertyInfo pr in prop)
            {
                if (pr.GetValue(propreties) != null)
                {
                    //Console.WriteLine(pr.Name);
                    switch(pr.Name)
                    {
                        case "DiscoveryMethod":
                            p = p.Where( pl => pl.discoverymethod == propreties.DiscoveryMethod);
                            break;
                        case "DiscYear":
                            if (ToNullableFloat(propreties.DiscYear[0]) != null)
                            {
                                p = p.Where(pl => ToNullableFloat(pl.disc_year) >= ToNullableFloat(propreties.DiscYear[0]));
                            }                          
                            if (ToNullableFloat(propreties.DiscYear[1]) != null)
                            {
                                p = p.Where(pl => ToNullableFloat(pl.disc_year) <= 
                                    ToNullableFloat(propreties.DiscYear[1]));
                            }
                            break;
                        /*
                        case "PlOrbper":
                            p = p.Where(pl => ToNullableFloat(pl.pl_orbper) >= 
                                ToNullableFloat(propreties.PlOrbper[0]) && ToNullableFloat(pl.pl_orbper) <= 
                                ToNullableFloat(propreties.PlOrbper[1]));
                            break;
                        case "PlRade":
                            p = p.Where(pl => ToNullableFloat(pl.pl_rade) >= 
                                propreties.PlRade[0] && ToNullableFloat(pl.pl_rade) <= 
                                propreties.PlRade[1]);
                            break;
                        case "PlMasse":
                            p = p.Where(pl => ToNullableFloat(pl.pl_masse) >= 
                                propreties.PlMasse[0] && ToNullableFloat(pl.pl_masse) <= 
                                propreties.PlMasse[1]);
                            break;*/
                        case "PlEqt":
                                if (ToNullableFloat(propreties.PlEqt[0]) != null)
                                {
                                    p = p.Where(pl => ToNullableFloat(pl.pl_eqt) >= 
                                        ToNullableFloat(propreties.PlEqt[0]));
                                    
                                }
                                if (ToNullableFloat(propreties.PlEqt[1]) != null)
                                {
                                    p = p.Where(pl => ToNullableFloat(pl.pl_eqt) <= 
                                        ToNullableFloat(propreties.PlEqt[1]));
                                }
                            break;
                    }
                }
            }

            Interface UI = new Interface(p, propreties.CVS);
            //output();
            
        }

        private void output()
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