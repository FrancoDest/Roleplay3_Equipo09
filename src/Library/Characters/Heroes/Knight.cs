using System.Collections.Generic;
namespace RoleplayGame
{
    public class Knight: Hero 
    {
        public Knight(string name)
        {
            this.Name = name;
            
            this.AddItem(new Sword());
            this.AddItem(new Armor());
            this.AddItem(new Shield());
        }
    }
}