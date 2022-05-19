using System.Collections.Generic;

namespace RoleplayGame
{
    public abstract class Enemy : Character //Creamos una clase de tipo abstracta llamada Enemy, la cual es heredada de Character.
    {                                       //Es una clase padre
       public int showVp()
       {
           return this.VP; // retorna los VP (Puntos de Victoria) de Enemy
       }
       public void ReceiveAttack(int power, Hero hero) //Este método se hace para que se reciba el ataque de un heroe
        {                                             
            if (this.DefenseValue < power)
            {
                this.Health -= power - this.DefenseValue;
            }
            if (this.Health <= 0)
            {
                hero.AddVP(showVp()); //Los puntos de victoria del enemigo va para el heroe que lo vence.
            }
        }
    }
}