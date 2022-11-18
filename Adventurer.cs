using System;


namespace MoD
{
    public class Adventurer : IHealth
    {
        public string Name = "";

        public int MaxHealth {get;set;}
        public int CurrentHealth {get;set;}

        public LifeState LifeState
        {
            get { return (CurrentHealth <= 0)? LifeState.Dead : (CurrentHealth <= 2)? LifeState.Unconscious : LifeState.Alive; }
        }

        public int TakeDamage(int damage){
            CurrentHealth -= damage;
            CurrentHealth = Math.Max(0,CurrentHealth);

            return CurrentHealth;
        }
    }
}