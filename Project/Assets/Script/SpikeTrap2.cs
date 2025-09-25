using System.Collections;
using UnityEngine;

public class SpikeTrap2 : Trap
{
    Trigger trigger;

    [SerializeField] Vector3 initPos;

    protected override void Awake()
    {
        trigger = GetComponentInParent<Trigger>();
        initPos = transform.position;
    }

    void Update()
    {
        Activate(trigger.trigger);
    }

    public override void Init()
    {
        trigger.init();
        transform.position = initPos;
    }

    public override void Activate(bool trigger)
    {
        if (trigger)
        {
            
        }
    }

    // private IEnumerator GoUp()
    // {
    //     transform.position = Vector3.up(transform.position);
    // }

}
