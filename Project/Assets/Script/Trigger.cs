using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool trigger = false;

    private void Awake()
    {
        Debug.Log("Ʈ���� �õ�");

    }

    public void init()
    {
        trigger = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;
        trigger = true;
    }
}

