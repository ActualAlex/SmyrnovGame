using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGame
{
    class Tank
    {
        int SerialNumber { get; }
        public int Power { get; }
        Soldier[] Soldiers { get;}

        public Tank(int serialNumber, Soldier[] soldiers)
        {
            SerialNumber = serialNumber;
            Soldiers = soldiers;
            int forceOfSoldiers = 0;
            foreach (Soldier s in soldiers)
                forceOfSoldiers += s.Force;
            Power = new Random().Next(50,100) + forceOfSoldiers;           
        }
    }
}
