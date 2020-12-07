using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LP2_Project1
{
    public class Search
    {

        //private List<Stars> Stars;

        private Propreties propreties;
        public IEnumerable<Planets> planets {get; set;}
        public IEnumerable<Stars> stars {get; set;}

        //planetsrivate IEnumerable<Stars> s;
        public Search(IEnumerable<Planets> planets, IEnumerable<Stars> stars, Propreties propreties)
        {
            this.planets = planets;
            this.stars = stars;
            this.propreties = propreties;

            switch(propreties.Search)
            {
                case "info":
                    if (propreties.Type == "planet")
                        Planet_Info();
                    else
                        Star_Info();
                    break;
                case "search":
                    Planet_Star_search();
                    break;
            }
        }

        private void Planet_Info()
        {
            planets = planets.Where( pl => pl.pl_name == propreties.Name);      
        }
        private void Star_Info()
        {
            Console.WriteLine(propreties.Name);
            stars = stars.Where( pl => pl.st_name == propreties.Name);
        }
        private void Planet_Star_search()
        {
            PropertyInfo[] prop = typeof(Propreties).GetProperties();

            foreach (PropertyInfo pr in prop)
            {
                if (pr.GetValue(propreties) != null)
                {
                    switch(pr.Name)
                    {
                        case "Name":
                            if(propreties.Type == "planet")
                            {
                                planets = planets.Where( 
                                    pl => pl.pl_name.Contains(propreties.Name));
                            }
                            else
                            {
                                stars = stars.Where( pl => 
                                    pl.st_name.Contains(propreties.Name));
                            }
                            break;
                        case "DiscoveryMethod":
                            planets = planets.Where( pl => pl.discoverymethod
                                .Contains(propreties.DiscoveryMethod));
                            break;
                        case "HostName":
                            planets = planets.Where( pl => 
                                pl.hostname.Contains(propreties.HostName));
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
                        case "StTeff":
                            SearchFloats(propreties.StTeff, "st_teff");
                            break;
                        case "StRad":
                            SearchFloats(propreties.StRad, "st_rad");
                            break;
                        case "StMass":
                            SearchFloats(propreties.StMass, "st_mass");
                            break;
                        case "StVsin":
                            SearchFloats(propreties.StVsin, "st_vsin");
                            break;
                        case "StRotp":
                            SearchFloats(propreties.StRotp, "st_rotp");
                            break;
                        case "SyDist":
                            SearchFloats(propreties.SyDist, "sy_dist");
                            break;
                        case "StAge":
                            SearchFloats(propreties.StAge, "st_age");
                            break;
                        case "StPls":
                            SearchFloats(propreties.StPls, "st_pls");
                            break;
                    }
                }
            }

            if(propreties.CrOrder != null)
            {
                if((propreties.CrOrder == "pl_name") || 
                    (propreties.CrOrder == "hostname") ||
                    (propreties.CrOrder == "discmethod") || 
                    (propreties.CrOrder == "st_name"))
                {
                    CrOrdering(propreties.CrOrder);
                }
                else
                {
                    FloatCrOrdering(propreties.CrOrder);
                }
            }
            else if(propreties.DrOrder != null)
            {
                if((propreties.DrOrder == "pl_name") || 
                    (propreties.DrOrder == "hostname") || 
                    (propreties.DrOrder == "discmethod") ||
                    (propreties.DrOrder == "st_name"))
                {
                    DrOrdering(propreties.DrOrder);
                }
                else
                {
                    FloatDrOrdering(propreties.DrOrder);
                }
            }
            
        }

        private float? ToNullableFloat(string s)
        {
            float i;
            if (float.TryParse(s, out i)) return i;
            return null;
        }

        private void SearchFloats(string[] minmax, string value)
        {
            if(propreties.Type == "planet")
            {
                if (ToNullableFloat(minmax[0]) != null)
                {
                    planets = planets.Where(pl => ToNullableFloat(Convert.
                    ToString(pl.GetType().GetProperty(value).GetValue(pl, null))) 
                        >= ToNullableFloat(minmax[0]));

                }
                if (ToNullableFloat(minmax[1]) != null)
                {
                    planets = planets.Where(pl => ToNullableFloat(Convert.
                    ToString(pl.GetType().GetProperty(value).GetValue(pl, null))) 
                        <= ToNullableFloat(minmax[1]));
                }
            }
            else
            {
                if (ToNullableFloat(minmax[0]) != null)
                {
                    stars = stars.Where(pl => ToNullableFloat(Convert.
                    ToString(pl.GetType().GetProperty(value).GetValue(pl, null))) 
                        >= ToNullableFloat(minmax[0]));

                }
                if (ToNullableFloat(minmax[1]) != null)
                {
                    stars = stars.Where(pl => ToNullableFloat(Convert.
                    ToString(pl.GetType().GetProperty(value).GetValue(pl, null))) 
                        <= ToNullableFloat(minmax[1]));
                }
            }

            
        }

        private void FloatCrOrdering(string order)
        {
            if(propreties.Type == "planet")
            {
                planets = planets.OrderBy
                    (pl => (ToNullableFloat(Convert.ToString(pl.GetType()
                    .GetProperty(order).GetValue(pl, null)))));
            }
            else
            {
                stars = stars.OrderBy
                    (pl => (ToNullableFloat(Convert.ToString(pl.GetType()
                    .GetProperty(order).GetValue(pl, null)))));
            }
        }

        private void FloatDrOrdering(string order)
        {
            if(propreties.Type == "planet")
            {
                planets = planets.OrderByDescending
                    (pl => (ToNullableFloat(Convert.ToString(pl.GetType()
                    .GetProperty(order).GetValue(pl, null)))));
            }
            else
            {
                stars = stars.OrderByDescending
                    (pl => (ToNullableFloat(Convert.ToString(pl.GetType()
                    .GetProperty(order).GetValue(pl, null)))));
            }
        }

        private void CrOrdering(string order)
        {
            if(propreties.Type == "planet")
            {
                planets = planets.OrderBy
                (pl => (pl.GetType().GetProperty(order).GetValue(pl, null)));
            }
            else
            {
                stars= stars.OrderBy
                (pl => (pl.GetType().GetProperty(order).GetValue(pl, null)));
            }
        }

        private void DrOrdering(string order)
        {
            if(propreties.Type == "planet")
            {
                planets = planets.OrderByDescending
                (pl => (pl.GetType().GetProperty(order).GetValue(pl, null)));
            }
            else
            {
                stars = stars.OrderByDescending
                (pl => (pl.GetType().GetProperty(order).GetValue(pl, null)));
            }
        }
    }
}