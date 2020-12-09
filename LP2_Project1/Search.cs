using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LP2_Project1
{
    /// <summary>
    /// Class which will search the planets or stars depending of the propreties
    /// of the user
    /// </summary>
    public class Search
    {

        private Propreties propreties;
        /// <summary>
        /// Auto-implemented property that contains all the planets of the file
        /// </summary>
        /// <value>The collection of all the planets</value>
        public IEnumerable<Planets> planets {get; set;}
        /// <summary>
        /// Auto-implemented property that contains all the stars of the file
        /// </summary>
        /// <value>The collection of all the stars</value>
        public IEnumerable<Stars> stars {get; set;}

        /// <summary>
        /// Public constructor that will launch the search process
        /// </summary>
        /// <param name="planets">Name of the file</param>
        /// <param name="stars">Type of search</param>
        /// <param name="propreties">Search for planet or star</param>
        /// <return> Returns the actualized the enumerables after the 
        /// search </return>
        public Search(IEnumerable<Planets> planets, IEnumerable<Stars> stars, 
            Propreties propreties)
        {
            // Variables
            this.planets = planets;
            this.stars = stars;
            this.propreties = propreties;

            // Sees which type of search the user wants with propreties
            switch(propreties.Search)
            {
                case "info":
                    // Sees if it's a planet type of search
                    if (propreties.Type == "planet")
                        Planet_Info();
                    // or a star one
                    else
                        Star_Info();
                    break;
                case "search":
                    Planet_Star_search();
                    break;
            }
        }

        /// <summary>
        /// Private method to modify the enumerables planets depending of which 
        /// planet the user wants to have info of
        /// </summary>
        private void Planet_Info()
        {
            planets = planets.Where( pl => pl.pl_name == propreties.Name);      
        }
        /// <summary>
        /// Private method to modify the enumerable stars depending of which 
        /// star the user wants to have info of
        /// </summary>
        private void Star_Info()
        {
            Console.WriteLine(propreties.Name);
            stars = stars.Where( pl => pl.st_name == propreties.Name);
        }
        /// <summary>
        /// Private method do the search for the planets or stars he wants
        /// </summary>
        private void Planet_Star_search()
        {
            // Gets the propreties of Propreties.cs class
            PropertyInfo[] prop = typeof(Propreties).GetProperties();

            // Cycles through propreties
            foreach (PropertyInfo pr in prop)
            {
                // Continues if the propreties is not null
                if (pr.GetValue(propreties) != null)
                {
                    // Sees what's the name of the property to filter
                    switch(pr.Name)
                    {
                        // For each of them, it will filter the enumerables 
                        // planets or stars depending of the property
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
                            SearchPlanetFloats(propreties.DiscYear, 
                                "disc_year");
                            break;
                        case "PlOrbper":
                            SearchPlanetFloats(propreties.PlOrbper, 
                                "pl_orbper");
                            break;
                        case "PlRade":
                            SearchPlanetFloats(propreties.PlRade, "pl_rade");
                            break;
                        case "PlMasse":
                            SearchPlanetFloats(propreties.PlMasse, "pl_masse");
                            break;
                        case "PlEqt":
                            SearchPlanetFloats(propreties.PlEqt, "pl_eqt");
                            break;
                        case "StTeff":
                            SearchStarsFloats(propreties.StTeff, "st_teff");
                            break;
                        case "StRad":
                            SearchStarsFloats(propreties.StRad, "st_rad");
                            break;
                        case "StMass":
                            SearchStarsFloats(propreties.StMass, "st_mass");
                            break;
                        case "StVsin":
                            SearchStarsFloats(propreties.StVsin, "st_vsin");
                            break;
                        case "StRotp":
                            SearchStarsFloats(propreties.StRotp, "st_rotp");
                            break;
                        case "SyDist":
                            SearchStarsFloats(propreties.SyDist, "sy_dist");
                            break;
                        case "StAge":
                            SearchStarsFloats(propreties.StAge, "st_age");
                            break;
                        case "StPls":
                            SearchStarsFloats(propreties.StPls, "st_pls");
                            break;
                    }
                }
            }

            if(propreties.Type == "planet")
            {
                planets = 
                    from p in planets
                    join s in stars on p.hostname equals s.st_name
                    select p;
            }
            if(propreties.Type == "star")
            {
                stars = 
                    from s in stars
                    join p in planets on s.st_name equals p.hostname
                    select s;
            }
            
            // Sees if the user wants the increasing order
            if(propreties.CrOrder != null)
            {
                // Sees if it's for string orderging
                if((propreties.CrOrder == "pl_name") || 
                    (propreties.CrOrder == "hostname") ||
                    (propreties.CrOrder == "discmethod") || 
                    (propreties.CrOrder == "st_name"))
                {
                    CrOrdering(propreties.CrOrder);
                }
                // Or float ordering
                else
                {
                    FloatCrOrdering(propreties.CrOrder);
                }
            }
            // Sees if the user wants the decreasing order
            else if(propreties.DrOrder != null)
            {
                // Sees if it's for string orderging
                if((propreties.DrOrder == "pl_name") || 
                    (propreties.DrOrder == "hostname") || 
                    (propreties.DrOrder == "discmethod") ||
                    (propreties.DrOrder == "st_name"))
                {
                    DrOrdering(propreties.DrOrder);
                }
                // Or float ordering
                else
                {
                    FloatDrOrdering(propreties.DrOrder);
                }
            }
            
        }

        /// <summary>
        /// Private method that search for the planets or stars with the min
        /// or max value of a property and actualize the enumerables
        /// </summary>
        /// <param name="minmax">The value min or max to search</param>
        /// <param name="value">What property to search</param>
        private void SearchPlanetFloats(string[] minmax, string value)
        {
            // If the minimun is not null, then it searchs with the min 
            // value
            if (ToNullableFloat(minmax[0]) != null)
            {
                planets = planets.Where(pl => ToNullableFloat(Convert.
                ToString(pl.GetType().GetProperty(value).GetValue(pl, null))) 
                    >= ToNullableFloat(minmax[0]));
            }
            // If the maximum is not null, then it searchs with the max 
            // value
            if (ToNullableFloat(minmax[1]) != null)
            {
                planets = planets.Where(pl => ToNullableFloat(Convert.
                ToString(pl.GetType().GetProperty(value).GetValue(pl, null))) 
                    <= ToNullableFloat(minmax[1]));
            }
            
        }
        private void SearchStarsFloats(string[] minmax, string value)
        {
            // If the maximum is not null, then it searchs with the min
            // value
            if (ToNullableFloat(minmax[0]) != null)
            {
                stars = stars.Where(pl => ToNullableFloat(Convert.
                ToString(pl.GetType().GetProperty(value).GetValue(pl, null))) 
                    >= ToNullableFloat(minmax[0]));
            }
            // If the maximum is not null, then it searchs with the max 
            // value
            if (ToNullableFloat(minmax[1]) != null)
            {
                stars = stars.Where(pl => ToNullableFloat(Convert.
                ToString(pl.GetType().GetProperty(value).GetValue(pl, null))) 
                    <= ToNullableFloat(minmax[1]));
            }
        }

        /// <summary>
        /// Private method that orders increasingly the enumerables of a 
        /// specific float value
        /// </summary>
        /// <param name="order">The value to order</param>
        private void FloatCrOrdering(string order)
        {
            // Sees if it's a planet
            if(propreties.Type == "planet")
            {
                //Orders the planets enumerable
                planets = planets.OrderBy
                    (pl => (ToNullableFloat(Convert.ToString(pl.GetType()
                    .GetProperty(order).GetValue(pl, null)))));
            }
            // Sees if it's a star
            else
            {
                //Orders the stars enumerable
                stars = stars.OrderBy
                    (pl => (ToNullableFloat(Convert.ToString(pl.GetType()
                    .GetProperty(order).GetValue(pl, null)))));
            }
        }

        /// <summary>
        /// Private method that orders decreasingly the enumerables of a 
        /// specific float value
        /// </summary>
        /// <param name="order">The value to order</param>
        private void FloatDrOrdering(string order)
        {
            // Sees if it's a planet
            if(propreties.Type == "planet")
            {
                //Orders the planets enumerable
                planets = planets.OrderByDescending
                    (pl => (ToNullableFloat(Convert.ToString(pl.GetType()
                    .GetProperty(order).GetValue(pl, null)))));
            }
            // Sees if it's a star
            else
            {
                //Orders the stars enumerable
                stars = stars.OrderByDescending
                    (pl => (ToNullableFloat(Convert.ToString(pl.GetType()
                    .GetProperty(order).GetValue(pl, null)))));
            }
        }

        /// <summary>
        /// Private method that orders decreasingly the enumerables of a 
        /// specific string value
        /// </summary>
        /// <param name="order">The value to order</param>
        private void CrOrdering(string order)
        {
            // Sees if it's a planet
            if(propreties.Type == "planet")
            {
                //Orders the planets enumerable
                planets = planets.OrderBy
                (pl => (pl.GetType().GetProperty(order).GetValue(pl, null)));
            }
            // Sees if it's a star
            else
            {
                //Orders the stars enumerable
                stars= stars.OrderBy
                (pl => (pl.GetType().GetProperty(order).GetValue(pl, null)));
            }
        }

        /// <summary>
        /// Private method that orders decreasingly the enumerables of a 
        /// specific string value
        /// </summary>
        /// <param name="order">The value to order</param>
        private void DrOrdering(string order)
        {
            // Sees if it's a planet
            if(propreties.Type == "planet")
            {
                //Orders the planets enumerable
                planets = planets.OrderByDescending
                (pl => (pl.GetType().GetProperty(order).GetValue(pl, null)));
            }
            // Sees if it's a star
            else
            {
                //Orders the stars enumerable
                stars = stars.OrderByDescending
                (pl => (pl.GetType().GetProperty(order).GetValue(pl, null)));
            }
        }

        /// <summary>
        /// Private method that see if it's possible to convert to float
        /// </summary>
        /// <param name="s">The string you want to convert</param>
        /// <return> Returns float if possible, or else it's null </return>
        private float? ToNullableFloat(string s)
        {
            float i;
            if (float.TryParse(s, out i)) return i;
            if (s == "") return null;
            if (s == null) return null;
            Console.WriteLine("There must be an error in a value for a argument that requires a float.");
            Console.WriteLine("Please, try again with a correct value (consult -- help for help).");
            Console.WriteLine("The incorrect value : {0}", s);
            Environment.Exit(0);
            return null;
        }
    }
}