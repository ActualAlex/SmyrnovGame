using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGame
{
    class War
    {
        MilitaryBase mb1;
        MilitaryBase mb2;

        public War(MilitaryBase mb1, MilitaryBase mb2)
        {
            this.mb1 = mb1;
            this.mb2 = mb2;
        }

        public void FindWinner()
        {
            int forceSoildersMb1 = 0;
            int forceSoildersMb2 = 0;

            foreach (Soldier s in mb1.Soldiers)
                forceSoildersMb1 += s.Force;

            foreach (Tank t in mb1.Tanks)
                forceSoildersMb1 += t.Power;

            foreach (Soldier s in mb2.Soldiers)
                forceSoildersMb2 += s.Force;

            foreach (Tank t in mb2.Tanks)
                forceSoildersMb2 += t.Power;

            Console.WriteLine("Победитель: " + (forceSoildersMb1 > forceSoildersMb2 ? mb1.Name : mb2.Name));
            Console.WriteLine($"Общаяя сила войск {forceSoildersMb1} против {forceSoildersMb2}");

        }

    }
}
