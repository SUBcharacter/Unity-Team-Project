using UnityEngine;

public abstract class Trap : MonoBehaviour, IResetable
{
    protected Rigidbody2D rigid;

    public abstract void Activate(bool trigger = false);
    public abstract void Init();

    protected virtual void Awake()
    {
        Debug.Log("���� �õ�");

        rigid = GetComponent<Rigidbody2D>();
    }

    

}
