namespace Assets.Scripts.Shooting
{
    class TorchScript : ParticleShootingScript
    {
        public TorchScript() : base(7) {}

        public override string GetName() {
            return "Torch";
        }
    }
}
