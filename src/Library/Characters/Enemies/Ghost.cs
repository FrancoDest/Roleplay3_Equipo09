namespace RoleplayGame
{
    public class Ghost : Enemy
    {
        protected override int VP
        {
            get 
            {
                return 50;
            }
        }
        public Ghost (string name)
        {
            this.Name = name;
            this.AddItem(new Sword());
            this.AddItem(new Armor());
        }
        
    }
}