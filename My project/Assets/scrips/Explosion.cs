using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float radius = 4f;
    public float force = 8f;

    void Start()
    {
        // Explosion applies force to all nearby objects as soon as it is instantiated.
        Collider[] affected = Physics.OverlapSphere(transform.position, radius);

        foreach (var col in affected)
        {
            Rigidbody rb = col.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius, force * 0.5f, ForceMode.Impulse);
            }
        }

        // Destroy the explosion object after 5 seconds
        Destroy(gameObject, 5f);
    }
}
