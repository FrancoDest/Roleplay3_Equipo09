using System.Collections.Generic;

namespace RoleplayGame
{
    public class Orc: Enemy
    {
        public Orc(string name)
        {
            this.Name = name;
        }
        public override int VP
        {
            get {return 50;}
        }
    }
}