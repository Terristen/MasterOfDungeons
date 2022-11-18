namespace MoD
{
    public interface IHealth {
        public int MaxHealth {get;set;}
        public int CurrentHealth {get;set;}

        public LifeState LifeState {get;}

        public int TakeDamage(int damage);
        
    }

    

}