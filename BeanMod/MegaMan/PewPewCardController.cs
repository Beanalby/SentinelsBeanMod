using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;
using System.Collections;

namespace BeanMod.MegaMan
{
    class PewPewCardController : CardController
    {
        private int damageAmount = 2;
        private int numberOfTargets = 1;

        public PewPewCardController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController)
        {
        }
        public override IEnumerator Play()
        {
            IEnumerator e;
            e = this.GameController.SelectTargetsAndDealDamage(
                this.DecisionMaker,
                new DamageSource(this.GameController, this.CharacterCard),
                damageAmount,
                DamageType.Projectile,
                numberOfTargets,
                false,
                numberOfTargets,
                cardSource:GetCardSource()
            );

            if (UseUnityCoroutines)
            {
                yield return this.GameController.StartCoroutine(e);
            }
            else
            {
                this.GameController.ExhaustCoroutine(e);
            }
        }
    }
}
