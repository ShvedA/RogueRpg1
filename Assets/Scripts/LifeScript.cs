using UnityEngine;
using System.Collections;

public class LifeScript : MonoBehaviour {

    public float life;

	
	void Update () {
	    if (life <= 0)
        {
            //Destroy(gameObject);
            life = 100;
            transform.position = new Vector3(15f, 7f);
        }
	}
}
