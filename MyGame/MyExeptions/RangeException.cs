using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGame
{
    class RangeException : Exception
    {
        public override string Message
        {
            get { return "Выход за диапозон значения"; }
        }
    }
}
