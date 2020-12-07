using System;
using System.Collections.Generic;
namespace LP2_Project1
{
    public class StarComparer : IEqualityComparer<Stars>
    {
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
        }
    }
}