using RoleplayGame;
using NUnit.Framework;

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
        private Skeleton skeletonTest;
        private Encounters encounter;
        
        [SetUp]
        public void Setup()
        {
            archerTest = new Archer("Raul");
            knightTest = new Knight("Tusam");
            dwarfTest = new Dwarf("Thomas");
            Wizard wizardTest = new Wizard("Ruben");
            DarkLord darkLordTest = new DarkLord("Samuel");
            Ghost ghostTest = new Ghost("Gonzalo");
            Orc orcTest = new Orc("francisc");
            Skeleton skeletonTest = new Skeleton("robert"); 
            Encounters encounter = new Encounters();
        }

        [Test]
        public void OnlyHero()
        {
            int expected = archerTest.Health;
            encounter.AddHero(archerTest);
            encounter.DoEncounter();
            Assert.AreEqual(expected, archerTest.Health);
        }

        [Test]
        public void OnlyEnemy()
        {
            int expected = orcTest.Health;
            encounter.AddEnemy(orcTest);
            encounter.DoEncounter();
            Assert.AreEqual(expected, orcTest.Health);
        }

        [Test]
        public void Hero1Enemy1()
        {
            int expected = archerTest.Health;
            encounter.AddHero(archerTest);
            encounter.AddEnemy(orcTest);
            encounter.DoEncounter();
            Assert.AreEqual(expected, archerTest.Health);
        }

        [Test]
        public void Hero2Enemy1()
        {
            int expected = archerTest.Health;
            encounter.AddHero(archerTest);
            encounter.AddHero(knightTest);
            encounter.AddEnemy(orcTest);
            encounter.DoEncounter();
            Assert.AreEqual(expected, archerTest.Health);
        }

        [Test]
        public void Hero1Enemy2()
        {
            int expected = archerTest.Health;
            encounter.AddHero(archerTest);
            encounter.AddEnemy(orcTest);
            encounter.AddEnemy(skeletonTest);
            encounter.DoEncounter();
            Assert.AreEqual(expected, archerTest.Health);
        }

        [Test]
        public void Hero4Enemy4()
        {
            int expected = archerTest.Health;
            encounter.AddHero(archerTest);
            encounter.AddHero(dwarfTest);
            encounter.AddHero(knightTest);
            encounter.AddHero(wizardTest);
            encounter.AddEnemy(darkLordTest);
            encounter.AddEnemy(ghostTest);
            encounter.AddEnemy(skeletonTest);
            encounter.AddEnemy(orcTest);
            encounter.DoEncounter();
            Assert.AreEqual(expected, archerTest.Health);
        }

    }
}