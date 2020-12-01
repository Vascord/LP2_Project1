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
        public string _name {get; private set;}
        public string _type {get; private set;}
        public string _discoveryMethod {get; private set;}
        public int[] _discYear {get; private set;}
        public float[] _plOrbper {get; private set;}
        public float[] _plRade {get; private set;}
        public float[] _plMasse {get; private set;}
        public float[] _plEqt {get; private set;}
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

        private Propreties(string type, string name)
        {
            this._type = type;
            this._name = name;
        }

        private Propreties(string type, float[] eqt)
        {
            this._type = type;
            this._plEqt = eqt;

            Console.WriteLine(_plEqt);
        }

        public static Propreties ReadArgs(string[] args)
        {
            string type;
            Propreties propreties;

            switch (args[0])
            {
                case "search-planets":
                    type = "planet";
                    propreties = SearchPlanetsOption(args, type);
                    return new Propreties();
                    // break;
                case "search-stars":
                    // propreties = SearchStarsOption(args);
                    return new Propreties();
                    // break;
                case "planet-info":
                    type = "planet";
                    propreties = InfoOption(args, type);
                    break;
                case "star-info":
                    type = "star";
                    propreties = InfoOption(args, type);
                    break;
                default:
                    Console.WriteLine(
                    "You will need to specify which search you want to do.");
                    return new Propreties();
            }

            return propreties;
        }

        private static Propreties SearchPlanetsOption(string[] args,string type)
        {
            int index = 0;
            string name = "";
            float[] eqt = new float[2];

            foreach(string arg in args)
            {
                arg.ToLower();

                if((arg == "--eqt-min") || (arg == "--eqt-max"))
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

                else if(arg == "--pl_name")
                {
                    name = args[++index].ToLower();
                    --index;
                }

                index++;
            }

            return new Propreties(type, eqt);
        }

        // private static Propreties SearchStarsOption(string[] args)
        // {

        // }

        private static Propreties InfoOption(string[] args, string type)
        {
            int index = 0;
            string name = "";

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

            return new Propreties(type, name);
        }
    }
}