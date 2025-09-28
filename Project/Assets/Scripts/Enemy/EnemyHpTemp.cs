using UnityEngine;

public class EnemyHpTemp : MonoBehaviour, IResetable
{
    // CJH 적 피 관리 임시로 만들어둠
    [SerializeField] int hp = 3; // n번 총 맞으면 죽음
    int nowHp;

    void Start()
    {
        nowHp = hp;
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("데미지");
        if (collision.gameObject.CompareTag("Bullet"))
        {
            nowHp -= 1;
        }
        if (nowHp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void Init()
    {
        nowHp = hp;
        gameObject.SetActive(true);
    }

}
