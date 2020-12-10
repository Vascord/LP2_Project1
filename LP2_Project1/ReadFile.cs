using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;

namespace LP2_Project1 
{
    /// <summary>
    /// </summary>
    public class ReadFile
    {
        private string filename;
        private bool firstLine;
        private bool columnError;
        private bool minInfoError;
        private bool incorrectTypeError;

        public List<Planets> planets;

        public List<Stars> stars;

        /// <summary>
        /// </summary>
        /// <value></value>
        public IEnumerable<Stars> s {get; set;}
        /// <summary>
        /// </summary>
        /// <value></value>
        public IEnumerable<Stars> s2 {get; set;}
        /// <summary>
        /// </summary>
        /// <value></value>
        public IEnumerable<Planets> p {get; set;}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        public ReadFile(string filename)
        {
            this.filename = filename;
            planets = new List<Planets>();
            stars = new List<Stars>();

            firstLine = true;
            columnError = false;
            minInfoError = false;
            incorrectTypeError = false;
            File();
        }
        /// <summary>
        /// 
        /// </summary>
        private void File()
        {
            int? pl_name = null, hostname = null, discoverymethod= null, 
                disc_year= null, pl_orbper= null, pl_rade = null, 
                pl_masse = null, pl_eqt= null,st_teff = null, st_rad = null, 
                st_mass= null, st_vsin = null, st_rotp = null, sy_dist= null, 
                st_age=null;

            int columnNr = 0;
            string[] FirstLineColumns;
            string[] colums;
            string[] nr;
            float temp;
            string[] lines = null;

            string path = path  = Path.Combine(Environment.CurrentDirectory, 
                filename);
            try
            {                
                lines = System.IO.File.ReadAllLines(path);
            }
            catch(FileNotFoundException)
            {
                try
                {
                    lines = System.IO.File.ReadAllLines(filename);
                }
                catch(FileNotFoundException)
                {
                    Console.WriteLine("\nFile Not Found:");
                    Console.WriteLine(path);
                    Environment.Exit(0);
                }
                
            }

            IEnumerable<string> lowerNames = lines.Select(l => l.ToLower());

            foreach(string line in lowerNames)
            {
                if (String.IsNullOrEmpty(line)){}
                else if (line[0] == '#'){}
                else if (firstLine)
                {
                    FirstLineColumns = line.Split(',');
                    columnNr = FirstLineColumns.Length;
                    for (int i = 0; i < FirstLineColumns.Length; i++)
                    {
                        //Detects the positions of the fields
                        switch(FirstLineColumns[i].Trim())
                        {
                            case "pl_name":
                                pl_name = i;
                                break;
                            case "hostname":
                                hostname = i;
                                break;
                            case "discoverymethod":
                                discoverymethod = i;
                                break;
                            case "disc_year":
                                disc_year = i;
                                break;
                            case "pl_orbper":
                                pl_orbper = i;
                                break;
                            case "pl_rade":
                                pl_rade = i;
                                break;
                            case "pl_masse":
                                pl_masse = i;
                                break;
                            case "pl_eqt":
                                pl_eqt = i;
                                break;
                            case "st_teff":
                                st_teff = i;
                                break;
                            case "st_rad":
                                st_rad = i;
                                break;
                            case "st_mass":
                                st_mass = i;
                                break;
                            case "st_age":
                                st_age = i;
                                break;
                            case "st_vsin":
                                st_vsin = i;
                                break;
                            case "st_rotp":
                                st_rotp = i;
                                break;
                            case "sy_dist":
                                sy_dist = i;
                                break;
                        }
                    }
                    firstLine = false;
                }
                else
                {
                    colums = line.Split(',');

                    //Used for verification of fille possible errors and to 
                    //fill planets.cs and stars.cs
                    nr = new string[] {st_teff == null ? null : 
                        colums[st_teff.GetValueOrDefault()].Trim(), 
                        st_rad == null ? null : 
                            colums[st_rad.GetValueOrDefault()].Trim(), 
                        st_mass == null ? null : 
                            colums[st_mass.GetValueOrDefault()].Trim(), 
                        st_age == null ? null : 
                            colums[st_age.GetValueOrDefault()].Trim(), 
                        st_vsin == null ? null : 
                            colums[st_vsin.GetValueOrDefault()].Trim(), 
                        st_rotp == null ? null : 
                            colums[st_rotp.GetValueOrDefault()].Trim(),
                        sy_dist == null ? null : 
                            colums[sy_dist.GetValueOrDefault()].Trim(), 
                        disc_year == null ? null : 
                            colums[disc_year.GetValueOrDefault()].Trim(),
                        pl_orbper == null ? null : 
                            colums[pl_orbper.GetValueOrDefault()].Trim(), 
                        pl_rade == null ? null : 
                            colums[pl_rade.GetValueOrDefault()].Trim(),
                        pl_masse == null ? null : 
                            colums[pl_masse.GetValueOrDefault()].Trim(), 
                        pl_eqt == null ? null : 
                            colums[pl_eqt.GetValueOrDefault()].Trim()};

                    //Verification of fille possible errors
                    if (colums.Length != columnNr)
                        columnError = true;
                    if(hostname == null && pl_name == null)
                        minInfoError = true;
                    foreach(string s in nr)
                    {
                        if (String.IsNullOrEmpty(s) == false && 
                            float.TryParse(s, out temp) == false)
                            incorrectTypeError = true;
                        if(String.IsNullOrEmpty(pl_name == null ? null : 
                        colums[pl_name.GetValueOrDefault()].Trim()))
                            minInfoError = true;
                        if(String.IsNullOrEmpty(hostname == null ? null : 
                        colums[hostname.GetValueOrDefault()].Trim()))
                            minInfoError = true;
                    }

                    //planets list completion
                    planets.Add(new Planets(pl_name == null ? null : 
                        colums[pl_name.GetValueOrDefault()].Trim(), 
                        hostname == null ? null : 
                        colums[hostname.GetValueOrDefault()].Trim(), 
                        discoverymethod == null ? null : 
                        colums[discoverymethod.GetValueOrDefault()].Trim(), 
                        nr[7], nr[8], nr[9], nr[10], nr[11])); 

                    //stars list completion
                    stars.Add(new Stars(hostname == null ? null : 
                        colums[hostname.GetValueOrDefault()].Trim(), 
                        nr[0], nr[1], nr[2], nr[3], nr[4], nr[5], nr[6], null));
                }
            }
            // If there is a error in the file calls FilleErrorsOutput()
            if(columnError || minInfoError || incorrectTypeError) 
                FileErrorsOutput();

            FillIEnumerables();           
        }

