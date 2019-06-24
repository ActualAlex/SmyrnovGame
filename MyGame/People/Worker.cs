using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGame
{
    public class Worker : People
    {
        public int Performance { get; }
        

        public Worker(string name)
        {
            Name = name;
            Performance = random.Next(1,5);
        }

        public override string ToString()
        {
            return $"Имя: {Name}, Производительность: {Performance}";
        }
    }
}
