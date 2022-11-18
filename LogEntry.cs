namespace MoD
{
    public struct LogEntry
    {
        public bool Success;
        public string Message;
        public ICharacter Actor;
        public ICharacter Target;
        public List<int> EventRolls;
        public IWeapon Weapon; //need a weapon interface type
    }
}