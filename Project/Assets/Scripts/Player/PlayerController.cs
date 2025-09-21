using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float stunDuration = 3f; // 3초 스턴
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
        playerMove.enabled = false; // 이동/조작 막기

        // 충돌 시 튕기는 느낌 연출
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(new Vector2(-2f, 5f), ForceMode2D.Impulse);

        // 여기서 애니메이션이나 깜빡임 넣어도 돼

        yield return new WaitForSeconds(stunDuration); //  3초 대기

        Respawn();
    }

    void Respawn()
    {
        // 세이브 지점 있으면 복귀, 없으면 시작 위치로
        transform.position = lastCheckpoint != Vector3.zero ? lastCheckpoint : Vector3.zero;

        playerMove.enabled = true;
        isStunned = false;
    }
}
