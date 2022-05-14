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
        private Spell spellTest1;
        private Spell spellTest2;
        private Spell spellTest3;
        private Spell spellTest4;
        private Dwarf dwarfTest;
        private Armor armorTest;
        private Axe axeTest;


        [SetUp]
        public void Setup()
        {
            wizardTest = new Wizard("Richy");
            staffTest = new Staff();
            spellsBookTest = new SpellsBook();
            spellTest1 = new Spell();
            spellTest2 = new Spell();
            spellTest3 = new Spell();
            spellTest4 = new Spell();
            dwarfTest = new Dwarf("Thomas");
            armorTest = new Armor();
            axeTest = new Axe();
        }
        // Se prueba si los hechizos se equipan correctamente.
        // Si el hechizo se equipa correctamente el ataque debe variar segun los hechizos agregados. 
        [Test]
        public void WizardEquipSpells()
        {
            wizardTest.EquipSpellbook(spellsBookTest);
            spellsBookTest.Spells = new Spell[]{spellTest1, spellTest2, spellTest3, spellTest4};
            int expected = spellTest1.AttackValue + spellTest2.AttackValue + spellTest3.AttackValue + spellTest4.AttackValue;
            Assert.AreEqual(expected, wizardTest.AttackValue);
        }

        // Se prueba si los hechizos funcionan correctamente durante la defensa
        [Test]
        public void WizardDefenseSpells()
        {
            wizardTest.EquipSpellbook(spellsBookTest);
            spellsBookTest.Spells = new Spell[]{ new Spell() };
            int expecteddamage = 0;
            dwarfTest.Equip(axeTest);
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
            wizardTest.EquipSpellbook(spellsBookTest);
            spellsBookTest.Spells = new Spell[]{ new Spell() };
            int expecteddamage = 0;
            dwarfTest.Equip(armorTest);
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
            wizardTest.EquipSpellbook(spellsBookTest);
            spellsBookTest.Spells = new Spell[]{ new Spell() };
            wizardTest.Equip(staffTest);
            int expecteddamage = 0;
            dwarfTest.Equip(axeTest);
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
            wizardTest.EquipSpellbook(spellsBookTest);
            spellsBookTest.Spells = new Spell[]{};
            wizardTest.Equip(staffTest);
            int expecteddamage = 0;
            dwarfTest.Equip(armorTest);
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
            wizardTest.EquipSpellbook(spellsBookTest);
            spellsBookTest.Spells = new Spell[]{ new Spell() };
            wizardTest.Equip(staffTest);
            int expecteddamage = 0;
            dwarfTest.Equip(armorTest);
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
            wizardTest.Equip(staffTest);
            Assert.AreEqual(expected, wizardTest.DefenseValue);
        }

        // Se prueba si al equipar un baculo se modifica correctamente el ataque
        [Test]
        public void WizardEquipStaffAttack()
        {
            int expected = wizardTest.AttackValue + staffTest.AttackValue;
            wizardTest.Equip(staffTest);
            Assert.AreEqual(expected, wizardTest.AttackValue);  
        }

        // Se prueba si al desequipar un baculo se modifica correctamente el ataque
        [Test]
        public void WizardUnequipStaffAttack()
        {
            int expected = wizardTest.AttackValue;
            wizardTest.Equip(staffTest);
            wizardTest.Unequip(staffTest);
            Assert.AreEqual(expected, wizardTest.AttackValue);
        }

        // Se prueba si al desequipar un baculo se modifica correctamente la defensa
        [Test]
        public void WizardUnequipStaffDefense()
        {
            int expected = wizardTest.DefenseValue;
            wizardTest.Equip(staffTest);
            wizardTest.Unequip(staffTest);
            Assert.AreEqual(expected, wizardTest.DefenseValue);
        }
    }
}