using System.Collections.Generic;
using System;
namespace RoleplayGame
{
    /// <summary>
    /// La clase encounter genera dos listas, una con heroes y una con enemigos, y los enfrenta.
    /// Por otro lado, tambien se le asignan los vp a los heroes una vez que termina el encuentro,
    /// lo que los cura.
    /// </summary>
    public class Encounters
    {
        private List<Enemy> enemies = new List<Enemy>();
        // Se genera una lista con enemigos
        private List<Hero> heroes = new List<Hero>();
        // Se genera una lista con heroes
        private bool somebodyToFight = true;
        // Verifica que queden personajes vivos en ambas listas
        public void DoEncounter()
        {
            /*
            Se crea una lista con los vp inciales de los heroes,
            para comparar con los vp finales y evaluar si se curan o no
            */
            List<int> VPheroes = new List<int>();
            foreach (Hero hero in heroes)
            {
                VPheroes.Add(hero.VP);
            }

            while (somebodyToFight && this.enemies.Count != 0 && this.heroes.Count != 0)
            {
                int indexE = 0;
                int indexH = 0;
                int moreThanMaxNumberOfEnemies = this.enemies.Count;

                while (indexE < moreThanMaxNumberOfEnemies && somebodyToFight)
                {
                    /*
                    Si el contador llega al final de la lista de heroes,
                    se resetea para recorrerla de nuevo
                    */
                    if (indexH == heroes.Count)
                    {
                        indexH = 0;
                    }

                    // Un enemigo ataca a un heroe
                    heroes[indexH].ReceiveAttack(enemies[indexE].AttackValue);

                    /*
                    Si un heroe se muere, se elimina de la lista de heroes
                    (y se deja de evaluar si sus vp al final del encuentro
                    en comparacion con sus vp al inicio del mismo son mayores a 5)
                    */
                    if (heroes[indexH].Health == 0)
                    {
                        heroes.RemoveAt(indexH);
                        VPheroes.Remove(indexH);
                        indexE -= 1;
                        // Evalua si quedan heroes con vida
                        if (heroes.Count == 0)
                        {
                            somebodyToFight = false;
                        }
                    }

                    indexE += 1;
                    indexH += 1;
                }

                int maxNumberOfHeroes = this.heroes.Count;
                indexE = 0;
                indexH = 0;

                while (indexH != maxNumberOfHeroes && somebodyToFight)
                {
                    /*
                    Si el contador llega al final de la lista de enemigos,
                    se resetea para recorrerla de nuevo
                    */
                    if (indexE == enemies.Count)
                    {
                        indexE = 0;
                    }

                    // Un heroe ataca a un enemigo
                    enemies[indexE].ReceiveAttack(heroes[indexH].AttackValue, heroes[indexH]);
                    
                    // Si un enemigo se muere, se elimina de la lista de enemigos
                    if (enemies[indexE].Health == 0)
                    {
                        enemies.RemoveAt(indexE);
                        indexE -= 1;
                        // Evalua si quedan enemigos con vida
                        if (enemies.Count == 0)
                        {
                            somebodyToFight = false;
                        }
                    }
                    indexE += 1;
                    indexH += 1;
                }
            }
            
            // Si un heroe consiguio 5 o mas vp a lo largo del encuentro, se cura
            for (int i = 0; i < heroes.Count; i++)
            {
                int vpGanados = heroes[i].VP - VPheroes[i];
                if (vpGanados >= 5)
                {
                    heroes[i].Cure();
                }
            }

            //Vacía la lista para que en el proximo encuentro no se mantengan los asignados anteriormente
            this.CleanLists();
        }
        
        // Vacia las listas de heroes y de enemigos
        public void CleanLists()
        {
            this.heroes = new List<Hero>();
            this.enemies = new List<Enemy>();            
        }

        // Añade heroes a la lista de heroes
        public void AddHero(Hero hero)
        {
            if (hero.Health != 0)
            {
            this.heroes.Add(hero);
            }
        }

        // Añade enemigos a la lista de enemigos
        public void AddEnemy(Enemy enemy)
        {
            if (enemy.Health != 0)
            {
            this.enemies.Add(enemy);
            }
        }

        // remueve heroes de la lista de heroes
        public void RemoveHero(Hero hero)
        {
            this.heroes.Remove(hero);
        }

        // remueve enemigos de la lista de enemigos
        public void RemoveEnemy(Enemy enemy)
        {
            this.enemies.Remove(enemy);
        }
    }
}