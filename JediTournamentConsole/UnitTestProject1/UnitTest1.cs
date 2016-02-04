using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntitiesLayer;

namespace UnitTestProject1
{
   [TestClass]
   public class UnitTest1
   {
      [TestMethod]
      public void TestJedi()
      {
         Caracteristiques Force1 = new Caracteristiques(EDefCaracteristique.Force, "Force", ETypeCaracteristique.Jedi, 666, 10);
         Caracteristiques Defense1 = new Caracteristiques(EDefCaracteristique.Defense, "Defense", ETypeCaracteristique.Jedi, 666, 12);
         Caracteristiques Vie1 = new Caracteristiques(EDefCaracteristique.Sante, "Sante", ETypeCaracteristique.Jedi, 666, 14);
         Caracteristiques Chance1 = new Caracteristiques(EDefCaracteristique.Chance, "Chance", ETypeCaracteristique.Jedi, 666, 16);

         Caracteristiques[] Un = { Force1, Defense1, Vie1, Chance1 };

         Jedi jedi = new Jedi(Un, true, "Lemoine", 1);
         Assert.AreEqual("Lemoine", jedi.Nom);
      }
   }
}
