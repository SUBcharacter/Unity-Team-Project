using UnityEngine;

public abstract class Trap : MonoBehaviour, IResetable
{
    protected Rigidbody2D rigid;

    public abstract void Activate(bool trigger = false);
    public abstract void Init();

    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    

}
