using UnityEngine;

public class Gun : MonoBehaviour
{
    public bool facingRight = true;

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
        if(facingRight)
        {
            bm.GetBullet(transform.position, Vector2.right);
        }
        else
        {
            bm.GetBullet(transform.position, Vector2.left);
        }
        
    }
}
