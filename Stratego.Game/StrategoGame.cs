using Montana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Game
{
    public class StrategoGame : GameBase<StrategoData>
    {
        // Verfügt über die Spiellogik von Stratego

        private StrategoBench _bench;
        private int _maxPlayer;

        // Game settings
        private IStrategoMode _mode;

        public GameState GameState
        {
            get
            {
                return Data.GameState;
            }
            protected set
            {
                var state = value;
                Data.GameState = state;
                OnGameStateChanged(state);
            }
        }

        public IStrategoMode Mode
        {
            get { return _mode; }
            private set { _mode = value; }
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

        public StrategoGame() : this(new StrategoModeClassic())
        {
            
        }

        public StrategoGame(IStrategoMode mode) : this(new StrategoData(), mode)
        {

        }

        public StrategoGame(StrategoData summary, IStrategoMode mode) : base(summary)
        {
            if (mode == null) throw new NullReferenceException();

            Mode = mode;
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            MaxPlayer = 2;
            Bench = new StrategoBench();
            Bench.Data = Data;

            if(Data.GameInfo == null)
            {
                Data.GameInfo = new GameInfo()
                {
                    Title = "Stratego Game",
                    CreateDateTime = DateTime.Now
                };
            }

            if (Data.ListOfMoves == null) Data.ListOfMoves = new List<GameMove>();

            //fight.AddSpecialCase(new CombatSpecialCase(fieldMarshal.TypeName, bomber.TypeName, new Func<Pawn, Pawn, FightResult>((att, def) => FightResult.Draw)));
            //fight.AddSpecialCase(new CombatSpecialCase(general.TypeName, bomber.TypeName, new Func<Pawn, Pawn, FightResult>((att, def) => FightResult.Draw)));
        }
    }

    public interface IStrategoMode
    {
        Unit GetUnit(string typeName);
        //bool GetBackPawn(Guid player, string typeName);
        IEnumerable<Tuple<Unit, int>> GetAllUnit();
    }

    public sealed class StrategoModeClassic : IStrategoMode
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

        public StrategoModeClassic()
        {
            InitializePawns();
        }

        public UnitSetting GetPawnSetting(string typeName)
        {
            return UnitSettings.Where(x => x.Type.TypeName == typeName).FirstOrDefault();
        }

        public Unit GetUnit(string typeName)
        {
            return UnitSettings.Where(x => x.Type.TypeName == typeName).FirstOrDefault()?.Type;
        }

        public Pawn GetUnit(Guid player, string typeName)
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

        public IEnumerable<Tuple<Unit, int>> GetAllUnit()
        {
            return null;
        }

        private void InitializePawns()
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
