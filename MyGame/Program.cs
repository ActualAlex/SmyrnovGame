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
            MilitaryBase myBase;
            MilitaryBase enemy;
            War war;

            int newOrOld = Game.NewOrOldGame();

            switch (newOrOld)
            {
                case 1:
                    Console.WriteLine("Введите название вашей военной базы");
                    myBase = new MilitaryBase(Console.ReadLine());
                    enemy = Game.AutoCreateBase();
                    Game.CreateArmy(myBase);
                    war = new War(myBase, enemy);
                    war.FindWinner();
                    break;
                case 2:
                    myBase = Game.LoadGame();
                    enemy = Game.AutoCreateBase();
                    Game.CreateArmy(myBase);
                    war = new War(myBase, enemy);
                    war.FindWinner();
                    break;
            }
        }
    }
}
