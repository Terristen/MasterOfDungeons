namespace MoD{
    public interface ICharacter 
    {

        Stats stats { get;set; }

        MoD.LifeState lifeState { get; set; }

        Combatant combat { get; set; }

        MoD.Stance stance { get; set; }

        MoD.BattleState battleState { get; set; }

        ///Returns remaining health
        int ApplyDamage(int dam);
    }
}