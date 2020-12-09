namespace LP2_Project1
{
    /// <summary>
    /// Class which keeps the data a given planet
    /// </summary>
    public class Planets
    {
        /// <summary>
        /// Auto-implemented property that contains the name of the planet
        /// </summary>
        /// <value>Name of the platnet</value>
        public string pl_name { get; }
        /// <summary>
        /// Auto-implemented property which contains the name of a star 
        /// </summary>
        /// <value>Name of the a star</value>
        public string hostname { get; }
        /// <summary>
        /// Auto-implemented property which will contain the name that the
        /// user want to search for discovery methods
        /// </summary>
        /// <value>Insert name of user for discovery method</value>
        public string discoverymethod { get; }
        /// <summary>
        /// Auto-implemented property containing value for the discovery year
        /// for search
        /// </summary>
        /// <value>Value of the discory year</value>
        public string disc_year {get; }
        /// <summary>
        /// Auto-implemented property containing value of the orbitational 
        /// period of the planet in days for search
        /// </summary>
        /// <value>Orbitational period in days</value>
        public string pl_orbper {get; }
        /// <summary>
        /// Auto-implemented property containing the period of rotation for the
        /// star for search
        /// </summary>
        /// <value>Period of rotation in days</value>
        public string pl_rade {get; }
        /// <summary>
        /// Auto-implemented property containing value of the mass of the planet
        /// for search
        /// </summary>
        /// <value>Mass of planet compared to Earth</value>
        public string pl_masse {get; }
        /// <summary>
        /// Auto-implemented property containing value of the equilibrium
        /// temperature of the planet for search
        /// </summary>
        /// <value>Equilibrium temperature in Kelvins</value>
        public string pl_eqt {get; }

        /// <summary>
        /// Public constructor for each planet with their date
        /// </summary>
        /// <param name="pl_name">Name of the planet</param>
        /// <param name="hostname">Name of the star</param>
        /// <param name="discoverymethod">Name of disc. method of the 
        /// planet</param>
        /// <param name="disc_year">Discovery year of the planet</param>
        /// <param name="pl_orbper">Orbitational period of the planet</param>
        /// <param name="pl_rade">Radius of the planet</param>
        /// <param name="pl_masse">Mass of the planet</param>
        /// <param name="pl_eqt">Equilibrium temperature of the planet</param>
        public Planets(string pl_name, string hostname, string discoverymethod,
            string disc_year, string pl_orbper, string pl_rade, string pl_masse, 
            string pl_eqt)
        {
            this.pl_name = pl_name;
            this.hostname = hostname;
            this.discoverymethod = discoverymethod;
            this.disc_year = disc_year;
            this.pl_orbper = pl_orbper;
            this.pl_rade = pl_rade;
            this.pl_masse = pl_masse;
            this.pl_eqt = pl_eqt;
        }
    }
}