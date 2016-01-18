using UnityEngine;

namespace Assets.Scripts.Helper
{
    public class AngleHelper
    {

        private static readonly Vector2 ZeroVectorForParticles = new Vector2(1, 0);
        private static readonly Vector2 ZeroVectorForTurningAround = new Vector2(0, -1);

        public static float GetAngleForParticles(Vector2 vectorFromCenter)
        {
            return GetAngle(vectorFromCenter, ZeroVectorForParticles);
        }

        public static float GetAngleForTurningAround(Vector2 vectorFromCenter)
        {
            return GetAngle(vectorFromCenter, ZeroVectorForTurningAround);
        }

        private static float GetAngle(Vector2 vectorFromCenter, Vector2 zeroVector)
        {
            var angle = Vector2.Angle(vectorFromCenter, zeroVector);
            if (zeroVector.x == 0)
            {
                return vectorFromCenter.x < 0 ? 360 - angle : angle;
            }
            return vectorFromCenter.y < 0 ? 360 - angle : angle;
        }
    }
}
