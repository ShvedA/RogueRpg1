using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {

    public float projectileSpeed;

    public GameObject Projectile;

    void Start () {
	
	}
	
	void Update () {

        if (Input.GetMouseButton(0))
        {
            Fire();
        }

    }

    private void Fire()
    {
        var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
        position = Camera.main.ScreenToWorldPoint(position);
        var go = Instantiate(Projectile, transform.position, Quaternion.identity) as GameObject;
        Physics2D.IgnoreCollision(go.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        var projectileVector = new Vector2(position.x - transform.position.x, position.y - transform.position.y);
        if (projectileVector.x >= 0)
        {
            go.transform.Rotate(new Vector3(0, 0, Mathf.Atan(projectileVector.y / projectileVector.x) / Mathf.PI * 180));
        }
        else if (projectileVector.x < 0)
        {
            go.transform.Rotate(new Vector3(0, 0, 180 + Mathf.Atan(projectileVector.y / projectileVector.x) / Mathf.PI * 180));
        }
        go.transform.parent = transform;
        //go.transform.LookAt(position);
        go.GetComponent<Rigidbody2D>().AddForce(Vector2.ClampMagnitude(projectileVector, 0.001f) * 1000 * projectileSpeed);

    }

}
