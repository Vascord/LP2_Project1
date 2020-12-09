using System;
using System.Collections.Generic;
namespace LP2_Project1
{
    /// <summary>
    /// Class whose objective is to be used LINQ Distinct method, so it can
    /// remove stars with the same name
    /// </summary>
    public class StarComparer : IEqualityComparer<Stars>
    {
        /// <summary>
        /// Public method which compare the names of 2 given stars
        /// </summary>
        /// <param name="x">First star with his data</param>
        /// <param name="y">Second star with his data</param>
        /// <return> Returns true if the name of the stars are equal and 
        /// false if they are not </return>
        public bool Equals(Stars x, Stars y)
        {

            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || 
            Object.ReferenceEquals(y, null))
                return false;

            //Check whether the products' properties are equal.
            return x.st_name == y.st_name;
        }

        /// <summary>
        /// Public method to obtain the hash code of a star
        /// </summary>
        /// <param name="star">Star with his data</param>
        /// <return> The hash code of the star </return>
        public int GetHashCode(Stars star)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(star, null)) return 0;

            //Get hash code for the Name field if it is not null.
            int hashStarName = star.st_name == null ? 0 : 
                star.st_name.GetHashCode();

            //Calculate the hash code for the star.
            return hashStarName;
        }
    }
}