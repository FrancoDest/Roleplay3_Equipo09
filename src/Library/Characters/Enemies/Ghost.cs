namespace RoleplayGame
{
    public class Ghost : MagicEnemy
    {
        public override int VP
        {
            get 
            {
                return 3;
            }
        }
        public Ghost (string name)
        {
            this.Name = name;
            this.AddItem(new Staff());
        }
        
    }
}