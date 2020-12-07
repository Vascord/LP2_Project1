using System;

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
        public string CVS {get; private set;}
        public string CrOrder {get; private set;}
        public string DrOrder {get; private set;}
        public string HostName {get; private set;}
        public string[] DiscYear {get; private set;}
        public string[] PlOrbper {get; private set;}
        public string[] PlRade {get; private set;}
        public string[] PlMasse {get; private set;}
        public string[] PlEqt {get; private set;}
        public string[] StTeff {get; private set;}
        public string[] StRad {get; private set;}
        public string[] StMass {get; private set;}
        public string[] StVsin {get; private set;}
        public string[] StRotp {get; private set;}
        public string[] SyDist {get; private set;}
        public string[] StAge {get; private set;}
        public string[] StPls {get; private set;}


        private Propreties()
        {
            Environment.Exit(0);
        }

        private Propreties(string file, string search, string type, string name,
             string csv)
        {
            this.File = file;
            this.Search = search;
            this.Type = type;
            this.Name = name;
            this.CVS = csv;
        }

        private Propreties(string file, string search, string type, string name, 
            string discMethod, string cvs, string crOrder, string drOrder, string host_name,
            string[] discYear, string[] eqt, string[] orbPer, string[] rade, 
            string[] masse)
        {
            this.File = file;
            this.Search = search;
            this.Type = type;
            this.Name = name;
            this.DiscoveryMethod = discMethod;
            this.CVS = cvs;
            this.CrOrder = crOrder;
            this.DrOrder = drOrder;
            this.HostName = host_name;
            this.DiscYear = discYear;
            this.PlEqt = eqt;
            this.PlOrbper = orbPer;
            this.PlRade = rade;
            this.PlMasse = masse;
            
        }

        private Propreties(string file,string search,string type,string name, 
            string cvs, string crOrder, string drOrder, string[] teff,
            string[] rad,string[] mass, string[] vsin, string[] rotp,
            string[] dist, string[] age, string[] pls)
        {
            this.File = file;
            this.Search = search;
            this.Type = type;
            this.Name = name;
            this.CVS = cvs;
            this.CrOrder = crOrder;
            this.DrOrder = drOrder;
            this.StTeff = teff;
            this.StRad = rad;
            this.StMass = mass;
            this.StVsin = vsin;
            this.StRotp = rotp;
            this.SyDist = dist;
            this.StAge = age;
            this.StPls = pls;
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
                case "help":
                    Interface UI = new Interface();
                    return new Propreties();

                default:
                    UI = new Interface();
                    return new Propreties();
            }

            return propreties;
        }

        private static Propreties SearchPlanetsOption(string[] args,string type,
            string search)
        {
            int index = 0;
            string file = null, name = null, discMethod = null, cvs = null, 
            crOrder = null, drOrder = null, hostName = null;
            string[] discYear = new string [2], eqt = new string [2], 
            orbPer = new string [2], rade = new string [2], 
            masse = new string [2];

            foreach(string arg in args)
            {
                arg.ToLower();
                
                if(arg == "--csv") cvs = "on";

                file = CondString(file, arg, "--file", index, args);

                name = CondString(name, arg, "--pl_name", index, args);

                discMethod = CondString(discMethod, arg, "--discmethod", index, 
                args);

                crOrder = CondString(crOrder, arg, "--cr_order", index, args);

                drOrder = CondString(drOrder, arg, "--dr_order", index, args);

                hostName = CondString(hostName, arg, "--hostname", 
                    index, args);

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

            return new Propreties(file, search, type, name, discMethod, cvs, 
                crOrder, drOrder, hostName, discYear, eqt, orbPer, rade, masse);
        }

        private static Propreties SearchStarsOption(string[] args, string type,
            string search)
        {
            int index = 0;
            string file = null, name = null, cvs = null, crOrder = null, 
            drOrder = null ;
            string[] teff = new string [2], rad = new string [2], 
            mass = new string [2], vsin = new string [2], rotp = new string [2],
            dist = new string [2], age = new string [2], pls = new string [2];

            foreach(string arg in args)
            {
                arg.ToLower();

                if(arg == "--csv") cvs = "on";

                file = CondString(file, arg, "--file", index, args);

                name = CondString(name, arg, "--st_name", index, args);

                crOrder = CondString(crOrder, arg, "--cr_order", index, args);

                drOrder = CondString(drOrder, arg, "--dr_order", index, args);

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

                age = FloatMinMax(age, arg, "--age-min", 
                "--age-max", index, args);

                pls = FloatMinMax(pls, arg, "--pls-min", 
                "--pls-max", index, args);

                index++;
            }

            return new Propreties(file, search, type, name, cvs, crOrder, drOrder, 
                teff,rad, mass, vsin, rotp, dist, age, pls);
        }

        private static Propreties InfoOption(string[] args, string type, 
            string search)
        {
            int index = 0;
            string file = null, name = null, cvs = null;

            foreach(string arg in args)
            {
                arg.ToLower();

                if(arg == "--csv") cvs = "on";

                file = CondString(file, arg, "--file", index, args);

                if(((arg == "--st_name") && (type == "star")) || 
                ((arg == "--pl_name") && (type == "planet")))
                {
                    name = args[++index].ToLower();
                    --index;
                }

                index++;
            }

            return new Propreties(file, search, type, name, cvs);
        }

        private static string[] FloatMinMax(string[] cond, string arg, 
            string name1, string name2, int index, string[] args)
        {
            if((arg == name1) || (arg == name2))
            {
                if(arg == name1)
                {
                    cond[0] = args[++index].ToLower();
                    --index;
                    return cond;

                }

                else if(arg == name2)
                {
                    cond[1] = args[++index].ToLower();
                    --index;
                    return cond;
                    
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