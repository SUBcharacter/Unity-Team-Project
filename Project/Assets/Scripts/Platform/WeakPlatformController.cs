using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WeakPlatform : MonoBehaviour
{
    private bool isCracking = false;
    private Collider2D col;
    private TilemapRenderer tile;
    private Animator animator;

    private void Awake()
    {
        col = GetComponent<Collider2D>();

        tile = GetComponentInChildren<TilemapRenderer>(); // 자식 타일맵 찾기.. 추후 수정 가능
        if (tile == null)
        {
            Debug.Log("TilemapRenderer가 자식에 없습니다!");
        }

        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isCracking && collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("약한 발판 충돌");

            StartCoroutine(Crack());
        }
    }

    IEnumerator Crack()
    {
        isCracking = true;

        if (animator != null)
            animator.SetBool("Shake", true);

        yield return new WaitForSeconds(2.0f);

        col.enabled = false;
        tile.enabled = false;

        if (animator != null)
            animator.SetBool("Shake", false);

        yield return new WaitForSeconds(4.0f); // 다시 생성

        col.enabled = true;
        tile.enabled = true;

        isCracking = false;
    }
}