        /// <summary>
        /// 
        /// </summary>
        private void FillIEnumerables()
        {
            //Assigns the correct lists to the IEnumerables
            s = stars;
            p = planets;
            s2 = stars;

            // Removes duplicates from s
            s = s.Distinct(new StarComparer());

            //Gathers iformation from duplicate stars in s2 and fills in stars 
            // in s with extra information
            foreach(Stars st in s)
            {
                int count = 0;
                // Counts the number of planets that orbit the star
                foreach(Planets pl in p.Where(l => l.hostname == st.st_name))
                {
                    count++;
                }
                st.st_pls = Convert.ToString(count);
                foreach(Stars st2 in s2.Where(l => l.st_name == st.st_name))
                {
                    if (!String.IsNullOrEmpty(st2.st_teff))
                        st.st_teff = st2.st_teff;
                    if (!String.IsNullOrEmpty(st2.st_rad))
                        st.st_rad = st2.st_rad;
                    if (!String.IsNullOrEmpty(st2.st_mass))
                        st.st_mass = st2.st_mass;
                    if (!String.IsNullOrEmpty(st2.st_age))
                        st.st_age = st2.st_age;
                    if (!String.IsNullOrEmpty(st2.st_vsin))
                        st.st_vsin = st2.st_vsin;
                    if (!String.IsNullOrEmpty(st2.st_rotp))
                        st.st_rotp = st2.st_rotp;
                    if (!String.IsNullOrEmpty(st2.sy_dist))
                        st.sy_dist = st2.sy_dist;
                }
            } 
        }

        /// <summary>
        /// 
        /// </summary>
        private void FileErrorsOutput()
        {
            Console.WriteLine("\nFile ({0}) has an error:", filename);

            if(columnError)
            Console.WriteLine("- Number of columns of a line" +
                " does not correspond to the number of fields of the file");
            if(minInfoError)
                Console.WriteLine("- File does not have the minimum fields required");
            if(incorrectTypeError)
                Console.WriteLine("- File contains fields with incorrect types");
            
            Environment.Exit(0);
        }
    }
}