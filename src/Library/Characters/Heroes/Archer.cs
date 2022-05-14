using System.Collections.Generic;
namespace RoleplayGame
{
    public class Archer: Hero 
    {
        public Archer(string name)
        {
            this.Name = name;
            
            this.AddItem(new Bow());
            this.AddItem(new Helmet());
        }
    }
}