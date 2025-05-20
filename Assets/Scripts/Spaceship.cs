using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private Transform firePosition;
    [SerializeField] private GameObject lazerPrefab;

    void Start()
    {
    }

    void Update()
    {
        Movement();
        ShootLazer();
    }

    private void Movement()
    {
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        /*if (Input.GetKey(KeyCode.LeftShift) && transform.position.y < 20f)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftControl) && transform.position.y > 2.6f)
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }*/

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }

        transform.Translate(Vector3.forward * move);
        transform.Rotate(Vector3.up * rotation);

        Vector3 newPos = transform.position;
        newPos.y = Mathf.Clamp(transform.position.y, 2.6f, 20f);
        transform.position = newPos;
    }

    private void ShootLazer()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(lazerPrefab, firePosition.transform.position, firePosition.rotation);
        }
    }
}
