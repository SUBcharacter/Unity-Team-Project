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

        tile = GetComponent<TilemapRenderer>(); // Ÿ�ϸ� ã��. ��������Ʈ �������� �����ϰ� �ȴٸ� ������ ��
        if (tile == null)
        {
            Debug.Log("TilemapRenderer�� �����ϴ�");
        }

        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isCracking && collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("�ν��� ���� �浹");

            StartCoroutine(Crack());
        }
    }

    IEnumerator Crack()
    {
        isCracking = true;

        if (animator != null) { animator.SetBool("Shake", true); }

        yield return new WaitForSeconds(2.0f);

        col.enabled = false;
        tile.enabled = false;

        if (animator != null) { animator.SetBool("Shake", false); }
            
        yield return new WaitForSeconds(4.0f); // �ٽ� ����

        col.enabled = true;
        tile.enabled = true;

        isCracking = false;
    }
}
