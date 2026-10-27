using Unity.VisualScripting;
using UnityEngine;

public class MenuParallax : MonoBehaviour
{
    public float offsetMultiplyer = 1f;
    public float smoothTime = .3f;

    private Vector2 startPosition;
    private Vector3 velocity;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        Vector2 offset = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        transform.position = Vector3.SmoothDamp(transform.position, startPosition + (offset * offsetMultiplyer), ref velocity, smoothTime);
    }

}
