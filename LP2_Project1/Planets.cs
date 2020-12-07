namespace LP2_Project1
{
    public class Planets
    {
        public string pl_name { get; }
        public string hostname { get; }
        public string discoverymethod { get; }
        public string disc_year {get; }
        public string pl_orbper {get; }
        public string pl_rade {get; }
        public string pl_masse {get; }
        public string pl_eqt {get; }


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