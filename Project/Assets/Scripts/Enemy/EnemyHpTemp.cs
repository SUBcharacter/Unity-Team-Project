using UnityEngine;

public class EnemyHpTemp : MonoBehaviour, IResetable
{
    // CJH �� �� ���� �ӽ÷� ������
    [SerializeField] int hp = 3; // n�� �� ������ ����
    int nowHp;

    void Start()
    {
        nowHp = hp;
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("������");
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
