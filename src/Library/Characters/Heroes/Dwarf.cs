using System.Collections.Generic;
namespace RoleplayGame
{
    public class Dwarf: Hero 
    {
        // Se crea un enano, el cual hereda de heroe y comienza con hacha y casco.
        public Dwarf(string name)
        {
            this.Name = name;
            this.AddItem(new Axe());
            this.AddItem(new Helmet());
        }

    }
}