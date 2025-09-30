using UnityEngine;

public class Bojo : MonoBehaviour
{
    Animator animator;
    AnimatorStateInfo stateInfo;

    public bool farAway = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        Debug.Log(stateInfo.ToString());

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
