namespace RoleplayGame
{
    public abstract class Hero : Character
    {
        // VP (puntos de victoria) de los heroes. Comienzan en 0 y a medida que va derrotando enemigos aumenta.
        public override int VP {get; protected set;} = 0;

        public void AddVP(int vp)
        {
            this.VP += vp;
        }
    }
}