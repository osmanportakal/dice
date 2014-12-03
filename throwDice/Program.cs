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
            Dice dice1 = new Dice();
            Dice dice2 = new Dice();

            Dice testOne = new Dice();
            Random random = new Random();
            int roll1 = random.Next(1, 7);
            int roll2 = random.Next(1, 7);
            dice1.num = roll1;
            dice2.num = roll2;

            dice1.initClientConnection();
            dice2.initClientConnection();
            dice1.createDice();
            dice2.createDice();

        }

       
    }

  
}
