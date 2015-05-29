using Montana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Game
{
    public class StrategoGame : GameBase<StrategoGameSummary>
    {
        // Verfügt über die Spiellogik von Stratego

        private GameInfo _info;
        private StrategoBench _bench;
        private int _maxPlayer;
        private GameState _gameState;

        public GameState GameState
        {
            get
            {
                return _gameState;
            }
            protected set
            {
                var state = value;
                _gameState = state;
                OnGameStateChanged(state);
            }
        }

        public override int MaxPlayer
        {
            get
            {
                return _maxPlayer;
            }
            protected set
            {
                if(IsActive && !IsReady)
                    _maxPlayer = value;
            }
        }

        public StrategoBench Bench
        {
            get
            {
                return _bench;
            }
            protected set
            {
                _bench = value;
            }
        }

        public event EventHandler GameStateChanged;

        protected void OnGameStateChanged(GameState state)
        {
            var ev = GameStateChanged;

            if (ev != null) ev(this, EventArgs.Empty);
        }

        public StrategoGame()
        {
            
        }

        public StrategoGame(StrategoGameSummary summary) : base(summary)
        {
            
        }

        public override StrategoGameSummary GetSummary()
        {
            var sum = base.GetSummary();

            return sum;
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            this.MaxPlayer = 2;

            //fight.AddSpecialCase(new CombatSpecialCase(fieldMarshal.TypeName, bomber.TypeName, new Func<Pawn, Pawn, FightResult>((att, def) => FightResult.Draw)));
            //fight.AddSpecialCase(new CombatSpecialCase(general.TypeName, bomber.TypeName, new Func<Pawn, Pawn, FightResult>((att, def) => FightResult.Draw)));
        }
    }

    public class GameInfo
    {
        public string Title { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime FinishDateTime { get; set; }
    }

    public interface IPawnSettings
    {
        Pawn GetPawn(Guid player, string typeName);
        bool GetBackPawn(Guid player, string typeName);
        IEnumerable<Tuple<Unit, int>> GetAll();
    }

    public sealed class StrategoPawnSettings : IPawnSettings
    {
        protected class UnitSetting
        {
            public readonly int MaxPawns;
            public readonly Unit Type;
            protected Dictionary<Guid,int> CurrentCount; // PlayerId/Count

            public event EventHandler CountChanged;

            public UnitSetting(int max, Unit type)
            {
                this.MaxPawns = max;
                this.Type = type;
                CurrentCount = new Dictionary<Guid, int>();
            }

            public Unit GetUnit(Guid player)
            {
                if(!CurrentCount.Keys.Contains(player))
                    CurrentCount.Add(player, MaxPawns);

                if (CurrentCount[player] == 0)
                    throw new ArgumentException("You have reached the max!");

                CurrentCount[player]--;

                return Type;
            }

            public bool GetBackUnit(Guid player)
            {
                return false;
            }
        }

        protected List<UnitSetting> UnitSettings;

        public event EventHandler CountChanges;

        public StrategoPawnSettings()
        {
            InitializePawnSettings();
        }

        protected UnitSetting GetPawnSetting(string typeName)
        {
            return UnitSettings.Where(x => x.Type.TypeName == typeName).FirstOrDefault();
        }

        public Pawn GetPawn(Guid player, string typeName)
        {
            var type = GetPawnSetting(typeName).GetUnit(player);

            return new Pawn(type, player);
        }

        public bool GetBackPawn(Guid player, string typeName)
        {
            var setting = GetPawnSetting(typeName);

            if(setting == null)
                return false;
                
            return setting.GetBackUnit(player);
        }

        public IEnumerable<Tuple<Unit, int>> GetAll()
        {
            return null;
        }

        private void InitializePawnSettings()
        {
            UnitSettings = new List<UnitSetting>()
            {
                new UnitSetting(1, new Unit()
                {
                    TypeName = "PAWN_FLAG",
                    Power = 0,
                    Range = 0,
                    MoveType = MoveType.None
                }),
                new UnitSetting(5, new Unit()
                {
                    TypeName = "PAWN_BOMB",
                    Power = 12,
                    Range = 0,
                    MoveType = MoveType.None
                }),
                new UnitSetting(2, new Unit()
                {
                    TypeName = "PAWN_FIELDMARSHAL",
                    Power = 11,
                    Range = 1,
                    MoveType = MoveType.Cross
                }),
                new UnitSetting(1, new Unit()
                {
                    TypeName = "PAWN_GENERAL",
                    Power = 10,
                    Range = 1,
                    MoveType = MoveType.Cross
                })
            };

            UnitSettings.ForEach(x => x.CountChanged += OnCountChanged);
        }

        private void OnCountChanged(object sender, EventArgs e)
        {
            var ev = CountChanges;

            if (ev != null) ev(sender, e);
        }
    }
}
