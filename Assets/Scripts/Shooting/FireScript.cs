namespace Assets.Scripts.Shooting
{
    public class FireScript : ParticleShootingScript
    {
        public FireScript() : base(10)
        {
            chargeCost = 2;
            chargeCharging = 0.2;
        }

        public override string GetName() {
            return "Fire";
        }
    }
}
