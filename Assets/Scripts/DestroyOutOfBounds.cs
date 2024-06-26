using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float bottomBound = -5f;

    void Update()
    {
        if (transform.localPosition.z < bottomBound)
        {
            Destroy(gameObject);
        }
    }
}
