using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stratego.Game;

namespace Stratego.Game.Test
{
    [TestClass]
    public class UnitGame
    {
        [TestMethod]
        public void InitGame()
        {
            var playerGuid1 = Guid.NewGuid();
            var playerGuid2 = Guid.NewGuid();

            var game = new StrategoGame();
            if(!game.AddPlayer(playerGuid1)) Assert.Fail("Can't add player.");
            if(!game.AddPlayer(playerGuid2)) Assert.Fail("Can't add player.");

            Assert.AreEqual(true, game.IsActive);
            Assert.AreEqual(true, game.IsReady);
        }

        // ===================================================================================
        // Ablauf testen
        // ===================================================================================

        StrategoGame game;
        StrategoBench bench;
        Guid playerOne;
        Guid playerTwo;

        [TestInitialize]
        public void Init()
        {
            game = new StrategoGame();
            playerOne = Guid.NewGuid();
            playerTwo = Guid.NewGuid();
        }

        [TestMethod]
        public void GameCheckReadyEvent()
        {
            game.Ready += (sender, e) =>
            {
                Assert.AreNotEqual(sender, null);
            };

            game.AddPlayer(playerOne);
            game.AddPlayer(playerTwo);
        }

        [TestMethod]
        public void InitBoardBench()
        {
            GameCheckReadyEvent();

            bench = game.Bench;
            
            var classic = new StrategoModeClassic();
            

            var pawn1 = classic.GetUnit(playerOne, "PAWN_FLAG");
            

            
        }

        [TestMethod]
        public void PlacingPawns()
        {
            InitBoardBench();

            //var result = bench.PlaceUnit(pawn1, new Montana.Position(1, 1));

            //Assert.AreEqual(true, result);
        }
    }
}
