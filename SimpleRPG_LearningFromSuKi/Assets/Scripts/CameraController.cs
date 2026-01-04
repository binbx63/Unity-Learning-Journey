using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public float speed;
    private Vector3 offset;
    private Transform playerTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offset + playerTransform.position;
        Vector2 scroll = Input.mouseScrollDelta;

        Camera.main.fieldOfView += scroll.y;
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 37, 70);
    }
}
