using UnityEngine;

namespace Assets.Scripts
{
    public class FloorScript : MonoBehaviour
    {

        [SerializeField] private GameObject _floorTexture;
        private const int Width = 10;
        private const int Height = 10;

        void Start ()
        {
            for (int x = -Width; x <= Width; x++)
            {
                for (int y = -Height; y <= Height; y++)
                {
                        GameObject each = Instantiate(_floorTexture, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                        each.transform.parent = transform;
                }
            }
        }
    }
}
