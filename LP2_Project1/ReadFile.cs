using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LP2_Project1 
{
    public class ReadFile
    {
        private string filename;
        private bool firstLine = true;

        public List<Planets> planets {get;}
        public List<Stars> stars {get;}

        public ReadFile(string filename)
        {
            this.filename = filename;
            planets = new List<Planets>();
            stars = new List<Stars>();
            File();
        }
        private void File()
        {
            int? pl_name = null, hostname = null, discoverymethod= null, disc_year= null, pl_orbper= null, pl_rade = null, pl_masse = null, pl_eqt= null,
                st_teff = null, st_rad = null, st_mass= null, st_vsin = null, st_rotp = null, sy_dist= null, st_age=null;
            string path  = Path.Combine(Environment.CurrentDirectory, filename);
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach(string line in lines)
            {
                if (String.IsNullOrEmpty(line)){}
                else if (line[0] == '#'){}
                else if (firstLine)
                {
                    string[] colums = line.Split(',');
                    for (int i = 0; i < colums.Length; i++)
                    {
                        
                        switch(colums[i].Trim())
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
                    foreach(string s in colums)
                    {
                        s.ToLower().Trim();
                    }
                    planets.Add(new Planets(pl_name == null ? null : colums[pl_name.GetValueOrDefault()].ToLower().Trim(), 
                        hostname == null ? null : colums[hostname.GetValueOrDefault()].ToLower().Trim(),
                        discoverymethod == null ? null : colums[discoverymethod.GetValueOrDefault()].ToLower().Trim(), 
                        disc_year == null ? null : colums[disc_year.GetValueOrDefault()].ToLower().Trim(), 
                        pl_orbper == null ? null : colums[pl_orbper.GetValueOrDefault()].ToLower().Trim(), 
                        pl_rade == null ? null : colums[pl_rade.GetValueOrDefault()].ToLower().Trim(), 
                        pl_masse == null ? null : colums[pl_masse.GetValueOrDefault()].ToLower().Trim(), 
                        pl_eqt == null ? null : colums[pl_eqt.GetValueOrDefault()].ToLower().Trim()));
                }
            }           
        }
        private float? ToNullableFloat(string s)
        {
            float i;
            if (float.TryParse(s, out i)) return i;
            return null;
        }

    }
}