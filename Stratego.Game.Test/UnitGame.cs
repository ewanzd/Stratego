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

        StrategoGame game;

        [TestInitialize]
        public void Init()
        {
            game = new StrategoGame();
        }

        [TestMethod]
        public void GameCheckReadyEvent()
        {
            game.Ready += (sender, e) =>
            {
                Assert.AreNotEqual(sender, null);
            };

            game.AddPlayer(Guid.NewGuid());
            game.AddPlayer(Guid.NewGuid());
        }

        [TestMethod]
        public void InitBoardBench()
        {
            var playerGuid1 = Guid.NewGuid();

            var bench = game.Bench;

            var pawnSettings = new StrategoPawnSettings();
            var pawn1 = pawnSettings.GetPawn(playerGuid1, "PAWN_FLAG");
            var result = bench.PlacingPawn(pawn1, new Montana.Position(1, 1));

            Assert.AreEqual(true, result);
        }
    }
}
