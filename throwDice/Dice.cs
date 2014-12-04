using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace throwDice
{
    public class Dice
    {
        public GraphClient client;
        Random random = new Random();
        public int num { get; set; }
        public int randomID { get; set; }

        public void initClientConnection()
        {
            try
            {
                client = new GraphClient(new Uri("http://localhost:7474/db/data"));
                client.Connect();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not make connection to database, check if database server is on and try again.");
            }
        }

        public void createDice()
        {
            initClientConnection();
            num = random.Next(1, 7);
            randomID = random.Next(1, 700);
            client.Cypher
                .Create("(dice:Dice {num:" + num + ", randomID:" + randomID + "})")
                .WithParam("Num", num)
                .ExecuteWithoutResults();
        }

    }
}
