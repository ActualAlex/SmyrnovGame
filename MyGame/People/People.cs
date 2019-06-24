using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGame
{
    public abstract class People
    {
        public string Name { get; protected set; }
        public static Random random = new Random();

    }
}
