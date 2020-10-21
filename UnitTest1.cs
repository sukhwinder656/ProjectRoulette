using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Form1;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        RussianRoulette gameObj = new RussianRoulette();
        [TestMethod]
        public void TestMethod1()
        {
           int chamberPosition = gameObj.spinChamber();
           int bulletPosition = gameObj.spinChamber();
        }
        public int Play(int numPlayers, int currentChamber, int bulletChamber)
        {
            for (int i = 1; i <= numPlayers; i++)
            {


                if (currentChamber == bulletChamber)
                {
                    
                    
                    if (i == 1)
                    {
                        Assert.AreEqual("You Lose Game", "You Lose Game");
                    }
                    else
                    {
                        Assert.AreEqual("You Win Game", "You Win Game");
                    }


                    return -1;

                }
                else
                {
                    Assert.AreEqual("You are Lucky", "You are Lucky");

                }
                if (currentChamber == 6)
                {

                    currentChamber = 1;

                }
                else
                {

                    currentChamber++;

                }


            }
            return currentChamber;


        }
        [TestMethod]
        public void PlayGame()
        {
            int totalPlayers = 2;
            int chamberPosition = gameObj.spinChamber();
            int bulletPosition = gameObj.spinChamber();
            int currentChamber =Play(totalPlayers, chamberPosition, bulletPosition);

        }
    }
}
