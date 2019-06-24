using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGame
{
    class SoldiersDeficitException : Exception
    {

        public override string Message
        {
            get { return "Не хватает солдат"; }
        }
    }
}
