using System;
using System.Collections.Generic;

namespace CowboyCafe.Data
{
    public abstract class Entree
    {
        public abstract double Price { get; }

        public abstract uint Calories { get; }

        public abstract List<string> SpecialInstructions { get; }

    }
}
