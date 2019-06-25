using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGame
{
    [Serializable]
    public class Worker : People
    {
        public int Performance { get; }
        

        public Worker(string name)
        {
            Name = name;
            Performance = Game.random.Next(5);
        }

        public override string ToString()
        {
            return $"Имя: {Name}, Производительность: {Performance}";
        }
    }
}
