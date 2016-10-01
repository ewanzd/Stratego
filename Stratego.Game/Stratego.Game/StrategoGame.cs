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

        private StrategoBench _bench;
        private int _maxPlayer;

        public GameState GameState
        {
            get
            {
                return Summary.GameState;
            }
            protected set
            {
                var state = value;
                Summary.GameState = state;
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
                if (IsActive && !IsReady)
                    _maxPlayer = value;
            }
        }

        public StrategoBench Bench
        {
            get { return _bench; }
            protected set { _bench = value; }
        }

        public event EventHandler GameStateChanged;

        protected void OnGameStateChanged(GameState state)
        {
            GameStateChanged?.Invoke(this, EventArgs.Empty);
        }

        public StrategoGame() : this(new StrategoGameSummary())
        {
            
        }

        public StrategoGame(StrategoGameSummary summary) : base(summary)
        {
            
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            MaxPlayer = 2;
            Bench = new StrategoBench();
            Bench.Summary = Summary;

            if(Summary.GameInfo == null)
            {
                Summary.GameInfo = new GameInfo()
                {
                    Title = "Stratego Game",
                    CreateDateTime = DateTime.Now
                };
            }

            if (Summary.ListOfMoves == null) Summary.ListOfMoves = new List<GameMove>();

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
        public class UnitSetting
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

        public List<UnitSetting> UnitSettings;

        public event EventHandler CountChanges;

        public StrategoPawnSettings()
        {
            InitializePawnSettings();
        }

        public UnitSetting GetPawnSetting(string typeName)
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
            CountChanges?.Invoke(sender, e);
        }
    }
}
