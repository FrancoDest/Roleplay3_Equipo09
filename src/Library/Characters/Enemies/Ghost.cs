namespace RoleplayGame
{
    public class Ghost : MagicEnemy
    {
        public override int VP
        {
            get 
            {
                return 50;
            }
        }
        public Ghost (string name)
        {
            this.Name = name;
            this.AddItem(new Staff());
        }
        
    }
}