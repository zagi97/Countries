using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace RestCountries
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader oSr = new StreamReader("countries.json");
            string sJson = "";
            using (oSr)
            {
                sJson = oSr.ReadToEnd();
            }
            JObject oJson = JObject.Parse(sJson);
            var oCountries = oJson["countries"].ToList();
            List<country> lCountry = new List<country>();

            for (int i=0; i< oCountries.Count; i++)
            {
                lCountry.Add(new country
                { 
                
                    sCode = (string)oCountries[i]["alpha3Code"],
                    sName = (string)oCountries[i]["name"],
                    sCapital = (string)oCountries[i]["capital"],
                    nPopulation = (int)oCountries[i]["population"],
                    fArea = (float)oCountries[i]["area"],
                });
            }

            for(int i=0; i<oCountries.Count();i++)
            {
                Console.WriteLine(lCountry[i].sCode + " " + lCountry[i].sName);
            }
            Console.WriteLine("-----------------------------------------");
            var OrderByQuery = from c in lCountry.OrderByDescending(o => o.nPopulation) select c;
            List<country> lSortedCountry = OrderByQuery.ToList();
            for(int i= 0; i< lSortedCountry.Count; i++)
            {
                Console.WriteLine(lSortedCountry[i].nPopulation +" " +lSortedCountry[i].sName + " " + lSortedCountry[i].sCapital);
            }
            Console.ReadKey();
        }
    }
}
