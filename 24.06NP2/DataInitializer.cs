using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24._06NP2
{
    class DataInitializer : DropCreateDatabaseAlways<StreetContext>
    {
        protected override void Seed(StreetContext context)
        {
            List<Street> streets = new List<Street>
            {
                new Street
                {
                   Name = "Beybitshilik",
                   PostIndex = "000000"
                },
                new Street
                {
                   Name = "Imanova",
                   PostIndex = "000000"
                },
                new Street
                {
                   Name = "Kunaeva",
                   PostIndex = "000000"
                },
                new Street
                {
                   Name = "Sauran",
                   PostIndex = "000000"
                },
                new Street
                {
                   Name = "Pushkin",
                   PostIndex = "111111"
                },
                new Street
                {
                   Name = "Abay",
                   PostIndex = "111111"
                },
                new Street
                {
                   Name = "Kerey and Zhanibek",
                   PostIndex = "111111"
                }
            };
            context.Streets.AddRange(streets);
            base.Seed(context);
        }
    }
}