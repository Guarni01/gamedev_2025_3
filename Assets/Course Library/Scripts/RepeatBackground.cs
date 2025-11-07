using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startX;
    private float reapeatWidth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       startX = transform.position;
       reapeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startX.x - reapeatWidth) 
        {
            transform.position = startX;
        }
    }
}
