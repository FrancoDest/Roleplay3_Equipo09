using System.Collections.Generic;
namespace RoleplayGame
{
    public abstract class Character : ICharacter
    {
        public string Name { get; set; }

        protected int health = 100;
        public virtual int VP {get; protected set;}
        protected List<IItem> items = new List<IItem>();
        // Lista de equipamiento

        // Vida del personaje. Si el personaje esta muerto, su vida queda en 0.
        public int Health
        {
            get
            {
                return this.health;
            }
            protected set
            {
                this.health = value < 0 ? 0 : value;
            }
        }

        // Ataque del personaje. Se calcula como la suma del daño de todos sus items.
        public virtual int AttackValue
        {
            get
            {
                int value = 0;
                foreach (IItem item in this.items)
                {
                    if (item is IAttackItem)
                    {
                        value += (item as IAttackItem).AttackValue;
                    }
                }
                return value;
            }
        }

        // Defensa del personaje. Se calcula como la suma de la defensa de todos sus items.
        public virtual int DefenseValue
        {
            get
            {
                int value = 0;
                foreach (IItem item in this.items)
                {
                    if (item is IDefenseItem)
                    {
                        value += (item as IDefenseItem).DefenseValue;
                    }
                }
                return value;
            }
        }

        // Añade items a la lista de items.
        public void AddItem(IItem item)
        {
            this.items.Add(item);
        }

        // Remueve items de la lista de items.
        public void RemoveItem(IItem item)
        {
            this.items.Remove(item);
        }

        // Cura al personaje. Curar implica asignarle la vida base del personaje.
        public void Cure()
        {
            this.Health = 100;
        }

        /*
        Recibe un ataque de otro personaje. Previo a modificar la vida, se bloquea el daño con la armadura
        en caso de que sea mayor al poder del ataque, y se reduce en caso contrario.
        */
        public virtual void ReceiveAttack(int power)
        {
            if (this.DefenseValue < power)
            {
                this.Health -= power - this.DefenseValue;
            }
        }
    }
}