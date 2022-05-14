namespace RoleplayGame
{
    public abstract class Hero : Character
    {
        public override int VP {get; protected set;} = 0;

        public void AddVP(int vp)
        {
            this.VP += vp;
        }
    }
}