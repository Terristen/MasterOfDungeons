namespace MoD
{
    public interface IWeapon {
        public string Name { get; }

        public WeaponClass weaponClass { get; }

        public int maxDamage { get; }
        public int minDamage { get; }

        public LogEntry HitOn(ICharacter Actor, ICharacter Target);
        public LogEntry MissOn(ICharacter Actor, ICharacter Target);
        public LogEntry BlockedOn(ICharacter Actor, ICharacter Target);

    }

    

}