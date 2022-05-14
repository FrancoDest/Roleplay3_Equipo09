namespace RoleplayGame
{
    public class Skeleton : Enemy
    {
        public override int VP
        {
            get 
            {
                return 21;
            }
        }
        public Skeleton ()
        {
            this.AddItem(new Sword());
            this.AddItem(new Helmet());
        }
        
    }
}