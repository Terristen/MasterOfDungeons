using MoD;

namespace MoD.Skills
{
    public class Bludgeon : ISkill
    {
        public string Name { get{ return this.Name; }  }

        public string SuccessTemplate { get{ return "{Actor.Name} Bludgeons {Target.Name}.";} }
        public string FailTemplate { get{ return "{Actor.Name} misses {Target.Name} with his blugeon.";} }
        public LogEntry TrySkill(ICharacter Actor, ICharacter Target, IWeapon Weapon)
        {
            return new LogEntry()
            {
                Actor = Actor,
                Success = true,
                Target = Target,
                Weapon = Weapon,
                Message = "{Actor.Name} swings {Weapon.Name} at {Target.Name} damage."
            };
        }

    }
}