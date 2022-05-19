using System.Collections.Generic;

namespace RoleplayGame
{
    public class Orc: Enemy
    {
        public Orc(string name)
        {
            this.Name = name;

            this.AddItem(new Axe());
        }
        public override int VP
        {
            get {return 1;}
        }
    }
}