using System;
using System.Reflection;

namespace LP2_Project1
{
    /// <summary>
    /// Class responsible for reading the arguments from the user and obtain
    /// the information he wants. It will help later on for the filter of
    /// the IEnumerables of the planets and stars.
    /// </summary>
    public class Propreties
    {
        /// <summary>
        /// Auto-implemented property that contains file name for search
        /// </summary>
        /// <value>Name of the file</value>
        public string File {get; private set;}
        /// <summary>
        /// Auto-implemented property that contains the name of the planet /
        /// star
        /// </summary>
        /// <value>Name of the platnet/star</value>
        public string Name {get; private set;}
        /// <summary>
        /// Auto-implemented property which will permit to know if it's a
        /// planet search or a star search
        /// </summary>
        /// <value>Planet or star, depending of which the user wants to
        /// search</value>
        public string Type {get; private set;}
        /// <summary>
        /// Auto-implemented property which contains the type of search the user
        /// wants
        /// </summary>
        /// <value>Search or Info, depending of which type of search the
        /// user wants</value>
        public string Search {get; private set;}
        /// <summary>
        /// Auto-implemented property which will contain the name that the
        /// user want to search for discovery methods
        /// </summary>
        /// <value>Insert name of user for discovery method</value>
        public string DiscoveryMethod {get; private set;}
        /// <summary>
        /// Auto-implemented property to know if the user wants the file in
        /// csv or not.
        /// </summary>
        /// <value>Null or On, depending of the user choice</value>
        public string CVS {get; private set;}
        /// <summary>
        /// Auto-implemented property to know if the user wants to a increasing
        /// order of a value
        /// </summary>
        /// <value>String of the value to do order</value>
        public string CrOrder {get; private set;}
        /// <summary>
        /// Auto-implemented property to know if the user wants to a decreasing
        /// order of a value
        /// </summary>
        /// <value>String of the value to do order</value>
        public string DrOrder {get; private set;}
        /// <summary>
        /// Auto-implemented property which contains the star that hosts the
        /// planet for search
        /// </summary>
        /// <value>Name of the star which contains the planet</value>
        public string HostName {get; private set;}
        /// <summary>
        /// Auto-implemented property containing value for the discovery year
        /// for search
        /// </summary>
        /// <value>Value of the discory year</value>
        public string[] DiscYear {get; private set;}
        /// <summary>
        /// Auto-implemented property containing value of the orbitational 
        /// period of the planet in days for search
        /// </summary>
        /// <value>Orbitational period in days</value>
        public string[] PlOrbper {get; private set;}
        /// <summary>
        /// Auto-implemented property containing value of the radius of the 
        /// planet for search
        /// </summary>
        /// <value>Radius of planet compared to Earth</value>
        public string[] PlRade {get; private set;}
        /// <summary>
        /// Auto-implemented property containing value of the mass of the planet
        /// for search
        /// </summary>
        /// <value>Mass of planet compared to Earth</value>
        public string[] PlMasse {get; private set;}
        /// <summary>
        /// Auto-implemented property containing value of the equilibrium
        /// temperature of the planet for search
        /// </summary>
        /// <value>Equilibrium temperature in Kelvins</value>
        public string[] PlEqt {get; private set;}
        /// <summary>
        /// Auto-implemented property contaning effective temperature of the
        /// star for search
        /// </summary>
        /// <value>Effective temperature in Kelvins</value>
        public string[] StTeff {get; private set;}
        /// <summary>
        /// Auto-implemented property containing radius of the star for search
        /// </summary>
        /// <value>Radius of star compared to the Sun</value>
        public string[] StRad {get; private set;}
        /// <summary>
        /// Auto-implemented property containing mass of the star for search
        /// </summary>
        /// <value>Mass of star compared to the Sun</value>
        public string[] StMass {get; private set;}
        /// <summary>
        /// Auto-implemented property containing the speed of rotation of the
        /// star for search
        /// </summary>
        /// <value>Speed of rotation in km/s</value>
        public string[] StVsin {get; private set;}
        /// <summary>
        /// Auto-implemented property containing the period of rotation for the
        /// star for search
        /// </summary>
        /// <value>Period of rotation in days</value>
        public string[] StRotp {get; private set;}
        /// <summary>
        /// Auto-implemented property containing the distance between the star
        /// and the Sun for search
        /// </summary>
        /// <value>distance between the star and the Sun in Parsecs</value>
        public string[] SyDist {get; private set;}
        /// <summary>
        /// Auto-implemented property containing the age of the star for search
        /// </summary>
        /// <value>Age of the star in Giga-years</value>
        public string[] StAge {get; private set;}
        /// <summary>
        /// Auto-implemented property containing the number of planets around
        /// the star for search
        /// </summary>
        /// <value>Number of planets around star</value>
        public string[] StPls {get; private set;}

