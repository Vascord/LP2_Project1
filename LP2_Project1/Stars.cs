using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace LP2_Project1
{
    public class Stars
    {
        public string st_name {get; }
        public string st_teff {get; }
        public string st_rad {get; }
        public string st_mass {get; }
        public string st_age {get; }
        public string st_vsin {get; }
        public string st_rotp {get; }
        public string sy_dist {get; }

        public Stars(string st_name, string st_teff, string st_rad, string st_mass,
            string st_age, string st_vsin, string st_rotp, string sy_dist)
        {
            this.st_name = st_name;
            this.st_teff = st_teff;
            this.st_rad = st_rad;
            this.st_age = st_age;
            this.st_vsin = st_vsin;
            this.st_rotp = st_rotp;
            this.sy_dist = sy_dist;
            this.st_mass = st_mass;

        }

        /*
        public bool Equals(Stars x, Stars y)
        {

            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the products' properties are equal.
            return x.st_name == y.st_name;
        }

        public int GetHashCode(Stars product)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(product, null)) return 0;

            //Get hash code for the Name field if it is not null.
            int hashProductName = product.st_name == null ? 0 : product.st_name.GetHashCode();

            //Calculate the hash code for the product.
            return hashProductName;
        }*/
    }
}