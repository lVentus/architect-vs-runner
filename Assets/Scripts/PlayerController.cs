using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Range(0, 2)]
    private int path = 1;
    private float pathOffset;
    private void ChangePath(int newPath)
    {
        transform.localPosition = new Vector3((newPath - 1) * pathOffset, transform.localPosition.y, transform.localPosition.z);
        path = newPath;
    }

    void Start()
    {
        transform.localPosition = new Vector3((path - 1) * pathOffset, transform.localPosition.y, transform.localPosition.z);
        pathOffset = Singleton.Instance.pathOffset;
    }
    public InputAction move;

    private void Awake()
    {
        move.Enable();
        move.performed += context => { StartCoroutine(Move(context.ReadValue<Vector2>())); };
        SwipeDetection.instance.swipePerformed += context => { StartCoroutine(Move(context)); };
    }
    private IEnumerator Move(Vector2 direction)
    {
        // x : left/right y : up/down
        if (direction.x < 0 && path > 0)
        {
            ChangePath(path - 1);
        }
        else if (direction.x > 0 && path < 2)
        {
            ChangePath(path + 1);
        }
        yield return null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) && path > 0)
        {
            ChangePath(path - 1);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) && path < 2)
        {
            ChangePath(path + 1);
        }
    }
}
