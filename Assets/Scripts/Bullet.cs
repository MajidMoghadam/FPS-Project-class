
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;     // bullet speed
    public float lifetime = 3f;   // destroy after this time

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // get Rigidbody

        rb.linearVelocity = -transform.right * speed; // set forward motion

        Destroy(gameObject, lifetime); // auto-destroy after lifetime
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); // destroy on collision
    }
}
