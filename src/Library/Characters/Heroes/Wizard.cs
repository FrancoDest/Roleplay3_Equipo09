using System.Collections.Generic;
namespace RoleplayGame
{
    public class Wizard: MagicHero
    {
        public Wizard(string name)
        {
            this.Name = name;
            
            this.AddItem(new Staff());
        }
    }
}