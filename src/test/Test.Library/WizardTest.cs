using NUnit.Framework;
using System;
using RoleplayGame;


namespace Test.Library
{
    /// <summary>
    /// Se crearon los test de la clase wizard por seperado, debido a que posee atributos y metodos distinto a
    /// los demas ICharacters, por lo cual merece un testing mas exhaustivo debido a sus caracteristicas magicas.
    /// </summary>
    public class WizardTests
    {
        private Wizard wizardTest;
        private Staff staffTest;
        private SpellsBook spellsBookTest;
        private SpellOne spellTest1;
        private SpellOne spellTest2;
        private SpellOne spellTest3;
        private SpellOne spellTest4;
        private Dwarf dwarfTest;
        private Armor armorTest;
        private Axe axeTest;


        [SetUp]
        public void Setup()
        {
            wizardTest = new Wizard("Richy");
            staffTest = new Staff();
            spellsBookTest = new SpellsBook();
            spellTest1 = new SpellOne();
            spellTest2 = new SpellOne();
            spellTest3 = new SpellOne();
            spellTest4 = new SpellOne();
            dwarfTest = new Dwarf("Thomas");
            armorTest = new Armor();
            axeTest = new Axe();
        }
        // Se prueba si los hechizos se equipan correctamente.
        // Si el hechizo se equipa correctamente el ataque debe variar segun los hechizos agregados. 
        [Test]
        public void WizardEquipSpells()
        {
            int expected = wizardTest.AttackValue + spellTest1.AttackValue + spellTest2.AttackValue + spellTest3.AttackValue + spellTest4.AttackValue;
            wizardTest.AddItem(spellsBookTest);
            spellsBookTest.AddSpell(spellTest1);
            spellsBookTest.AddSpell(spellTest2);
            spellsBookTest.AddSpell(spellTest3);
            spellsBookTest.AddSpell(spellTest4);
            Assert.AreEqual(expected, wizardTest.AttackValue);
        }

        // Se prueba si los hechizos funcionan correctamente durante la defensa
        [Test]
        public void WizardDefenseSpells()
        {
            wizardTest.AddItem(spellsBookTest);
            spellsBookTest.AddSpell(spellTest1);
            int expecteddamage = 0;
            dwarfTest.AddItem(axeTest);
            if (dwarfTest.AttackValue - wizardTest.DefenseValue > 0)
            {
                expecteddamage = dwarfTest.AttackValue - wizardTest.DefenseValue;
            }
            int expectedLifeAfterAttack = 0;
            if ((wizardTest.Health - expecteddamage) > 0)
                expectedLifeAfterAttack = wizardTest.Health - expecteddamage;
            wizardTest.ReceiveAttack(dwarfTest.AttackValue);
            Assert.AreEqual(expectedLifeAfterAttack, wizardTest.Health);
        }

        // Se prueba si los hechizos funcionan correctamente durante el ataque
        [Test]
        public void WizardAttackSpells()
        {
            wizardTest.AddItem(spellsBookTest);
            spellsBookTest.AddSpell(spellTest1);
            int expecteddamage = 0;
            dwarfTest.AddItem(armorTest);
            if (wizardTest.AttackValue - dwarfTest.DefenseValue > 0)
            {
                expecteddamage = wizardTest.AttackValue - dwarfTest.DefenseValue;
            }
            int expectedLifeAfterAttack = 0;
            if ((dwarfTest.Health - expecteddamage) > 0)
                expectedLifeAfterAttack = dwarfTest.Health - expecteddamage;
            dwarfTest.ReceiveAttack(wizardTest.DefenseValue);
            Assert.AreEqual(expectedLifeAfterAttack, dwarfTest.Health);
        }

