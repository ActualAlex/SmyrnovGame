using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGame
{
    class Program
    {
        static void Main(string[] args)
        {
            City city = new City("Kiev");
            Info.Rule(city);
            for (int i = 0; i < 6; i++)
            {
                city.SetSoldiersAndWorkers();
                city.MineGoldAndFood();
                city.MakeTanks();
                city.PeopleEat();
                // Info.WriteListOfSoldiers(city);
                // Info.WriteListOfWorkers(city);
                Info.WriteAllInfoCity(city);
                city.CountOfMonth++;
            }
        }
    }
}
