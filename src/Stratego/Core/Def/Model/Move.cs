﻿using Montana;
using System;

namespace Stratego.Core.Def
{
    /// <summary>
    /// Save source and destination position.
    /// </summary>
    public class Move
    {
        private readonly Position _from;
        private readonly Position _to;
        private readonly FightResult _fightResult;
        private readonly Actor _offender;
        private readonly Actor _defender;

        public Position From { get => _from; }
        public Position To { get => _to; }
        public FightResult FightResult { get => _fightResult; }
        public Actor Offender { get => _offender; }
        public Actor Defender { get => _defender; }

        /// <summary>
        /// Create new move with source and destination position.
        /// </summary>
        /// <param name="from">Source position.</param>
        /// <param name="to">Destination position.</param>
        public Move(Position from, Position to, Actor offender) {
            _from = from;
            _to = to;
            _fightResult = FightResult.None;
            _offender = offender;
            _defender = null;
        }

        /// <summary>
        /// Create new move with source, destination position and result of a fight.
        /// </summary>
        /// <param name="from">Source position.</param>
        /// <param name="to">Destination position.</param>
        /// <param name="fightResult">Result of a fight.</param>
        /// <param name="offender">Offender of this fight.</param>
        /// <param name="defender">Defender of this fight.</param>
        public Move(Position from, Position to, FightResult fightResult, Actor offender, Actor defender) {
            _from = from;
            _to = to;
            _fightResult = fightResult;
            _offender = offender;
            _defender = defender;
        }
    }
}
