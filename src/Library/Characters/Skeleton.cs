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
        public Skeleton (string name)
        {
            this.Name = name;
            this.AddItem(new Sword());
            this.AddItem(new Helmet());
        }
        
    }
}