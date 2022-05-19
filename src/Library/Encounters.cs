using System.Collections.Generic;
using System;
namespace RoleplayGame
{
    public class Encounters
    {
        private List<Enemy> enemies = new List<Enemy>();
        private List<Hero> heroes = new List<Hero>();
        private bool somebodyToFight = true;
        public void DoEncounter()
        {
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
                    if (indexH == heroes.Count)
                    {
                        indexH = 0;
                    }

                    heroes[indexH].ReceiveAttack(enemies[indexE].AttackValue);

                    if (heroes[indexH].Health == 0)
                    {
                        heroes.RemoveAt(indexH);
                        VPheroes.Remove(indexH);
                        indexE -= 1;
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
                    if (indexE == enemies.Count)
                    {
                        indexE = 0;
                    }
                    enemies[indexE].ReceiveAttack(heroes[indexH].AttackValue, heroes[indexH]);
                    if (enemies[indexE].Health == 0)
                    {
                        enemies.RemoveAt(indexE);
                        indexE -= 1;
                        if (enemies.Count == 0)
                        {
                            somebodyToFight = false;
                        }
                    }
                    indexE += 1;
                    indexH += 1;
                }
            }
            
            for (int i = 0; i < heroes.Count; i++)
            {
                int vpGanados = heroes[i].VP - VPheroes[i];
                if (vpGanados >= 5)
                {
                    heroes[i].Cure();
                }
            }
        }
        public void AddHero(Hero hero)
        {
            this.heroes.Add(hero);
        }
        public void AddEnemy(Enemy enemy)
        {
            this.enemies.Add(enemy);
        }
        public void RemoveHero(Hero hero)
        {
            this.heroes.Remove(hero);
        }
        public void RemoveEnemy(Enemy enemy)
        {
            this.enemies.Remove(enemy);
        }
    }
}