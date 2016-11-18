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
        StrategoBenchSetup benchPrep;
        StrategoBenchInPlay benchInPlay;
        Guid playerOne;
        Guid playerTwo;

        [TestInitialize]
        public void Init()
        {
            playerOne = Guid.NewGuid();
            playerTwo = Guid.NewGuid();

            game = new StrategoGame(playerOne, playerTwo);
            benchPrep = new StrategoBenchSetup(game);
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

    internal class UnitPlayer
    {
        private readonly Guid _id;
        private string _name;
        private string _color;
    }

    internal class UnitGameKind
    {
        private readonly StrategoGame _game;
        private string _title;
    }
}
