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
        private Orc orcTest2;
        private Skeleton skeletonTest;
        private Encounters encounter;

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
            encounter = new Encounters();
        }

        /*
        Prueba que no se realicen ataques si solo se añade un heroe a las
        listas de personaje de encuentros (sin ningun enemigo)
        */
        [Test]
        public void OnlyHero()
        {
            int expected = archerTest.Health;
            encounter.AddHero(archerTest);
            encounter.DoEncounter();
            Assert.AreEqual(expected, archerTest.Health);
        }

        /*
        Prueba que no se realicen ataques si solo se añade un enemigo a las
        listas de personaje de encuentros (sin ningun heroe)
        */
        [Test]
        public void OnlyEnemy()
        {
            int expected = orcTest.Health;
            encounter.AddEnemy(orcTest);
            encounter.DoEncounter();
            Assert.AreEqual(expected, orcTest.Health);
        }

        /*
        Prueba que se realicen de manera correcta los ataques en un encuentro
        cuando la cantidad de heroes y de enemigos son la misma
        */
        [Test]
        public void Hero1Enemy1()
        {
            encounter.AddHero(dwarfTest);
            encounter.AddEnemy(orcTest);
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
            encounter.AddHero(archerTest);
            encounter.AddHero(knightTest);
            encounter.AddEnemy(orcTest);
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
            encounter.AddHero(archerTest);
            encounter.AddEnemy(orcTest);
            encounter.AddEnemy(skeletonTest);
            encounter.DoEncounter();
            Assert.AreEqual(0, archerTest.Health);
            Assert.AreEqual(0, orcTest.Health);
            Assert.AreEqual(100, skeletonTest.Health);
        }

        [Test]
        public void Hero2Enemy2()
        {
            encounter.AddHero(archerTest);
            encounter.AddHero(knightTest);
            encounter.AddEnemy(orcTest);
            encounter.AddEnemy(skeletonTest);
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
            encounter.AddHero(dwarfTest);
            encounter.AddEnemy(orcTest);
            encounter.AddEnemy(orcTest2);
            encounter.DoEncounter();
            Assert.AreEqual(100,dwarfTest.Health);
        }

        //El objetivo del test es verificar si se eliminan de la lista los character luego de un encuentro
        //En el encuentro Hero1Enemy1 dwarf termina con menos vida y el orc termina sin vida
        //Si el hero que sigue con vida (por lo tanto sigue en la lista) se lo elimina de la misma al terminar el encuentro
        //al agregar un enemy pero no un hero y llamar a DoEncounter nuevamente
        //no habria hero en DoEncounter por lo cual la vida de los character no cambiaria ya que no hay batalla
        [Test]
        public void CleanListsTest()
        {
            encounter.AddHero(dwarfTest);
            encounter.AddEnemy(orcTest);
            encounter.DoEncounter();
            encounter.AddEnemy(skeletonTest);
            encounter.DoEncounter();
            Assert.AreEqual(72, dwarfTest.Health);
            Assert.AreEqual(100, skeletonTest.Health);
        }

        //El objetivo del test es verificar que se puedan hacer encuentros luego de haber terminado un encuentro
        [Test]
        public void DoTwoEncounterTest()
        {
            encounter.AddHero(dwarfTest);
            encounter.AddEnemy(orcTest);
            encounter.DoEncounter();
            encounter.AddHero(knightTest);
            encounter.AddEnemy(skeletonTest);
            encounter.DoEncounter();
            Assert.AreEqual(100, knightTest.Health);
            Assert.AreEqual(0, skeletonTest.Health);
        }

        //El objetivo del test es verificar que un character utilizado en un encuentro anterior puede ser parte
        //de un nuevo encuentro
        [Test]
        public void DoTwoEncounterTestWithTheSameCharacter()
        {
            encounter.AddHero(dwarfTest);
            encounter.AddEnemy(orcTest);
            encounter.DoEncounter();
            encounter.AddHero(dwarfTest);
            encounter.AddEnemy(skeletonTest);
            encounter.DoEncounter();
            Assert.AreEqual(42, dwarfTest.Health);
            Assert.AreEqual(0, skeletonTest.Health);
        }
    }
}