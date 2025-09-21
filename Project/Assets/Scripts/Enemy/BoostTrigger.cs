using UnityEngine;

public class BoostTrigger : MonoBehaviour
{
    private BoostEnemy boostEnemy;

    private void Awake()
    {
        boostEnemy = GetComponentInParent<BoostEnemy>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player °¨ÁöµÊ");
            boostEnemy.StartBoost(other.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            boostEnemy.StopBoost();
        }
    }
}
