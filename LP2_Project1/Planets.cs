using System;
using System.Collections.Generic;
using System.Collections;
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
        public string st_teff {get; }
        public string st_rad {get; }
        public string st_mass {get; }
        public string st_age {get; }
        public string st_vsin {get; }
        public string st_rotp {get; }
        public string sy_dist {get; }

        public Planets(string pl_name, string hostname, string discoverymethod,
            string disc_year, string pl_orbper, string pl_rade, string pl_masse, 
            string pl_eqt, string st_teff, string st_rad, string st_mass,
            string st_age, string st_vsin, string st_rotp, string sy_dist)
        {
            this.pl_name = pl_name;
            this.hostname = hostname;
            this.discoverymethod = discoverymethod;
            this.disc_year = disc_year;
            this.pl_orbper = pl_orbper;
            this.pl_rade = pl_rade;
            this.pl_masse = pl_masse;
            this.pl_eqt = pl_eqt;
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