using UnityEngine;

public class RotateX : MonoBehaviour
{
    public float speed = 3f;          
    public float distance = 5f;      

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; 
    }

    void Update()
    {
        
        float xOffset = Mathf.Sin(Time.time * speed) * distance;
        transform.position = startPosition + new Vector3(xOffset, 0, 0);
    }
}
