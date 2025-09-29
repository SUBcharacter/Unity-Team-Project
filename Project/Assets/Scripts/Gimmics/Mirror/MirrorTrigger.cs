using UnityEngine;

public class MirrorTrigger : MonoBehaviour
{
    // 특정 구간에 들어갔을 때 미러 플레이어가 활성화 되야함 그니까 지금 활성화 되면 안됨 
    [SerializeField] private GameObject mirrorPrefab;      // private GameObjectmirrorPrefab으로 바꾸기 
    [SerializeField] private float mirrorCenterX;

   public GameObject mirrorInstance;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || mirrorInstance == null)
        {
            mirrorInstance = Instantiate(mirrorPrefab);
            MirrorPlayer mp = mirrorInstance.GetComponent<MirrorPlayer>();
            mp.mirrorCenterX = mirrorCenterX;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Playter") || mirrorInstance != null)
        {
            // 1. 비활성화 시킨다.
            mirrorPrefab.SetActive(false);      // 일단일케 고
            // 2. Destroy를 한다.
        }
    }
}
