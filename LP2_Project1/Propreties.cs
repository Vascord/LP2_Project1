using System;
using System.Linq;
using System.Globalization;

namespace LP2_Project1
{
    /// <summary>
    /// Class responsible for reading the arguments from the user and obtain
    /// the information he wants. It will help later on for the filter of
    /// the IEnumerables of the planets and stars.
    /// </summary>
    public class Propreties
    {
        public string File {get; private set;}
        public string Name {get; private set;}
        public string Type {get; private set;}
        public string Search {get; private set;}
        public string DiscoveryMethod {get; private set;}
        public int[] DiscYear {get; private set;}
        public float[] PlOrbper {get; private set;}
        public float[] PlRade {get; private set;}
        public float[] PlMasse {get; private set;}
        public float[] PlEqt {get; private set;}
        public float _stTeff {get; private set;}
        public float _stRad {get; private set;}
        public float _stMass {get; private set;}
        public float _stVsin {get; private set;}
        public float _stRotp {get; private set;}
        public float _syDist {get; private set;}

        private Propreties()
        {
            Environment.Exit(0);
        }

        private Propreties(string file, string search, string type, string name)
        {
            this.File = file;
            this.Search = search;
            this.Type = type;
            this.Name = name;
        }

        private Propreties(string file, string search, string type, string name, 
            string discMethod, int[] discYear, float[] eqt, float[] orbPer, 
            float[] rade, float[] masse)
        {
            this.File = file;
            this.Search = search;
            this.Type = type;
            this.Name = name;
            this.DiscoveryMethod = discMethod;
            this.DiscYear = discYear;
            this.PlEqt = eqt;
            this.PlOrbper = orbPer;
            this.PlRade = rade;
            this.PlMasse = masse;
        }

        public static Propreties ReadArgs(string[] args)
        {
            string type;
            string search;
            Propreties propreties;

            switch (args[0])
            {
                case "search-planets":
                    type = "planet";
                    search = "search";
                    propreties = SearchPlanetsOption(args, type, search);
                    break;
                case "search-stars":
                    // type = "planet";
                    // search = "search";
                    // propreties = SearchStarsOption(args);
                    return new Propreties();
                    // break;
                case "planet-info":
                    type = "planet";
                    search = "info";
                    propreties = InfoOption(args, type, search);
                    break;
                case "star-info":
                    type = "star";
                    search = "info";
                    propreties = InfoOption(args, type, search);
                    break;
                default:
                    Console.WriteLine(
                    "You will need to specify which search you want to do.");
                    return new Propreties();
            }

            return propreties;
        }

        private static Propreties SearchPlanetsOption(string[] args,string type,
            string search)
        {
            int index = 0;
            string file = null;
            string name = null;
            string discMethod = null;
            int[] discYear = new int [2];
            float[] eqt = new float[2];
            float[] orbPer = new float [2];
            float[] rade = new float [2];
            float[] masse = new float [2];

            foreach(string arg in args)
            {
                arg.ToLower();

                if(arg == "--file")
                {
                    file = args[++index].ToLower();
                    --index;
                }

                else if(arg == "--pl_name")
                {
                    name = args[++index].ToLower();
                    --index;
                }

                else if(arg == "--discmethod")
                {
                    discMethod = args[++index].ToLower();
                    --index;
                }

                else if((arg == "--eqt-min") || (arg == "--eqt-max"))
                {
                    if(arg == "--eqt-min")
                    {
                        eqt[0] = float.Parse(args[++index], 
                            CultureInfo.InvariantCulture.NumberFormat); 
                        --index;
                    }

                    else if(arg == "--eqt-max")
                    {
                        eqt[1] = float.Parse(args[++index], 
                            CultureInfo.InvariantCulture.NumberFormat); 
                        --index;
                    }
                }

                else if((arg == "--masse-min") || (arg == "--masse-max"))
                {
                    if(arg == "--masse-min")
                    {
                        masse[0] = float.Parse(args[++index], 
                            CultureInfo.InvariantCulture.NumberFormat); 
                        --index;
                    }

                    else if(arg == "--masse-max")
                    {
                        masse[1] = float.Parse(args[++index], 
                            CultureInfo.InvariantCulture.NumberFormat); 
                        --index;
                    }
                }

                else if((arg == "--rade-min") || (arg == "--rade-max"))
                {
                    if(arg == "--rade-min")
                    {
                        rade[0] = float.Parse(args[++index], 
                            CultureInfo.InvariantCulture.NumberFormat); 
                        --index;
                    }

                    else if(arg == "--rade-max")
                    {
                        rade[1] = float.Parse(args[++index], 
                            CultureInfo.InvariantCulture.NumberFormat); 
                        --index;
                    }
                }

                else if((arg == "--orbper-min") || (arg == "--orbper-max"))
                {
                    if(arg == "--orbper-min")
                    {
                        orbPer[0] = float.Parse(args[++index], 
                            CultureInfo.InvariantCulture.NumberFormat); 
                        --index;
                    }

                    else if(arg == "--orbper-max")
                    {
                        orbPer[1] = float.Parse(args[++index], 
                            CultureInfo.InvariantCulture.NumberFormat); 
                        --index;
                    }
                }

                else if((arg == "--discyear-min") || (arg == "--discyear-max"))
                {
                    if(arg == "--discyear-min")
                    {
                        discYear[0] = int.Parse(args[++index], 
                            CultureInfo.InvariantCulture.NumberFormat); 
                        --index;
                    }

                    else if(arg == "--discyear-max")
                    {
                        discYear[1] = int.Parse(args[++index], 
                            CultureInfo.InvariantCulture.NumberFormat); 
                        --index;
                    }
                }

                index++;
            }

            return new Propreties(file, search, type, name, discMethod, 
                discYear, eqt, orbPer, rade, masse);
        }

        // private static Propreties SearchStarsOption(string[] args)
        // {

        // }

        private static Propreties InfoOption(string[] args, string type, 
            string search)
        {
            int index = 0;
            string file = null;
            string name = null;

            foreach(string arg in args)
            {
                arg.ToLower();

                if(((arg == "--st_name") && (type == "star")) || 
                ((arg == "--pl_name") && (type == "planet")))
                {
                    name = args[++index].ToLower();
                    --index;
                }

                index++;
            }

            return new Propreties(file, search, type, name);
        }
    }
}