
using UnityEngine;

public class PizzaThrower : MonoBehaviour
{
    public GameObject pizzaPrefab;
    public float spawnInterval = 1.0f;
    public float speed = 5.0f;

    private int pizzaCount = 0;

    void Start()
    {
        InvokeRepeating("ThrowPizza", 0f, spawnInterval);
    }

    void ThrowPizza()
    {
        if (pizzaPrefab == null || pizzaCount >= 10)
            return;

        GameObject pizza = Instantiate(
            pizzaPrefab,
            transform.position,
            pizzaPrefab.transform.rotation
        );

        // Stop the old Z-axis movement
        MoveForward oldMove = pizza.GetComponent<MoveForward>();
        if (oldMove != null)
            oldMove.enabled = false;

        // Move along the X-axis
        Rigidbody rb = pizza.GetComponent<Rigidbody>();
        if (rb == null)
            rb = pizza.AddComponent<Rigidbody>();

        rb.useGravity = false;
        rb.isKinematic = false;
        rb.linearVelocity = Vector3.right * speed;

        pizzaCount++;
    }
}
