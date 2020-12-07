using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;

namespace LP2_Project1 
{
    public class ReadFile
    {
        private string filename;
        private bool firstLine;
        private bool columnError;
        private bool minInfoError;
        private bool incorrectTypeError;

        public List<Planets> planets;

        public List<Stars> stars;

        public IEnumerable<Stars> s {get; set;}
        public IEnumerable<Stars> s2 {get; set;}
        public IEnumerable<Planets> p {get; set;}

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
        private void File()
        {
            int? pl_name = null, hostname = null, discoverymethod= null, disc_year= null, pl_orbper= null, pl_rade = null, pl_masse = null, pl_eqt= null,
                st_teff = null, st_rad = null, st_mass= null, st_vsin = null, st_rotp = null, sy_dist= null, st_age=null;

            int columnNr = 0;

            

            string path  = Path.Combine(Environment.CurrentDirectory, filename);
            string[] lines = System.IO.File.ReadAllLines(path);

            IEnumerable<string> lowerNames = lines.Select(l => l.ToLower());

            foreach(string line in lowerNames)
            {
                if (String.IsNullOrEmpty(line)){}
                else if (line[0] == '#'){}
                else if (firstLine)
                {
                    string[] FirstLineColumns = line.Split(',');
                    columnNr = FirstLineColumns.Length;
                    for (int i = 0; i < FirstLineColumns.Length; i++)
                    {
                        
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
                    string[] colums = line.Split(',');

                    if (colums.Length != columnNr)
                        columnError = true;
                    if(hostname == null && pl_name == null)
                        minInfoError = true;

                    
                    planets.Add(new Planets(pl_name == null ? null : colums[pl_name.GetValueOrDefault()].Trim(), 
                        hostname == null ? null : colums[hostname.GetValueOrDefault()].Trim(), 
                        discoverymethod == null ? null : colums[discoverymethod.GetValueOrDefault()].Trim(), 
                        disc_year == null ? null : colums[disc_year.GetValueOrDefault()].Trim(), 
                        pl_orbper == null ? null : colums[pl_orbper.GetValueOrDefault()].Trim(), 
                        pl_rade == null ? null : colums[pl_rade.GetValueOrDefault()].Trim(), 
                        pl_masse == null ? null : colums[pl_masse.GetValueOrDefault()].Trim(), 
                        pl_eqt == null ? null : colums[pl_eqt.GetValueOrDefault()].Trim())); 

                    stars.Add(new Stars(hostname == null ? null : colums[hostname.GetValueOrDefault()].Trim(), 
                        st_teff == null ? null : colums[st_teff.GetValueOrDefault()].Trim(),
                        st_rad == null ? null : colums[st_rad.GetValueOrDefault()].Trim(), 
                        st_mass == null ? null : colums[st_mass.GetValueOrDefault()].Trim(), 
                        st_age == null ? null : colums[st_age.GetValueOrDefault()].Trim(), 
                        st_vsin == null ? null : colums[st_vsin.GetValueOrDefault()].Trim(), 
                        st_rotp == null ? null : colums[st_rotp.GetValueOrDefault()].Trim(), 
                        sy_dist == null ? null : colums[sy_dist.GetValueOrDefault()].Trim(),
                        null));
                }
            }

            foreach(Stars st in stars)
            { 
                float x;
                if (String.IsNullOrEmpty(st.st_teff) == false && float.TryParse(st.st_teff, out x) == false)
                    incorrectTypeError = true;
                if (String.IsNullOrEmpty(st.st_rad) == false && float.TryParse(st.st_rad, out x) == false)
                    incorrectTypeError = true;
                if (String.IsNullOrEmpty(st.st_mass) == false && float.TryParse(st.st_mass, out x) == false)
                    incorrectTypeError = true;
                if (String.IsNullOrEmpty(st.st_age) == false && float.TryParse(st.st_age, out x) == false)
                    incorrectTypeError = true;
                if (String.IsNullOrEmpty(st.st_rotp) == false && float.TryParse(st.st_rotp, out x) == false)
                    incorrectTypeError = true;
                if (String.IsNullOrEmpty(st.st_vsin) == false && float.TryParse(st.st_vsin, out x) == false)
                    incorrectTypeError = true;
                if (String.IsNullOrEmpty(st.sy_dist) == false && float.TryParse(st.sy_dist, out x) == false)
                    incorrectTypeError = true;
            }

            foreach(Planets pl in planets)
            { 
                float x;
                if (String.IsNullOrEmpty(pl.disc_year) == false && float.TryParse(pl.disc_year, out x) == false)
                    incorrectTypeError = true;
                if (String.IsNullOrEmpty(pl.pl_orbper) == false && float.TryParse(pl.pl_orbper, out x) == false)
                    incorrectTypeError = true;
                if (String.IsNullOrEmpty(pl.pl_rade) == false && float.TryParse(pl.pl_rade, out x) == false)
                    incorrectTypeError = true;
                if (String.IsNullOrEmpty(pl.pl_masse) == false && float.TryParse(pl.pl_masse, out x) == false)
                    incorrectTypeError = true;
                if (String.IsNullOrEmpty(pl.pl_eqt) == false && float.TryParse(pl.pl_eqt, out x) == false)
                    incorrectTypeError = true;
            }

            if(columnError || minInfoError || incorrectTypeError)
                FileErrorsOutput();
            
            s = stars;
            p = planets;
            s2 = stars;

            s = s.Distinct(new StarComparer());

            foreach(Stars st in s)
            {
                int count = 0;
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