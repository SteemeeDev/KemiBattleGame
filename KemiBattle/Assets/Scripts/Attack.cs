using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] int damage;

    public virtual void Awake()
    {
        Debug.Log("Attack incoming!");
        StartCoroutine(attack(3));
    }

    public virtual IEnumerator attack(float delay)
    {
        Debug.Log("Normal attack!");

        yield return new WaitForSeconds(delay);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        Debug.Log("Player took damage!");
        player.GetComponent<PlayerManager>().health -= damage;
        Debug.Log(player.GetComponent<PlayerManager>().health);
    }
}
