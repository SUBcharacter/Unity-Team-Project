using System.Collections;
using UnityEngine;

public class WeakPlatformController : MonoBehaviour
{
    [SerializeField] GameObject weakPlatform;
    void Awake()
    {
        weakPlatform = GetComponent<GameObject>();
        weakPlatform.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (weakPlatform.activeSelf == true)
            {
                StartCoroutine(Crack());
            }
        }
    }

    IEnumerator Crack()
    {
        yield return new WaitForSeconds(2.0f);

        weakPlatform.SetActive(false);

        yield return new WaitForSeconds(4.0f); // 다시 생성

        weakPlatform.SetActive(true);
    }
}
