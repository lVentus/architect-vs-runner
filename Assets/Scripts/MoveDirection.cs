using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDirection : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 direction = Vector3.forward;

    void Update()
    {
        if (gameObject.CompareTag("Obstacle"))
        {
            speed = Singleton.Instance.obstacleSpeed;
        }
        transform.Translate(direction * speed * Time.deltaTime, Space.Self);
    }
}
