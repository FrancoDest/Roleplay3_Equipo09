using RoleplayGame;
using NUnit.Framework;
using System.Collections.Generic;

namespace Test.Library
{
    public class EncountersTest
    {
        private Archer archerTest;
        private Knight knightTest;
        private Dwarf dwarfTest;
        private Wizard wizardTest;
        private DarkLord darkLordTest;
        private Ghost ghostTest;
        private Orc orcTest;
        private Orc orcTest2;
        private Skeleton skeletonTest;
        private Encounters encounter;
        private List<Hero> herolist;
        private List<Enemy> enemylist;


        [SetUp]
        public void Setup()
        {
            archerTest = new Archer("Raul");

            knightTest = new Knight("Tusam");

            dwarfTest = new Dwarf("Thomas");

            wizardTest = new Wizard("Ruben");

            darkLordTest = new DarkLord("Samuel");

            ghostTest = new Ghost("Gonzalo");

            orcTest = new Orc("francisc");

            orcTest2 = new Orc("francisc2");

            skeletonTest = new Skeleton("robert");
            herolist = new List<Hero>();
            enemylist = new List<Enemy>();
            encounter = new Encounters(herolist,enemylist);

        }
        /*
        Prueba que se realicen de manera correcta los ataques en un encuentro
        cuando la cantidad de heroes y de enemigos son la misma
        */
        [Test]
        public void Hero1Enemy1()
        {
            herolist.Add(dwarfTest);
            enemylist.Add(orcTest);
            encounter = new Encounters(herolist,enemylist);
            encounter.DoEncounter();
            Assert.AreEqual(72, dwarfTest.Health);
            Assert.AreEqual(0, orcTest.Health);
        }

        /*
        Prueba que se realicen de manera correcta los ataques en un encuentro
        cuando la cantidad de heroes es mayor a la de enemigos
        */
        [Test]
        public void Hero2Enemy1()
        {
            herolist.Add(archerTest);
            herolist.Add(knightTest);
            enemylist.Add(orcTest);
            encounter.DoEncounter();
            Assert.AreEqual(79, archerTest.Health);
            Assert.AreEqual(100, knightTest.Health);
            Assert.AreEqual(0, orcTest.Health);
        }

        /*
        Prueba que se realicen de manera correcta los ataques en un encuentro
        cuando la cantidad de enemigos es mayor a la de heroes
        */
        [Test]
        public void Hero1Enemy2()
        {
            herolist.Add(archerTest);
            enemylist.Add(orcTest);
            enemylist.Add(skeletonTest);
            encounter.DoEncounter();
            Assert.AreEqual(0, archerTest.Health);
            Assert.AreEqual(0, orcTest.Health);
            Assert.AreEqual(100, skeletonTest.Health);
        }

        [Test]
        public void Hero2Enemy2()
        {
            herolist.Add(archerTest);
            herolist.Add(knightTest);
            enemylist.Add(orcTest);
            enemylist.Add(skeletonTest);
            encounter.DoEncounter();
            Assert.AreEqual(0, archerTest.Health);
            Assert.AreEqual(100,knightTest.Health);
            Assert.AreEqual(0, orcTest.Health);
            Assert.AreEqual(0, skeletonTest.Health);
        }

        //Como demostramos en el test Hero1Enemy1 al luchar un enano contra un orco pierde vida
        //Utilizamos este test para ver que si mata a dos orcos y sobrevive se cura
        [Test]
        public void VPAsignados()
        {
            herolist.Add(dwarfTest);
            enemylist.Add(orcTest);
            enemylist.Add(orcTest2);
            encounter.DoEncounter();
            Assert.AreEqual(100,dwarfTest.Health);
        }
        
    }
}