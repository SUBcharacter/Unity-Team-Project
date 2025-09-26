using UnityEngine;

public class LinearMovePlatform : MonoBehaviour
{
    // ���� �̵�

    [SerializeField] Vector3 station2;
    [SerializeField] float speed = 2f;

    private Vector3 station1;
    private Vector2 direction;
    private bool toStation2;

    private void Start()
    {
        station1 = transform.position;
        toStation2 = true;
        Caldir();
    }

    void Caldir()
    {
        Vector3 destination;

        if (toStation2) { destination = station2; }
        else { destination = station1; }

        direction = new Vector2(destination.x - transform.position.x, destination.y - transform.position.y).normalized;
    }

    private void MovePlatform()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        float distance;

        if (toStation2)
        {
            distance = Vector3.Distance(transform.position, station2);
        }
        else
        {
            distance = Vector3.Distance(transform.position, station1);
        }

        if (distance <= 0.05f) // ���� ���������� ���� ����. �� ���̸� �ν� �� �� ��.
        {
            toStation2 = !toStation2;
            Caldir();
        }
    }

    private void FixedUpdate()
    {
         MovePlatform();
    }


    
}
