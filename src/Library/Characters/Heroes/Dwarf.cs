using System.Collections.Generic;
namespace RoleplayGame
{
    public class Dwarf: Hero 
    {
        public Dwarf(string name)
        {
            this.Name = name;
            
            this.AddItem(new Axe());
            this.AddItem(new Helmet());
        }

    }
}