using UnityEngine;

public class RotateZ : MonoBehaviour
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
       
        float zOffset = Mathf.Sin(Time.time * speed) * distance;
        transform.position = startPosition + new Vector3(0, 0, zOffset);
    }
}
