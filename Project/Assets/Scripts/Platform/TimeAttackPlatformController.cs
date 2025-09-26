using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAttackPlatformController : MonoBehaviour
{
    // platforms ¸®½ºÆ®¿¡ ÇÃ·§Æû ³ÖÀ¸¸é ÇÃ·§ÆûÀÌ ¼ø¼­´ë·Î º¸¿´´Ù »ç¶óÁü

    [SerializeField] List<GameObject> platforms;
    [SerializeField] float timer = 1f;
    private bool isStarted = false;

    private void Awake()
    {
        if (platforms == null || platforms.Count == 0)
        {
            platforms = new List<GameObject>();

            foreach (Transform child in transform)
            {
                platforms.Add(child.gameObject);
            }
        }

        foreach (GameObject gameObject in platforms)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isStarted)
        {
            isStarted = true;
            StartCoroutine("StartTimeAttack");
        }
    }

    IEnumerator StartTimeAttack()
    {
        foreach (GameObject gameObject in platforms)
        {
            gameObject.SetActive(true);
            yield return new WaitForSeconds(timer);
            gameObject.SetActive(false);
        }

        isStarted = false;
    }
}
