namespace LP2_Project1
{
    public class Stars
    {
        public string st_teff {get; }
        public string st_rad {get; }
        public string st_mass {get; }
        public string st_age {get; }
        public string st_vsin {get; }
        public string st_rotp {get; }
        public string sy_dist {get; }

        public Stars(string st_teff, string st_rad, string st_mass,
            string st_age, string st_vsin, string st_rotp, string sy_dist)
        {
            this.st_teff = st_teff;
            this.st_rad = st_rad;
            this.st_age = st_age;
            this.st_vsin = st_vsin;
            this.st_rotp = st_rotp;
            this.sy_dist = sy_dist;
            this.st_mass = st_mass;

        }
    }
}