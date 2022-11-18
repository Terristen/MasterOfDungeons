namespace MoD
{
    public interface ISkill {
        public string Name { get; }

        public string SuccessTemplate { get; }
        public string FailTemplate { get; }


        public LogEntry TrySkill(ICharacter Actor, ICharacter Target, IWeapon Weapon);

    }

    

}