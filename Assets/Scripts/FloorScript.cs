using UnityEngine;

namespace Assets.Scripts
{
    public class FloorScript : MonoBehaviour
    {

        [SerializeField] private GameObject _floorTexture;
        [SerializeField] private int Width;
        [SerializeField] private int Height;
        [SerializeField] private float Size;

        void Start ()
        {
            for (int x = -Width; x <= Width; x++)
            {
                for (int y = -Height; y <= Height; y++)
                {
                        GameObject each = Instantiate(_floorTexture, new Vector3(x * Size, y * Size, 0), Quaternion.identity) as GameObject;
                        each.transform.parent = transform;
                }
            }
        }
    }
}
