using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGame
{
    [Serializable]
    public abstract class People
    {
        public string Name { get; protected set; }
    }
}
