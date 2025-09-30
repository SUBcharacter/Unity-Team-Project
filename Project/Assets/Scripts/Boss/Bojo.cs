using UnityEngine;

public class Bojo : MonoBehaviour, IResetable
{
    Animator animator;
    Boss boss;
    AnimatorStateInfo stateInfo;

    public bool farAway = false;
  

    private void Awake()
    {
        animator = GetComponent<Animator>();
        boss = GetComponentInChildren<Boss>();
        
    }

    public void Init()
    {
        animator.Play("StandBy", 0,0f);
        farAway = false;
    }

    public void Ready()
    {
        Debug.Log("패턴 준비");
        boss.attacking = false;
        animator.SetBool("EndAttack", false);
    }

    private void Update()
    {
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if(stateInfo.IsName("ScaleDown"))
        {
            farAway = true;
        }
        else if(stateInfo.IsName("ScaleUp"))
        {
            farAway = false;
        }
    }
}
