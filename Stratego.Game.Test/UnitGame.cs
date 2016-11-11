using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Montana;

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

            game = StrategoGame.New(playerOne, playerTwo);
            var source = new StrategoSource();
            var boardInitializer = new BoardInitializer(source);
            benchPrep = new StrategoBenchPrep(boardInitializer);
        }

        [TestMethod]
        public void GameCheckReady()
        {
            Assert.AreEqual(true, game.IsActive);
        }

        [TestMethod]
        public void PlacingPawns()
        {
            GameCheckReady();

            //var settings = game.GetSettings();
            //var listUnits = settings.GetAllUnit().ToList();

            //bench.PlaceUnit(playerOne, listUnits[0], new Position(1, 1));

            //Assert.AreEqual(bench.GetField(new Position(1, 1)).Pawn.Player, playerOne);
        }

        [TestMethod]
        public void MovePawns()
        {
            benchInPlay = new StrategoBenchInPlay(game, benchPrep);
        }
    }
}