        /// <summary>
        /// Just permits to end the programs in the user does not put a
        /// correct argument for search
        /// </summary>
        /// <return> Nothing </return>
        private Propreties()
        {
            // Exit the Program
            Environment.Exit(0);
        }

        /// <summary>
        /// Private constructor for the propreties for info type searchs
        /// </summary>
        /// <param name="file">Name of the file</param>
        /// <param name="search">Type of search</param>
        /// <param name="type">Search for planet or star</param>
        /// <param name="name">Name of the planet/star</param>
        /// <param name="csv">To know if csv is on or not</param>
        /// <return> The propreties to create a search for a specific 
        /// planet/star </return>
        private Propreties(string file, string search, string type, string name,
             string csv)
        {
            // Variables for propreties
            this.File = file;
            this.Search = search;
            this.Type = type;
            this.Name = name;
            this.CVS = csv;
        }

        /// <summary>
        /// Private constructor for the propreties for search type search for
        /// stars and planets
        /// </summary>
        /// <param name="file">Name of the file</param>
        /// <param name="search">Type of search</param>
        /// <param name="type">Search for planet or star</param>
        /// <param name="hostname">Name of the star</param>
        /// <param name="name">Name of the planet</param>
        /// <param name="discMethod">Name of disc. method of the planet</param>
        /// <param name="csv">To know if csv is on or not</param>
        /// <param name="crOrder">To know if there's increasing order</param>
        /// <param name="drOrder">To know if there's decreasing order</param>
        /// <param name="discYear">Discovery year of the planet</param>
        /// <param name="eqt">Equilibrium temperature of the planet</param>
        /// <param name="orbPer">Orbitational period of the planet</param>
        /// <param name="rade">Radius of the planet</param>
        /// <param name="masse">Mass of the planet</param>
        /// <param name="teff">Effective temperature of the star</param>
        /// <param name="rad">Radius of the star</param>
        /// <param name="mass">Mass of the star</param>
        /// <param name="vsin">Speed of rotation of the star</param>
        /// <param name="rotp">Period of rotation of the star</param>
        /// <param name="dist">Distance between the star and the Sun</param>
        /// <param name="age">Age of the star</param>
        /// <param name="pls">Planets of the star</param>
        /// <return> The propreties to create a search of the planets </return>
        private Propreties(string file, string search, string type, string name, 
            string host_name, string discMethod, string cvs, string crOrder, 
            string drOrder,string[] discYear, string[] eqt, string[] orbPer, 
            string[] rade, string[] masse, string[] teff,string[] rad,
            string[] mass, string[] vsin, string[] rotp,string[] dist, 
            string[] age, string[] pls)
        {
            // Variables for propreties
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
            this.StTeff = teff;
            this.StRad = rad;
            this.StMass = mass;
            this.StVsin = vsin;
            this.StRotp = rotp;
            this.SyDist = dist;
            this.StAge = age;
            this.StPls = pls;
        }

