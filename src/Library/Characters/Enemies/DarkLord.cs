using System.Collections.Generic;
namespace RoleplayGame
{
    public class DarkLord : Enemy // Se crea una clase pública llamada DarkLord, heredada de la clase Enemy
    {
        public DarkLord(string name) 
        {
            this.Name = name;
            this.AddItem(new Sword()); // Se añado un item, en este caso: Espada
            this.AddItem(new Axe()); // Se le equipa un hacha
            this.AddItem(new Bow()); // Se le equipa un arco 
            this.AddItem(new Shield()); // Se le equipa un item de defensa, un Escudo
            this.AddItem(new Helmet()); // Se le añade mas defensa al equiparse un Casco
            this.AddItem(new Armor()); // Se le equipa una armadura
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