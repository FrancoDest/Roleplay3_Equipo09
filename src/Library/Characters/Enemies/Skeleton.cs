namespace RoleplayGame
{
    public class Skeleton : Enemy //Creamos la clase Skeleton, que es heredada de la clase abstracta Enemy.
    {
        public override int VP
        {
            get 
            {
                return 2; //Otorga la cantidad de puntos asignada para al que lo derrote.
            }
        }
        public Skeleton (string name)
        {
            this.Name = name;
            this.AddItem(new Sword());//Le agregamos una espada. 
            this.AddItem(new Helmet());//Le equipamos un casco aumentando su defensa.
        }
        
    }
}