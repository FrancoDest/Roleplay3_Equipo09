using System.Collections.Generic;
namespace RoleplayGame
{
    public class Archer: Hero 
    {
        // Se crea un arquero, el cual hereda de heroe y comienza con arco y casco.
        public Archer(string name)
        {
            this.Name = name;
            this.AddItem(new Bow());
            this.AddItem(new Helmet());
        }
    }
}