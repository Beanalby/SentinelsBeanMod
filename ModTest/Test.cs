using NUnit.Framework;
using System;
using Handelabra.Sentinels.Engine.Model;
using Handelabra.Sentinels.Engine.Controller;
using System.Linq;
using System.Collections;
using Handelabra.Sentinels.UnitTest;
using System.Collections.Generic;
using BeanMod.MegaMan;

namespace BeanModTest
{
    [TestFixture()]
    public class Test : BaseTest
    {
        protected TurnTakerController megaman { get { return FindHero("MegaMan");  } }

        [Test()]
        public void TestModWorks()
        {
            SetupGameController("CitizenDawn", "BeanMod.MegaMan", "Megalopolis");

            Assert.AreEqual(3, this.GameController.TurnTakerControllers.Count());

            Assert.IsNotNull(megaman);
            // no custom TurnTakerController for Mega Man
            Assert.IsInstanceOf(typeof(MegaManCharacterCardController), megaman.CharacterCardController);
            Assert.IsNotNull(dawn);
            Assert.IsNotNull(env);

            Assert.AreEqual(80, dawn.CharacterCard.HitPoints);
            Assert.AreEqual(30, megaman.CharacterCard.HitPoints);
            QuickHPStorage(dawn, megaman);

            StartGame();
            QuickHPCheck(0, 0);

            // Deals 2 damage
            SelectCardsForNextDecision(dawn.CharacterCard);
            PlayCard("PewPew");
            QuickHPCheck(-2, 0);
        }

        [Test()]
        public void TestStockCards()
        {
            SetupGameController("CitizenDawn", "TheWraith", "Megalopolis");

            Assert.AreEqual(3, this.GameController.TurnTakerControllers.Count());

            Assert.IsNotNull(wraith);
            Assert.IsNotNull(dawn);

            Assert.AreEqual(80, dawn.CharacterCard.HitPoints);
            Assert.AreEqual(26, wraith.CharacterCard.HitPoints);
            QuickHPStorage(dawn, wraith);

            StartGame();
            QuickHPCheck(0, 0);

            // Deals 2 damage
            SelectCardsForNextDecision(dawn.CharacterCard);
            PlayCard("ThroatJab");
            QuickHPCheck(-2, 0);
        }

    }
}
