using System.Collections.Generic;
namespace RoleplayGame
{
    public class Wizard: MagicHero
    {
        // Se crea un mago, el cual hereda de heroe magico y comienza con un baculo.
        public Wizard(string name)
        {
            this.Name = name;
            this.AddItem(new Staff());
        }
    }
}