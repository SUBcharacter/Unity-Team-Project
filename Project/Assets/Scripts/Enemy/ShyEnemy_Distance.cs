using UnityEngine;

// 플레이어가 특정 위치에 도달했을 때 적이 활성화되는 스크립트
public class ShyEnemy_Distance : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] private float activateDistance = 5.0f; // 플레이어가 접근해야 활성화되는 거리
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
            Debug.Log("플레이어 특정 위치 도달 적 활성화 시작");
            shyEnemy.Activate();

        }
        else
        {
            shyEnemy.Deactivate();

        }

    }

}
