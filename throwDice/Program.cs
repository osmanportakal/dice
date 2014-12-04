using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace throwDice
{
    class Program
    {
        static void Main(string[] args)
        {
            Dice dice = new Dice();
            dice.createDice();
        }
    }
}
