using UnityEngine;

public class Lazer : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private float lazerSpeed = 10f;

    private void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.velocity = transform.forward * lazerSpeed;

        DestroyLazer();
    }

    public void DestroyLazer()
    {
        Destroy(this.gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            IDamageable obj = other.GetComponent<IDamageable>();
            if (obj != null)
            {
                obj.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
