namespace Montana
{
    public interface ICombatSystem<pawn>
    {
        FightResult Go(pawn attacker, pawn defender);
    }
}
