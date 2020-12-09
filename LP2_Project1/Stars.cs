namespace LP2_Project1 
{
    /// <summary>
    /// Class which keeps the data a given star
    /// </summary>
    public class Stars
    {
        /// <summary>
        /// Auto-implemented property which contains the name of a star 
        /// </summary>
        /// <value>Name of the a star</value>
        public string st_name {get; set;}
        /// <summary>
        /// Auto-implemented property contaning effective temperature of the
        /// star for search
        /// </summary>
        /// <value>Effective temperature in Kelvins</value>
        public string st_teff {get; set;}
        /// <summary>
        /// Auto-implemented property containing radius of the star for search
        /// </summary>
        /// <value>Radius of star compared to the Sun</value>
        public string st_rad {get; set;}
        /// <summary>
        /// Auto-implemented property containing mass of the star for search
        /// </summary>
        /// <value>Mass of star compared to the Sun</value>
        public string st_mass {get; set;}
        /// <summary>
        /// Auto-implemented property containing the age of the star for search
        /// </summary>
        /// <value>Age of the star in Giga-years</value>
        public string st_age {get; set;}
        /// <summary>
        /// Auto-implemented property containing the speed of rotation of the
        /// star for search
        /// </summary>
        /// <value>Speed of rotation in km/s</value>
        public string st_vsin {get; set;}
        /// <summary>
        /// Auto-implemented property containing the period of rotation for the
        /// star for search
        /// </summary>
        /// <value>Period of rotation in days</value>
        public string st_rotp {get; set;}
        /// <summary>
        /// Auto-implemented property containing the distance between the star
        /// and the Sun for search
        /// </summary>
        /// <value>Distance between the star and the Sun in Parsecs</value>
        public string sy_dist {get; set;}
        /// <summary>
        /// Auto-implemented property containing the number of planets around
        /// the star for search
        /// </summary>
        /// <value>Number of planets around star</value>
        public string st_pls {get; set;}

        /// <summary>
        /// Public constructor for each planet with their date
        /// </summary>
        /// <param name="st_name">Name of the star</param>
        /// <param name="st_teff">Effective temperature of the star</param>
        /// <param name="st_rad">Radius of the star</param>
        /// <param name="st_mass">Mass of the star</param>
        /// <param name="st_age">Age of the star</param>
        /// <param name="st_vsin">Speed of rotation of the star</param>
        /// <param name="st_rotp">Period of rotation of the star</param>
        /// <param name="sy_dist">Distance between the star and the Sun</param>
        /// <param name="st_pls">Number of planets of the star</param>
        public Stars(string st_name, string st_teff, string st_rad, 
            string st_mass, string st_age, string st_vsin, string st_rotp, 
            string sy_dist, string st_pls)
        {
            this.st_name = st_name;
            this.st_teff = st_teff;
            this.st_rad = st_rad;
            this.st_age = st_age;
            this.st_vsin = st_vsin;
            this.st_rotp = st_rotp;
            this.sy_dist = sy_dist;
            this.st_mass = st_mass;
            this.st_pls = st_pls;
        }
    }
}