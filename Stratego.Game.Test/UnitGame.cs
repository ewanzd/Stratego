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
            game.AddPlayer(playerGuid1);
            game.AddPlayer(playerGuid2);

            Assert.AreEqual(true, game.IsActive);
            Assert.AreEqual(true, game.IsReady);
        }
    }
}
