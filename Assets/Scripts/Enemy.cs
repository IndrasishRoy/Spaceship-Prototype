using System.Collections;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private TextMeshProUGUI dmgText;
    [SerializeField] private float txtSpeed = 2f;
    [SerializeField] private int health = 20;

    private void Start()
    {
        dmgText = GetComponentInChildren<TextMeshProUGUI>();
        dmgText.gameObject.SetActive(false);
    }
    
    public void TakeDamage(int amount)
    {
        if(health > 0)
        {
            health -= amount;
            StartCoroutine(TextPopUp(amount));
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator TextPopUp(int amt)
    {
        dmgText.text = amt.ToString();
        dmgText.gameObject.SetActive(true);

        float t = 0;

        while (t < 0.6f)
        {
            dmgText.transform.position += Vector3.up * txtSpeed * Time.deltaTime;
            t += Time.deltaTime;
            yield return null;
        }

        dmgText.gameObject.SetActive(false);
        dmgText.transform.position = transform.position;
    }
}
