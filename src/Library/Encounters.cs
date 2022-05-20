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
        private List<Enemy> enemieslist;
        // Se genera una lista con enemigos
        private List<Hero> heroeslist;
        // Se genera una lista con heroes
        private bool somebodyToFight = true;
        // Verifica que queden personajes vivos en ambas listas
        public Encounters(List<Hero> heroes, List<Enemy> enemies)
        {
            this.heroeslist = heroes;
            this.enemieslist = enemies;

        }
        public void DoEncounter()
        {
            /*
            Se crea una lista con los vp inciales de los heroes,
            para comparar con los vp finales y evaluar si se curan o no
            */
            List<int> VPheroes = new List<int>();
            foreach (Hero hero in heroeslist)
            {
                VPheroes.Add(hero.VP);
            }

            while (somebodyToFight && this.enemieslist.Count != 0 && this.heroeslist.Count != 0)
            {
                int indexE = 0;
                int indexH = 0;
                int moreThanMaxNumberOfEnemies = this.enemieslist.Count;

                while (indexE < moreThanMaxNumberOfEnemies && somebodyToFight)
                {
                    /*
                    Si el contador llega al final de la lista de heroes,
                    se resetea para recorrerla de nuevo
                    */
                    if (indexH == heroeslist.Count)
                    {
                        indexH = 0;
                    }

                    // Un enemigo ataca a un heroe
                    heroeslist[indexH].ReceiveAttack(enemieslist[indexE].AttackValue);

                    /*
                    Si un heroe se muere, se elimina de la lista de heroes
                    (y se deja de evaluar si sus vp al final del encuentro
                    en comparacion con sus vp al inicio del mismo son mayores a 5)
                    */
                    if (heroeslist[indexH].Health == 0)
                    {
                        heroeslist.RemoveAt(indexH);
                        VPheroes.Remove(indexH);
                        indexE -= 1;
                        // Evalua si quedan heroes con vida
                        if (heroeslist.Count == 0)
                        {
                            somebodyToFight = false;
                        }
                    }

                    indexE += 1;
                    indexH += 1;
                }

                int maxNumberOfHeroes = this.heroeslist.Count;
                indexE = 0;
                indexH = 0;

                while (indexH != maxNumberOfHeroes && somebodyToFight)
                {
                    /*
                    Si el contador llega al final de la lista de enemigos,
                    se resetea para recorrerla de nuevo
                    */
                    if (indexE == enemieslist.Count)
                    {
                        indexE = 0;
                    }

                    // Un heroe ataca a un enemigo
                    enemieslist[indexE].ReceiveAttack(heroeslist[indexH].AttackValue, heroeslist[indexH]);
                    
                    // Si un enemigo se muere, se elimina de la lista de enemigos
                    if (enemieslist[indexE].Health == 0)
                    {
                        enemieslist.RemoveAt(indexE);
                        indexE -= 1;
                        // Evalua si quedan enemigos con vida
                        if (enemieslist.Count == 0)
                        {
                            somebodyToFight = false;
                        }
                    }
                    indexE += 1;
                    indexH += 1;
                }
            }
            
            // Si un heroe consiguio 5 o mas vp a lo largo del encuentro, se cura
            for (int i = 0; i < heroeslist.Count; i++)
            {
                int vpGanados = heroeslist[i].VP - VPheroes[i];
                if (vpGanados >= 5)
                {
                    heroeslist[i].Cure();
                }
            }
        }
    }
}