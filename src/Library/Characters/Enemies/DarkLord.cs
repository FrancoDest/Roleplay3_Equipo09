using System.Collections.Generic;
namespace RoleplayGame
{
    public class DarkLord : Enemy
    {
        public DarkLord(string name)
        {
            this.Name = name;
            this.AddItem(new Sword());
            this.AddItem(new Axe());
            this.AddItem(new Bow());
            this.AddItem(new Shield());
            this.AddItem(new Helmet());
            this.AddItem(new Armor());
        }

        public override int VP
        {
            get
            {
                return 5;
            }
        }
    }
}