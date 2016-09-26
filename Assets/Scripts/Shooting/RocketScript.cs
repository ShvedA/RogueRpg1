using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Shooting {
    class RocketScript : ReloadParticleShootingScript
    {
        public RocketScript() : base(20, 2) {}

        void Update()
        {
            ToUpdate();
        }

        public override string GetName() {
            return "Rocket";
        }
    }
}
