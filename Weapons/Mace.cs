using MoD;
using System;

namespace MoD.Skills
{
    public class Mace : IWeapon
    {
        public string Name { get{ return this.Name; }  }

        public WeaponClass weaponClass { get; set; }

        public int maxDamage { get; set; }
        public int minDamage { get; set; }

        Random rnd = new Random();

        public LogEntry HitOn(ICharacter Actor, ICharacter Target)
        {
            int damage = rnd.Next(minDamage,maxDamage+1);

            return new LogEntry()
            {
                Actor = Actor,
                Success = true,
                Target = Target,
                Weapon = this,
                Message = "{Actor.Name} hits {Target.Name} for {damage} damage."

            };
        }
        public LogEntry MissOn(ICharacter Actor, ICharacter Target)
        {
            return new LogEntry();
        }
        public LogEntry BlockedOn(ICharacter Actor, ICharacter Target)
        {
            return new LogEntry();
        }

    }
}