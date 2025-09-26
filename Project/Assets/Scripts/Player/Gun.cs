using UnityEngine;

public enum GunDirection
{
    UP,DOWN,CROUCH,STAND
}

public class Gun : MonoBehaviour
{
    public GunPosition gunPos;
    public GunDirection dir;
    public bool facingRight;


    private void Awake()
    {
        Debug.Log("ÃÑ ½Ãµ¿");
    }

    private void Update()
    {
        
    }

    public void Fire()
    {
        BulletManager bm = GameManager.instance.bulletManager;
        switch(dir)
        {
            case GunDirection.UP:
                if (facingRight)
                {
                    transform.localPosition = gunPos.lookUp_Right;
                    bm.GetBullet(transform.position, Vector2.up);
                }
                else
                {
                    transform.localPosition = gunPos.lookUp_Left;
                    bm.GetBullet(transform.position, Vector2.up);
                }
                break;
            case GunDirection.DOWN:
                if (facingRight)
                {
                    transform.localPosition = gunPos.shootDown_Right;
                    bm.GetBullet(transform.position, Vector2.down);
                }
                else
                {
                    transform.localPosition = gunPos.shootDown_Left;
                    bm.GetBullet(transform.position, Vector2.down);
                }
                break;
            case GunDirection.STAND:
                if (facingRight)
                {
                    transform.localPosition = gunPos.idle_Right;
                    bm.GetBullet(transform.position, Vector2.right);
                }
                else
                {
                    transform.localPosition = gunPos.idle_Left;
                    bm.GetBullet(transform.position, Vector2.left);
                }
                break;
            case GunDirection.CROUCH:
                if (facingRight)
                {
                    transform.localPosition = gunPos.crouch_Right;
                    bm.GetBullet(transform.position, Vector2.right);
                }
                else
                {
                    transform.localPosition = gunPos.crouch_Left;
                    bm.GetBullet(transform.position, Vector2.left);
                }
                break;
        }
       
        
    }

    
}



