using UnityEngine;

public class SpikeTrap : Trap
{
    Trigger trigger;

    [SerializeField] Vector3 initPos;
    [SerializeField] float launchForce;

    protected override void Awake()
    {
        Debug.Log("������ũ���� �õ�");

        trigger = GetComponentInParent<Trigger>();
        initPos = transform.position;
        base.Awake();
        Init();
    }

    private void Update()
    {
        Activate(trigger.trigger);
    }

    public override void Init()
    {
        gameObject.SetActive(true);
        trigger.init();
        transform.position = initPos;
        rigid.linearVelocityY = 0;
    }

    public override void Activate(bool trigger)
    {
        if(trigger)
        {
            rigid.linearVelocity = transform.up.normalized * launchForce;
        }
        
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            gameObject.SetActive(false);
        }
    }
}
