using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;
using System.Xml.Serialization;

namespace MyGame
{
    [Serializable]
    class MilitaryBase
    {
        
        public string Name { get; set; }

        public int CountOfMonth { get; set; } = 1;
        public int CountOfPeople { get; set; }
        public int DeadPeople { get; set; }
        public int NewPeople { get; set; }
        public int Gold { get;set; }
        public int Food { get; set; }

        public int NewGold { get; set; }
        public int NewFood { get; set; }

        public int SpentGold { get; set; } 
        public int SpentFood { get; set; }

        public List<Tank> Tanks { get; } = new List<Tank>();
        public List<Soldier> Soldiers { get; } = new List<Soldier>();
        public List<Worker> Workers { get; } = new List<Worker>();

        public MilitaryBase()
        {
            Gold = 100;
            Food = 100;
            for (int i = 1; i <= 100; i++)             
                Workers.Add(new Worker("Рабочий_" + i));
        }
    }
}
