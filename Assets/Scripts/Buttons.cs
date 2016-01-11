using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

	public void StartButton(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
