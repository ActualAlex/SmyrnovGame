using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGame
{
    static class Accident
    {
        private static MilitaryBase mb;
        public static void TryGetSomeAccident(Object m, EventArgs e)
        {

            if ( m is MilitaryBase)
            {
                mb = (MilitaryBase)m;
                switch (Game.random.Next(30))
                {
                    case 1:
                        Console.WriteLine("Произошел взрыв на шахте!!!Мы потеряли 20% золота!!!");
                        mb.Gold -= ((mb.Gold * 20) / 100);
                        break;
                    case 2:
                        Console.WriteLine("На складе с провизией появились крысы!!! Пропало 10% нашей еды!!!");
                        mb.Food -= ((mb.Food * 10) / 100);
                        break;
                }
            }
        }  
    }
}
