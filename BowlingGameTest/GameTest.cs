using BowlingGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGameTest
{
    [TestClass]
    public class GameTest
    {

        #region Startup

        // This region is created so I don't have to
        // repeat the same line for every test

        private Game g;
        // initialize a new game
        [TestInitialize]
        public void Initialize()
        {
            g = new Game();
        }

        [TestCleanup]
        public void Cleanup()
        {
            g = null;
        }
        #endregion

        #region 1st test
        [TestMethod]
        public void TestGutterGame()
        {
            // The startup region (line 10) helps me to not
            // repeat this following line of code for every test.
            
            // Game g = new Game();

            // The RollMany method (line 62) replaces the original code, to simplify the code below.
            // The method also makes sure that there's no need to repeat the full for-loop for every test. 

            // for(int i = 0; i < rolls; i++)
            // {
            //     g.Roll(pins);
            // }

            RollMany(20, 0);

            Assert.AreEqual(0, g.Score());
        }
        #endregion

        #region 2nd test
        [TestMethod]
        public void TestAllOnes()
        {
            RollMany(20, 1);
 
            Assert.AreEqual(20, g.Score());
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                g.Roll(pins);
            }
        }
        #endregion
        
        #region 3rd test
        
        [TestMethod]
        public void TestOneSpare()
        {
            RollSpare();
            g.Roll(3);
            RollMany(17, 0);
            
            Assert.AreEqual(16, g.Score());
        }

        private void RollSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }
        #endregion

        #region 4th test
        
        [TestMethod]
        public void TestOneStrike()
        {
            RollStrike();
            g.Roll(3);
            g.Roll(4);
            RollMany(16, 0);
            Assert.AreEqual(24, g.Score());
        }

        private void RollStrike()
        {
            g.Roll(10);
        }
        #endregion

        #region 5th test
        [TestMethod]
        public void TestPerfectGame()
        {
            RollMany(12, 10);

            Assert.AreEqual(300, g.Score());
        }
        #endregion
    }
}