        /// <summary>
        /// Public static method which will read the initial argument and 
        /// determinte which type of the search the user wants
        /// </summary>
        /// <param name="args">Arguments of the user</param>
        /// <return> The propreties for the search </return>
        public static Propreties ReadArgs(string[] args)
        {
            // Variables
            string type, search;
            Propreties propreties;

            //Read the first arguments to determinte the type of search he wants
            switch (args[0])
            {
                //For a search of the planets
                case "search-planets":
                    type = "planet";
                    search = "search";
                    propreties = SearchOption(args, type, search);
                    break;

                //For a search of the stars
                case "search-stars":
                    type = "star";
                    search = "search";
                    propreties = SearchOption(args, type, search);
                    break;

                //For a specific search of a planet
                case "planet-info":
                    type = "planet";
                    search = "info";
                    propreties = InfoOption(args, type, search);
                    break;

                //For a specific search of a star
                case "star-info":
                    type = "star";
                    search = "info";
                    propreties = InfoOption(args, type, search);
                    break;

                //Shows the possible commands for the searchs
                case "help":
                    Interface UI = new Interface();
                    return new Propreties();

                //Shows the possible commands of the search since the user
                // failed
                default:
                    Console.WriteLine("This option does not exist, consult the command by typing -- help");
                    return new Propreties();
            }

            return propreties;
        }

        /// <summary>
        /// Private static method to read the propreties the user wants for
        /// search 
        /// </summary>
        /// <param name="args">Arguments of the user</param>
        /// <param name="type">Planet or star type search</param>
        /// <param name="search">Search type</param>
        /// <return> The propreties for the planets or stars search </return>
        private static Propreties SearchOption(string[] args,string type,
            string search)
        {
            // Variables of the propreties for this search
            int index = 0;
            string file = null, name = null, discMethod = null, cvs = null, 
            crOrder = null, drOrder = null, hostName = null;
            string[] discYear = new string [2], eqt = new string [2], 
            orbPer = new string [2], rade = new string [2], 
            masse = new string [2], teff = new string [2], 
            rad = new string [2], mass = new string [2], vsin = new string [2], 
            rotp = new string [2],dist = new string [2], age = new string [2], 
            pls = new string [2];

            // Reads which argument of the user to know what he wants to search
            // If one is correct, then he will be add to the propreties, the
            // others stay null and will not affect the search
            foreach(string arg in args)
            {
                arg.ToLower();
                
                if(arg == "--csv") cvs = "on";

                else if(arg == "--file") file = 
                    CondString(file, arg, "--file", index, args);

                else if(arg == "--pl_name") name = 
                    CondString(name, arg, "--pl_name", index, args);

                else if(arg == "--discmethod") discMethod = 
                    CondString(discMethod, arg, "--discmethod", index, args);

                else if(arg == "--cr_order") crOrder = 
                    CondString(crOrder, arg, "--cr_order", index, args);

                else if(arg == "--dr_order") drOrder = 
                    CondString(drOrder, arg, "--dr_order", index, args);

                else if(arg == "--hostname") hostName = 
                    CondString(hostName, arg, "--hostname", index, args);

                else if((arg == "--eqt-min") || (arg == "--eqt-max")) eqt = 
                    FloatMinMax(eqt, arg, "--eqt-min", "--eqt-max", index, 
                    args);

                else if((arg == "--masse-min") || (arg == "--masse-max"))masse = 
                    FloatMinMax(masse, arg, "--masse-min", "--masse-max", index, 
                    args);

                else if((arg == "--rade-min") || (arg == "--rade-max")) rade = 
                    FloatMinMax(rade, arg, "--rade-min", "--rade-max", index, 
                    args);

                else if((arg == "--orbper-min") || (arg == "--orbper-max")) 
                    orbPer = FloatMinMax(orbPer, arg, "--orbper-min", 
                    "--orbper-max", index, args);

                else if((arg == "--discyear-min") || (arg == "--discyear-max")) 
                    discYear = FloatMinMax(discYear, arg, "--discyear-min", 
                    "--discyear-max", index, args);

                else if((arg == "--teff-min") || (arg == "--teff-max")) teff = 
                    FloatMinMax(teff, arg, "--teff-min", "--teff-max", index, 
                    args);

                else if((arg == "--rad-min") || (arg == "--rad-max")) rad = 
                    FloatMinMax(rad, arg, "--rad-min", "--rad-max", index, 
                    args);

                else if((arg == "--mass-min") || (arg == "--mass-max")) mass = 
                    FloatMinMax(mass, arg, "--mass-min", "--mass-max", index, 
                    args);

                else if((arg == "--vsin-min") || (arg == "--vsin-max")) vsin = 
                    FloatMinMax(vsin, arg, "--vsin-min", "--vsin-max", index, 
                    args);

                else if((arg == "--rotp-min") || (arg == "--rotp-max")) rotp = 
                    FloatMinMax(rotp, arg, "--rotp-min", "--rotp-max", index, 
                    args);

                else if((arg == "--dist-min") || (arg == "--dist-max")) dist = 
                    FloatMinMax(dist, arg, "--dist-min", "--dist-max", index, 
                    args);

                else if((arg == "--age-min") || (arg == "--age-max")) age = 
                    FloatMinMax(age, arg, "--age-min", 
                    "--age-max", index, args);

                else if((arg == "--pls-max") || (arg == "--pls-min")) pls = 
                    FloatMinMax(pls, arg, "--pls-min", "--pls-max", index, 
                    args);

                else if(arg.Contains("--")) {
                    Console.WriteLine("There's must be a problem with one of yours arguments.");
                    Console.WriteLine("Please try again (use -- help to know all of them if needed).");
                    Environment.Exit(0);
                }
                
                index++;
            }

            return new Propreties(file, search, type, name,hostName, discMethod, 
                cvs, crOrder, drOrder, discYear, eqt, orbPer, rade, masse,
                teff,rad, mass, vsin, rotp, dist, age, pls);
        }
        
