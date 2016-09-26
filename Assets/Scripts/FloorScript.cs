using UnityEngine;

namespace Assets.Scripts {
    public class FloorScript : MonoBehaviour {
        [SerializeField] private GameObject floorTexture;
        [SerializeField] private int width;
        [SerializeField] private int height;
        [SerializeField] private float size;
        [SerializeField] private float scale;

        private void Start() {
            for (var x = -width; x <= width; x++) {
                for (var y = -height; y <= height; y++) {
                    var each = Instantiate(floorTexture, new Vector3(x * size * scale, y * size * scale, 0), Quaternion.identity) as GameObject;
                    each.transform.parent = transform;
                }
            }
        }
    }
}