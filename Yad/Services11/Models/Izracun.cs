using System;
using System.Collections.Generic;

using databaseLayerProject.Models.Mock;

namespace serviceSloj.Models
{
    public static class Izracun
    {
        public static int izracunaj(int cijena,int popust)
        {
            return cijena - popust;
        }

        public static double porez(double s)
        {
            return s * 0.75;
        }

        public static double Profit(List<Narudzbe> nar)
        {
            double sum = 0;
           foreach (var narudzba in nar)
            {
                sum = sum + narudzba.cijena;
            }
            var rezultat = porez(sum);
            return rezultat;
        }
    }
}