        /// <summary>
        /// Private static method to read the propreties for the specific star
        /// or planet search
        /// </summary>
        /// <param name="args">Arguments of the user</param>
        /// <param name="type">Star or Planet type of search</param>
        /// <param name="search">Info type</param>
        /// <return> The propreties for the specific search </return>
        private static Propreties InfoOption(string[] args, string type, 
            string search)
        {
            // Variables of the propreties for this search
            int index = 0;
            string file = null, name = null, cvs = null;

            // Reads each argument for the info search
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

        /// <summary>
        /// Private static method to confirm that the argument has the right
        /// name and attribute it to the right property for floats in string
        /// </summary>
        /// <param name="cond">Property that will gain a value if it's 
        /// correct</param>
        /// <param name="arg">Argument of the user</param>
        /// <param name="name1">Correct name for the min of the
        /// value attribution</param>
        /// <param name="name2">Correct name for the max of the 
        /// value attribution</param>
        /// <param name="index">Actual position in arguments</param>
        /// <param name="args">Arguments of the user</param>
        /// <return> The actualized property </return>
        private static string[] FloatMinMax(string[] cond, string arg, 
            string name1, string name2, int index, string[] args)
        {
            // For min value
            if(arg == name1)
            {
                // Gives string to the specific property
                try
                {
                    cond[0] = args[++index].ToLower();
                    --index;
                }
                // If the users forgot to put a value to one of his inputs
                // This will show up
                catch(IndexOutOfRangeException)
                {
                    Console.WriteLine("You gave no value to an argument, please verify your input.");
                    Console.WriteLine("Invalid Argument : {0}", arg);
                    Environment.Exit(0);
                }
            }

            // For max value
            else if(arg == name2)
            {
                // Gives string to the specific property
                try
                {
                    cond[1] = args[++index].ToLower();
                    --index;      
                }
                // If the users forgot to put a value to one of his inputs
                // This will show up
                catch(IndexOutOfRangeException)
                {
                    Console.WriteLine("You gave no value to an argument, please verify your input.");
                    Console.WriteLine("Invalid Argument : {0}", arg);
                    Environment.Exit(0);
                }
            }

            return cond;
        }

        /// <summary>
        /// Private static method to confirm that the argument has the right
        /// name and attribute it to the right property for strings
        /// </summary>
        /// <param name="cond">Property that will gain a value if it's 
        /// correct</param>
        /// <param name="arg">Argument of the user</param>
        /// <param name="name">Correct name for the string attribution </param>
        /// <param name="index">Actual position in arguments</param>
        /// <param name="args">Arguments of the user</param>
        /// <return> The actualized property </return>
        private static string CondString(string cond, string arg, 
            string name, int index, string[] args)
        {
            // Gives string to the specific property
            try
            {
                cond = args[++index].ToLower();
                --index;
            }
            // If the users forgot to put a value to one of his inputs
            // This will show up
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("You gave no value to an argument, please verify your input.");
                Console.WriteLine("Invalid Argument : {0}", arg);
                Environment.Exit(0);
            }
            
        return cond;
        }
    }
}