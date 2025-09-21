using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float stunDuration = 3f; // 3�� ����
    private bool isStunned = false;
    private Vector3 lastCheckpoint;

    private Rigidbody2D rb;
    private PlayerMove playerMove; // 

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMove = GetComponent<PlayerMove>();
    }

    public void SetCheckpoint(Vector3 point)
    {
        lastCheckpoint = point;
    }

    public void StunAndFall()
    {
        if (isStunned) return;
        StartCoroutine(StunRoutine());
    }

    IEnumerator StunRoutine()
    {
        isStunned = true;
        playerMove.enabled = false; // �̵�/���� ����

        // �浹 �� ƨ��� ���� ����
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(new Vector2(-2f, 5f), ForceMode2D.Impulse);

        // ���⼭ �ִϸ��̼��̳� ������ �־ ��

        yield return new WaitForSeconds(stunDuration); //  3�� ���

        Respawn();
    }

    void Respawn()
    {
        // ���̺� ���� ������ ����, ������ ���� ��ġ��
        transform.position = lastCheckpoint != Vector3.zero ? lastCheckpoint : Vector3.zero;

        playerMove.enabled = true;
        isStunned = false;
    }
}
