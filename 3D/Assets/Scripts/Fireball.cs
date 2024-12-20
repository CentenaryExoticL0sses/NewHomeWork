using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float Speed = 10.0f;

    public int Damage = 1;

    private void Update()
    {
        transform.Translate(0, 0, Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerCharacter>(out var player))
        {
            player.Hurt(Damage);
            Debug.Log("Player hit");
        }

        Destroy(gameObject);
    }
}

