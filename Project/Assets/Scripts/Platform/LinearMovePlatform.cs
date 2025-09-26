using UnityEngine;

public class LinearMovePlatform : MonoBehaviour
{
    // 선형 이동

    Vector3 station1;
    [SerializeField] Vector2 station2;

    Vector2 direction;


    private void Start()
    {
        station1 = transform.position;

        Caldir();
    }

    private void FixedUpdate()
    {

    }

    void Caldir()
    {
        direction = new Vector2(Mathf.Abs(station1.x/station2.x), Mathf.Abs(station1.y/station2.y));
    }

    
}
