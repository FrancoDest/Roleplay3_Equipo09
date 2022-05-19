using System.Collections.Generic;
namespace RoleplayGame
{
    public class Knight: Hero 
    {
        // Se crea un caballero, el cual hereda de heroe y comienza con espada, armadura y escudo.
        public Knight(string name)
        {
            this.Name = name;
            this.AddItem(new Sword());
            this.AddItem(new Armor());
            this.AddItem(new Shield());
        }
    }
}