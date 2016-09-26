using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Shooting {
    internal class RocketScript : ReloadParticleShootingScript {
        public RocketScript() : base(20, 2) {}

        private void Update() {
            ToUpdate();
        }
    }
}