using System.Collections;
using UnityEngine;

public class Save : MonoBehaviour
{
    public Sprite[] sprites;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        Debug.Log("���̺� �õ�");

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Hit()
    {
        GameManager gm = GameManager.instance;
        Vector3 cameraPos = transform.parent.position;
        gm.saveManager.currentData.playerPos = gm.player.transform.position;
        gm.saveManager.currentData.cameraPos = new Vector3(cameraPos.x, cameraPos.y, -10);

        StartCoroutine(LightOn());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
            return;
        Hit();
    }

    private IEnumerator LightOn()
    {
        spriteRenderer.sprite = sprites[1];
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.sprite = sprites[0];
    }
}
