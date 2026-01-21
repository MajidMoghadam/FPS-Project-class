using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float time = 0.1f; // lifetime in seconds

    void Start()
    {
        Destroy(gameObject, time); // auto-destroy after 'time'
    }
}
