using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using throwDice;
using Neo4jClient;

namespace DiceTest
{
    [TestClass]
    public class UnitTest1
    {

        Dice dice = new Dice();


        [TestMethod]
        public void TestDiceNumbers()
        {
            if (dice.num < 0 && dice.num > 7)
            {
                Assert.Fail("Dicenumber incorrect");
            }

            if (dice.randomID < 0 && dice.randomID > 700)
            {
                Assert.Fail("Dice ID incorrect");
            }
        }

        [TestMethod]
        public void TestNode()
        {
          
            dice.initClientConnection();
            dice.createDice();

            var nodeResult =
            dice.client.Cypher
                .Match("(d:Dice)")
                .Where((Dice d) => d.randomID == dice.randomID)
                .Return(d => d.As<Dice>())
                .Results;

            foreach (Dice d in nodeResult) {
                if (d.randomID != dice.randomID)
                {
                    Assert.Fail("Node not created");
                }
            }
        }
    }
}
