using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stratego.Game.Test
{
    [TestClass]
    public class UnitGame
    {
        // ===================================================================================
        // Ablauf testen
        // ===================================================================================

        StrategoGame game;
        StrategoBenchPrep benchPrep;
        StrategoBenchInPlay benchInPlay;
        Guid playerOne;
        Guid playerTwo;

        [TestInitialize]
        public void Init()
        {
            playerOne = Guid.NewGuid();
            playerTwo = Guid.NewGuid();

            game = new StrategoGame(playerOne, playerTwo);


            var source = new StrategoSourceStandard();
            var mapGenerator = new StrategoMapGenerator(source);
            benchPrep = new StrategoBenchPrep(game, mapGenerator);
        }

        [TestMethod]
        public void GameCheckReady()
        {
            //Assert.AreEqual(true, game.IsActive);
        }

        [TestMethod]
        public void PlacingPawns()
        {
            GameCheckReady();

            
        }

        [TestMethod]
        public void MovePawns()
        {
            benchInPlay = new StrategoBenchInPlay(game, benchPrep);
        }
    }

    internal class UnitGameKind
    {
        private readonly StrategoGame _game;
        private string _title;
    }
}
