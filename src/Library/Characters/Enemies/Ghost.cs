namespace RoleplayGame
{
    public class Ghost : MagicEnemy //Se crea una clase llamada Ghost, heredada de la clase MagicEnemy
    {
        public override int VP
        {
            get 
            {
                return 3; //Este número se trata de VP (Puntos de victoria) que va para el heroe que lo derrote.
            }
        }
        public Ghost (string name)
        {
            this.Name = name;
            this.AddItem(new Staff());// Al enemigo se le equipa un arma: un báculo, que sirve tanto para ataque como defensa.
        }
        
    }
}