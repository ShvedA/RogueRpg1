using UnityEngine;
using System.Collections;
using Assets.Scripts;
using Assets.Scripts.Monsters.Model;

public class OnCollision : MonoBehaviour
{
    [SerializeField] private int _damage = 0;

    private void OnParticleCollision(GameObject col)
    {
        if (col.gameObject.tag == "Monster")
        {
            col.gameObject.GetComponent<Monster>().Damage(_damage);
        }
    }
}
