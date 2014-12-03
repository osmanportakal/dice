using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace throwDice
{
    class Dice
    {
        private GraphClient client;
        
       
        public int num { get; set; }

        public void initClientConnection()
        {
            try
            {
                if (this.client != null)
                {
                    return;
                }

                this.client = new GraphClient(new Uri("http://localhost:7474/db/data"));
                this.client.Connect();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not make connection to database, check if database server is on and try again.");
            }
        }

        public void createDice()
        {
            Console.Write(this.num);

            this.client.Cypher
                .Create("(dice:Dice {num:" + this.num + "})")
                .WithParam("Num", this.num)
                .ExecuteWithoutResults();
        }


    }
}
