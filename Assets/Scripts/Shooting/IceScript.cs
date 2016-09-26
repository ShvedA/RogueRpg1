namespace Assets.Scripts.Shooting
{
    class IceScript : ParticleShootingScript
    {
        public IceScript() : base(5) {}

        public override string GetName() {
            return "Ice";
        }
    }
}
