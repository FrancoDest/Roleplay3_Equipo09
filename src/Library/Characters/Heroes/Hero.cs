namespace RoleplayGame
{
    public abstract class Hero : Character
    {
        protected override int VP {get;set;} = 0;

        public void AddVP(int vp)
        {
            this.VP += vp;
        }
    }
}