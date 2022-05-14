using System.Collections.Generic;

namespace RoleplayGame
{
    public abstract class Enemy : Character
    {
       public int showVp()
       {
           return this.VP;
       }
       public void ReceiveAttack(int power, Hero hero)
        {
            if (this.DefenseValue < power)
            {
                this.Health -= power - this.DefenseValue;
            }
            if (this.Health <= 0)
            {
                hero.AddVP(showVp());
            }
        }
    }
}