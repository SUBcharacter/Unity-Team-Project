using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    public void OnAnimationEnd()
    {
        gameObject.SetActive(false);
    }

}
