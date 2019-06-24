using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGame
{
    public class Soldier : People
    {
        public int Force { get; }
        

        public Soldier(string name)
        {
            Name = name;
            Force = random.Next(50,100);
        }

        public override string ToString()
        {
            return $"Имя: {Name}, Сила: {Force}";
        }
    }
}
