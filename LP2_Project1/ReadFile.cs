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

        private List<Planets> planets = new List<Planets>();

        

        public ReadFile(string filename)
        {
            this.filename = filename;
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
                if (line[0] == '#'){}
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
                    planets.Add(new Planets(colums[pl_name], colums[hostname],
                        colums[discoverymethod], colums[disc_year], colums[pl_orbper], 
                        colums[pl_rade], colums[pl_masse], colums[pl_eqt], 
                        colums[st_teff], colums[st_rad], colums[st_mass],
                        colums[st_age] ,colums[st_vsin] ,colums[st_rotp], colums[sy_dist]));
                }
            }
            foreach(Planets a in planets)
            {
                Console.WriteLine(a.st_mass);
            }
        }
    }
}