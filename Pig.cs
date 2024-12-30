using System.Collections;
using UnityEngine;

public class Pig : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isMoving = false;
    private Vector2 lastPosition;

    public float destroyDelay = 2f; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastPosition = rb.position; 
    }

    void Update()
    {
        
        if (Vector2.Distance(rb.position, lastPosition) > 0.1f && !isMoving)
        {
            isMoving = true;
            StartCoroutine(DestroyAfterDelay());
        }
        lastPosition = rb.position; 
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }
}