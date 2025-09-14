using UnityEngine;

// �÷��̾ Ư�� ��ġ�� �������� �� ���� Ȱ��ȭ�Ǵ� ��ũ��Ʈ
public class ShyEnemy_Distance : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] private float activateDistance = 5.0f; // �÷��̾ �����ؾ� Ȱ��ȭ�Ǵ� �Ÿ�
    private ShyEnemy shyEnemy;

    // private bool hasActivated;

    private void Awake()
    {
        shyEnemy = GetComponent<ShyEnemy>();
        
    }

    private void Update()
    {
        //if(!hasActivated) { return; }

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= activateDistance)
        {
            Debug.Log("�÷��̾� Ư�� ��ġ ���� �� Ȱ��ȭ ����");
            shyEnemy.Activate();

        }
        else
        {
            shyEnemy.Deactivate();

        }

    }

}
