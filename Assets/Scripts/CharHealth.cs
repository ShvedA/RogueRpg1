using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharHealth : MonoBehaviour {


    private float health = 100;
    private int lastHealth;
    private float healthBarWidth;
    [SerializeField] private Image healthBar = null;

    void Start () {
        if (healthBar != null)
        {
            healthBarWidth = healthBar.rectTransform.rect.width;
        }
    }

	void Update ()
	{
        if (health <= 0)
            SceneManager.LoadScene(0);
        if ((int) health != lastHealth)
            SetHealth();
    }

    public void Damage(float damage)
    {
        health -= damage;
    }

    public void SetHealth()
    {
        lastHealth = (int)health;
        //healthText.text = lastHealth.ToString();
        healthBar.rectTransform.sizeDelta = new Vector2(((float)lastHealth - 100) / 100 * healthBarWidth, 20);
        healthBar.color = new Color((Mathf.Log(100 - (float)lastHealth) / Mathf.Log(100)), (float)lastHealth / 100, 0f);
    }

}
