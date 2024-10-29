using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour
{
    public float Speed = 3.0f;

    void Update()
    {
        transform.Rotate(0, Speed, 0);
    }
}
