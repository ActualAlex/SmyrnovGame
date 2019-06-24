using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGame
{
    class Accident
    {
        City city;
        Random random = new Random();
        
        public Accident(City city)
        {
            this.city = city;
            switch (random.Next(0, 5))
            {
                case 1:
                    MiningBlast();
                    break;
                case 2:
                    LongRains();
                    break;
                case 3:
                    Sabotage();
                    break;
            }
        }
       
        public void MiningBlast()
        {
            Console.WriteLine("Произошел взрыв на шахте!!! Погибли 10 рабочих! Мы потеряли 20% золота!!!");
            city.Gold -= ((city.Gold * 20) / 100);
            city.Workers.RemoveRange(0,10);
        }

        public void LongRains()
        {
            Console.WriteLine("На складе с провизией появились крысы!!! Пропало 10% нашей еды!!!");
            city.Food -= ((city.Food * 10) / 100);
        }

        public void Sabotage()
        {
            Console.WriteLine("Шпионы взорвали наши танки!!! Мы уничтожили противника, но потеряли 2 танка и 5 солдат");
            city.Soldiers.RemoveRange(0, 5);
            city.Tanks.RemoveRange(0, 2);
        }
    }
}
