using UnityEngine;
using System.Collections;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] private GameObject fireballPrefab;

    public float Speed = 3.0f;
    public float ObstacleRange = 5.0f;

    private GameObject _fireball;

    private bool _alive;

    private void Start()
    {
        _alive = true;
    }

    private void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, Speed * Time.deltaTime);

            Ray ray = new(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    if (_fireball == null)
                    {
                        _fireball = Instantiate(fireballPrefab) as GameObject;
                        _fireball.transform.position =
                        transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < ObstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}