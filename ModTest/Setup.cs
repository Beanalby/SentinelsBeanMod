using System;
using NUnit.Framework;
using System.Reflection;
using Handelabra.Sentinels.Engine.Model;
using BeanMod.MegaMan;
using Handelabra;

namespace BeanModTest
{
    [SetUpFixture]
    public class Setup
    {
        [OneTimeSetUp]
        public void DoSetup()
        {
            Log.DebugDelegate += Output;
            Log.WarningDelegate += Output;
            Log.ErrorDelegate += Output;

            // Tell the engine about our mod assembly so it can load up our code.
            // It doesn't matter which type as long as it comes from the mod's assembly.
            var a = Assembly.GetAssembly(typeof(MegaManCharacterCardController)); // replace with your own type
            ModHelper.AddAssembly("BeanMod", a); // replace with your own namespace
        }

        protected void Output(string message)
        {
            Console.WriteLine(message);
        }
    }
}
