using System.Collections.Generic;

namespace RoleplayGame
{
    public abstract class MagicHero : Hero
    {
        protected List<IMagicalItem> magicalItems = new List<IMagicalItem>();
        // Lista de equipamiento (solo items magicos)

        // Aparte de sumar el valor de ataque de los items, tambien se suma el ataque de los items magicos.
        public override int AttackValue
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
                foreach (IMagicalItem item in this.magicalItems)
                {
                    if (item is IMagicalAttackItem)
                    {
                        value += (item as IMagicalAttackItem).AttackValue;
                    }
                }
                return value;
            }
        }

        // Aparte de sumar el valor de defensa de los items, tambien se suma la defensa de los items magicos.
        public override int DefenseValue
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
                foreach (IMagicalItem item in this.magicalItems)
                {
                    if (item is IMagicalDefenseItem)
                    {
                        value += (item as IMagicalDefenseItem).DefenseValue;
                    }
                }
                return value;
            }
        }

        // Añade items a la lista de equipamiento de items magicos.
        public void AddItem(IMagicalItem item)
        {
            this.magicalItems.Add(item);
        }

        // Remueve items a la lista de equipamiento de items magicos.
        public void RemoveItem(IMagicalItem item)
        {
            this.magicalItems.Remove(item);
        }
    }
}