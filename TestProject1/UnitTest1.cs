using System.Xml.Linq;
using Assignment2;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Keeper abed =new Keeper();
        

        [TestMethod]
        public void InsertAnimal()
        {
            abed.AddHamster("abd", 40);
            abed.AddCat("bbd", 50);
            var expected = new List<string>();
            expected.AddRange(new[] { "abd", "bdd" });

           
            Assert.AreEqual(("abd",40), abed.GetAnimal()[0]);
            Assert.AreEqual(("bbd",50), abed.GetAnimal()[1]);
            Assert.AreEqual(expected.Count, abed.GetAnimal().Count);
        }
        [TestMethod]
        public void InsertMood()
        {
            //add days mood
            //day1
            abed.KBlue();
            //day2
            abed.KJoyfull();
            //day3
            abed.KUsual();
            var expected = new List<string>();
            expected.AddRange(new[] { "Blue", "Joyfull", "Usual" });
           
            Assert.AreEqual("Blue", abed.GetMood()[0]);
            Assert.AreEqual("Joyfull", abed.GetMood()[1]);
            Assert.AreEqual("Usual", abed.GetMood()[2]);
            Assert.AreEqual(expected.Count, abed.GetMood().Count);
        }
        [TestMethod]
        public void CheckMaxAnimal()
        {
            abed.AddHamster("Boss", 17);
            abed.AddCat("Kitty", 10);
            abed.KBlue();
            abed.KBlue();
            abed.KUsual();
            List<string> actual=abed.Maximum();
            Assert.AreEqual("Boss", actual[0]);
            Assert.AreEqual("Kitty", actual[1]);
            Assert.AreEqual("Kitty", actual[2]);

        }
        [TestMethod]
        public void CheckExceptions()
        {
            Assert.ThrowsException<Keeper.EmptyListException>(abed.Maximum);
            abed.AddCat("kitty", 69);
            abed.KJoyfull();
            Assert.ThrowsException<Keeper.ExOutOfRange>(abed.Maximum) ;
            abed.AddHamster("glock", 2);
            abed.KBlue();
            abed.KBlue();
            abed.KBlue();
            abed.KBlue();
            

        }
        [TestMethod]
        public void CheckExceptionDeath()
        {
            abed.AddHamster("katr", 10);
            abed.AddTarantula("Sped", 3);
            abed.AddCat("Kitten", 9);

            abed.KBlue();
            abed.KBlue();
            abed.KBlue();
            abed.KBlue();
            abed.KBlue();
            Assert.ThrowsException<Keeper.AllAnimalsDiedExeption>(abed.Maximum);
        }
        [TestMethod]
        public void CheckMoodChange()
        {
            abed.AddHamster("katr", 10);
            abed.AddTarantula("Sped", 15);
            abed.AddCat("Kitten", 9);
            abed.KUsual();
            abed.KJoyfull();
            abed.KUsual();
            abed.KBlue();
            abed.KBlue();
            List<string> beforechange = new List<string>();
            beforechange = abed.GetMood();
            abed.Maximum();
            List<string> afterchange = new List<string>();
            afterchange = abed.GetMood();
            Assert.AreNotEqual(beforechange, afterchange);
            Assert.AreEqual("Usual", beforechange[0]);
            Assert.AreEqual("Joyfull", afterchange[0]);
            Assert.AreEqual("Blue", beforechange[4]);
            Assert.AreEqual("Usual", afterchange[4]);


        }
    }
}