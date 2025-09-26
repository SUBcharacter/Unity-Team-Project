using System.Collections;
using UnityEngine;

public class SpikeTrap2 : Trap
{
    Trigger trigger;
    Collider2D col;

    [SerializeField] float limit = 0.4f; // �ö󰡴� ���� ����
    [SerializeField] float speed = 0.1f; // �ӵ�
    [SerializeField] Vector3 initPos;
    [SerializeField] bool isActive;

    protected override void Awake()
    {
        trigger = GetComponentInParent<Trigger>();
        initPos = transform.position;
        isActive = false;
        col = GetComponentInParent<Collider2D>();
        col.enabled = false;
    }

    void Update()
    {
        if (trigger.trigger && !isActive)
        {
            Activate(true);
        }
    }

    public override void Init()
    {
        trigger.init();
        transform.position = initPos;
        isActive = false;
        col.enabled = false;
    }

    public override void Activate(bool trigger)
    {
        if (trigger && isActive == false)
        {
            isActive = true;
            col.enabled = true;
        }
    }

    private void FixedUpdate()
    {
        if (!isActive) { return; }

        if (transform.position.y < initPos.y + limit)
        {
            transform.position += new Vector3(0, speed, 0);
        }
    }

}