        // Se prueba defender con el baculo equipado
        [Test]
        public void WizardDefendWithStaff()
        {
            wizardTest.AddItem(spellsBookTest);
            spellsBookTest.AddSpell(spellTest1);
            wizardTest.AddItem(staffTest);
            int expecteddamage = 0;
            dwarfTest.AddItem(axeTest);
            if (dwarfTest.AttackValue - wizardTest.DefenseValue > 0)
            {
                expecteddamage = dwarfTest.AttackValue - wizardTest.DefenseValue;
            }
            int expectedLifeAfterAttack = 0;
            if ((wizardTest.Health - expecteddamage) > 0)
                expectedLifeAfterAttack = wizardTest.Health - expecteddamage;
            wizardTest.ReceiveAttack(dwarfTest.AttackValue);
            Assert.AreEqual(expectedLifeAfterAttack, wizardTest.Health);
        }

        // Se prueba atacar con el baculo equipado
        [Test]
        public void WizardAttackWithStaff()
        {
            wizardTest.AddItem(spellsBookTest);
            spellsBookTest.AddSpell(spellTest1);
            wizardTest.AddItem(staffTest);
            int expecteddamage = 0;
            dwarfTest.AddItem(armorTest);
            if (wizardTest.AttackValue - dwarfTest.DefenseValue > 0)
            {
                expecteddamage = wizardTest.AttackValue - dwarfTest.DefenseValue;
            }
            int expectedLifeAfterAttack = 0;
            if ((dwarfTest.Health - expecteddamage) > 0)
                expectedLifeAfterAttack = dwarfTest.Health - expecteddamage;
            dwarfTest.ReceiveAttack(wizardTest.DefenseValue);
            Assert.AreEqual(expectedLifeAfterAttack, dwarfTest.Health);
        }

        // Se prueba atacar con hechizos y baculo equipados a la vez
        [Test]
        public void WizardAttackWithAll()
        {
            wizardTest.AddItem(spellsBookTest);
            spellsBookTest.AddSpell(spellTest1);
            wizardTest.AddItem(staffTest);
            int expecteddamage = 0;
            dwarfTest.AddItem(armorTest);
            if (wizardTest.AttackValue - dwarfTest.DefenseValue > 0)
            {
                expecteddamage = wizardTest.AttackValue - dwarfTest.DefenseValue;
            }
            int expectedLifeAfterAttack = 0;
            if ((dwarfTest.Health - expecteddamage) > 0)
                expectedLifeAfterAttack = dwarfTest.Health - expecteddamage;
            dwarfTest.ReceiveAttack(wizardTest.DefenseValue);
            Assert.AreEqual(expectedLifeAfterAttack, dwarfTest.Health);
        }

        /*
        Se prueba el funcionamiento del baculo, dado que a partir de los cambios en el mago
        se puede utilizar el mismo sin tener el libro de hechizos, y gracias a esto se puede crear una
        instancia de mago sin necesidad de que comience obligatoriamente con un libro de hechizos.
        */

        // Se prueba si al equipar un baculo se modifica correctamente la defensa
        [Test]
        public void WizardEquipStaffDefense()
        {
            int expected = wizardTest.DefenseValue + staffTest.DefenseValue;
            wizardTest.AddItem(staffTest);
            Assert.AreEqual(expected, wizardTest.DefenseValue);
        }

        // Se prueba si al equipar un baculo se modifica correctamente el ataque
        [Test]
        public void WizardEquipStaffAttack()
        {
            int expected = wizardTest.AttackValue + staffTest.AttackValue;
            wizardTest.AddItem(staffTest);
            Assert.AreEqual(expected, wizardTest.AttackValue);  
        }

        // Se prueba si al desequipar un baculo se modifica correctamente el ataque
        [Test]
        public void WizardUnequipStaffAttack()
        {
            int expected = wizardTest.AttackValue;
            wizardTest.AddItem(staffTest);
            wizardTest.RemoveItem(staffTest);
            Assert.AreEqual(expected, wizardTest.AttackValue);
        }

        // Se prueba si al desequipar un baculo se modifica correctamente la defensa
        [Test]
        public void WizardUnequipStaffDefense()
        {
            int expected = wizardTest.DefenseValue;
            wizardTest.AddItem(staffTest);
            wizardTest.RemoveItem(staffTest);
            Assert.AreEqual(expected, wizardTest.DefenseValue);
        }
    }
}