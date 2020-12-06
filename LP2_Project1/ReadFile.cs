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
            int pl_name =0, hostname=0, discoverymethod=0 , disc_year=0 , pl_orbper=0, pl_rade=0 , pl_masse =0, pl_eqt=0,
                st_teff=0 , st_rad=0 , st_mass=0, st_vsin=0 , st_rotp=0 , sy_dist=0, st_age=0;
            string path  = Path.Combine(Environment.CurrentDirectory, filename);
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach(string line in lines)
            {
                if (String.IsNullOrEmpty(line)){}
                else if (line[0] == '#')
                {

                }
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
                    planets.Add(new Planets(colums[pl_name].ToLower().Trim(), colums[hostname].ToLower().Trim(),
                        colums[discoverymethod].ToLower().Trim(), colums[disc_year].ToLower().Trim(), colums[pl_orbper].ToLower().Trim(), 
                        colums[pl_rade].ToLower().Trim(), colums[pl_masse].ToLower().Trim(), colums[pl_eqt].Trim()));
                }
            }
            
        }

    }
}