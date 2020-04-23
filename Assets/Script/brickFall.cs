using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickFall : MonoBehaviour
{
    public float fallDelay = 2.0f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine(DropBrick());
        }
    }

    // Update is called once per frame
    IEnumerator DropBrick()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.isKinematic = false;
    }
}
