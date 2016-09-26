using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts {
    public class Buttons : MonoBehaviour {
        public void StartButton(int scene) {
            SceneManager.LoadScene(scene);
        }

        public void ExitButton() {
            Application.Quit();
        }
    }
}