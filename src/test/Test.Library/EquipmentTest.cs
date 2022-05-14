using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class EquipmentTest
    {
        private ICharacter archerTest;
        private ICharacter knightTest;
        private ICharacter dwarfTest;
        private ICharacter wizardTest;
        private Armor armorTest;
        private Staff staffTest;
        private Axe axeTest;

        [SetUp]
        public void Setup()
        {
            archerTest = new Archer("Raul");
            knightTest = new Knight("Tusam");
            dwarfTest = new Dwarf("Thomas");
            wizardTest = new Wizard("Gandalf");
            staffTest = new Staff();
            armorTest = new Armor();
            axeTest = new Axe();
        }

        // Se prueba si al equipar un item de ataque se modifica correctamente el ataque
        [Test]
        public void DwarfEquipAxeAttack()
        {
            int expected = dwarfTest.AttackValue + axeTest.AttackValue;
            dwarfTest.AddItem(axeTest);
            Assert.AreEqual(expected, dwarfTest.AttackValue);  
        }

        // Se prueba si al desequipar un item de ataque se modifica correctamente el ataque
        [Test]
        public void DwarfUnequipAxeAttack()
        {
            int expected = dwarfTest.AttackValue;
            dwarfTest.AddItem(axeTest);
            dwarfTest.RemoveItem(axeTest);
            Assert.AreEqual(expected, dwarfTest.AttackValue);
        }

        // Se prueba si al desequipar un item de ataque se modifica correctamente la defensa
        [Test]
        public void DwarfUnequipAxeDefense()
        {
            int expected = dwarfTest.DefenseValue;
            dwarfTest.AddItem(axeTest);
            dwarfTest.RemoveItem(axeTest);
            Assert.AreEqual(expected, dwarfTest.DefenseValue);
        }

        // Se prueba si al equipar un item de defensa se modifica correctamente la defensa
        [Test]
        public void DwarfEquipHelArmorDefense()
        {
            int expected = dwarfTest.DefenseValue + armorTest.DefenseValue;
            dwarfTest.AddItem(armorTest);
            Assert.AreEqual(expected, dwarfTest.DefenseValue);
        }

        // Se prueba si al desequipar un item de defensa se modifica correctamente el ataque
        [Test]
        public void DwarfUnequipHelArmorAttack()
        {
            int expected = dwarfTest.AttackValue;
            dwarfTest.AddItem(armorTest);
            dwarfTest.RemoveItem(armorTest);
            Assert.AreEqual(expected, dwarfTest.AttackValue);
        }

        // Se prueba si al desequipar un item de defensa se modifica correctamente la defensa
        [Test]
        public void DwarfUnequipHelArmorDefense()
        {
            int expected = dwarfTest.DefenseValue;
            dwarfTest.AddItem(armorTest);
            dwarfTest.RemoveItem(armorTest);
            Assert.AreEqual(expected, dwarfTest.DefenseValue);
        }

    }
}