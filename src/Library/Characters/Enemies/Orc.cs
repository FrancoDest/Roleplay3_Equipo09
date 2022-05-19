using System.Collections.Generic;

namespace RoleplayGame
{
    public class Orc: Enemy //Creamos una clase, llamada Orc que es heredada de la clase abstracta Enemy.
    {
        public Orc(string name)
        {
            this.Name = name;

            this.AddItem(new Axe());//Se le equipa un arma, en este caso, un hacha.
        }
        public override int VP
        {
            get {return 1;} //Es el VP (Punto de victoria) que otorga al que lo derrote.
        }
    }
}