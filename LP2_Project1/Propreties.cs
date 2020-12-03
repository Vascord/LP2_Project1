using System;
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
        public float[] DiscYear {get; private set;}
        public float[] PlOrbper {get; private set;}
        public float[] PlRade {get; private set;}
        public float[] PlMasse {get; private set;}
        public float[] PlEqt {get; private set;}
        public float[] StTeff {get; private set;}
        public float[] StRad {get; private set;}
        public float[] StMass {get; private set;}
        public float[] StVsin {get; private set;}
        public float[] StRotp {get; private set;}
        public float[] SyDist {get; private set;}

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
            string discMethod, float[] discYear, float[] eqt, float[] orbPer, 
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

        private Propreties(string file,string search,string type,string name,
            float[] teff,float[] rad,float[] mass,float[] vsin,float[] rotp,
            float[] dist)
        {
            this.File = file;
            this.Search = search;
            this.Type = type;
            this.Name = name;
            this.StTeff = teff;
            this.StRad = rad;
            this.StMass = mass;
            this.StVsin = vsin;
            this.StRotp = rotp;
            this.SyDist = dist;
        }

        public static Propreties ReadArgs(string[] args)
        {
            string type, search;
            Propreties propreties;

            switch (args[0])
            {
                case "search-planets":
                    type = "planet";
                    search = "search";
                    propreties = SearchPlanetsOption(args, type, search);
                    break;

                case "search-stars":
                    type = "star";
                    search = "search";
                    propreties = SearchStarsOption(args, type, search);
                    break;

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
            string file = null, name = null, discMethod = null;
            float[] discYear = new float [2], eqt = new float[2], 
            orbPer = new float [2], rade = new float [2], masse = new float [2];

            foreach(string arg in args)
            {
                arg.ToLower();

                file = CondString(file, arg, "--file", index, args);

                name = CondString(name, arg, "--pl_name", index, args);

                discMethod = CondString(discMethod, arg, "--discmethod", index, 
                args);

                eqt = FloatMinMax(eqt, arg, "--eqt-min", "--eqt-max", 
                index, args);

                masse = FloatMinMax(masse, arg, "--masse-min", "--masse-max", 
                index, args);

                rade = FloatMinMax(rade, arg, "--rade-min", "--rade-max", 
                index, args);

                orbPer = FloatMinMax(orbPer, arg, "--orbper-min", "--orbper-max"
                , index, args);

                discYear = FloatMinMax(discYear, arg, "--discyear-min", 
                "--discyear-max", index, args);

                index++;
            }

            return new Propreties(file, search, type, name, discMethod, 
                discYear, eqt, orbPer, rade, masse);
        }

        private static Propreties SearchStarsOption(string[] args, string type,
            string search)
        {
            int index = 0;
            string file = null, name = null;
            float[] teff = new float [2], rad = new float[2], 
            mass = new float [2], vsin = new float [2], rotp = new float [2],
            dist = new float[2];

            foreach(string arg in args)
            {
                arg.ToLower();

                file = CondString(file, arg, "--file", index, args);

                name = CondString(name, arg, "--st_name", index, args);

                teff = FloatMinMax(teff, arg, "--teff-min", "--teff-max", 
                index, args);

                rad = FloatMinMax(rad, arg, "--rad-min", "--rad-max", 
                index, args);

                mass = FloatMinMax(mass, arg, "--mass-min", "--mass-max", 
                index, args);

                vsin = FloatMinMax(vsin, arg, "--vsin-min", "--vsin-max", 
                index, args);

                rotp = FloatMinMax(rotp, arg, "--rotp-min", 
                "--rotp-max", index, args);

                dist = FloatMinMax(dist, arg, "--dist-min", 
                "--dist-max", index, args);

                index++;
            }

            return new Propreties(file, search, type, name, teff, 
                rad, mass, vsin, rotp, dist);
        }

        private static Propreties InfoOption(string[] args, string type, 
            string search)
        {
            int index = 0;
            string file = null, name = null;

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

        private static float[] FloatMinMax(float[] cond, string arg, 
            string name1, string name2, int index, string[] args)
        {
            if((arg == name1) || (arg == name2))
            {
                if(arg == name1)
                {
                    cond[0] = int.Parse(args[++index], 
                        CultureInfo.InvariantCulture.NumberFormat); 
                    --index;
                }

                else if(arg == name2)
                {
                    cond[1] = int.Parse(args[++index], 
                        CultureInfo.InvariantCulture.NumberFormat); 
                    --index;
                }
            }

            return cond;
        }

        private static string CondString(string cond, string arg, 
            string name, int index, string[] args)
        {
            if(arg == name)
            {
                cond = args[++index].ToLower();
                --index;
            }

            return cond;
        }
    }
}