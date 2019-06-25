using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGame
{
    [Serializable]
    public class Tank
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
            Power = Game.random.Next(50,100) + forceOfSoldiers;           
        }

        public override string ToString()
        {
            return $"Танк №{SerialNumber}, Мощность: {Power}";
        }
    }
}
