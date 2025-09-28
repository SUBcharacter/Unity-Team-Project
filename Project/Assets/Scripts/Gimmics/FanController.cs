using UnityEngine;

public class FanController : MonoBehaviour
{
    Animator animator;
    [SerializeField] Collider2D windSpace;
    [SerializeField] bool isOn = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.Log("�ִϸ����� ����");
        }

        if (windSpace == null)
        {
            windSpace = GetComponentInChildren<Collider2D>();
        }

        if (isOn)
        {
            TurnOn();
        }
        else
        {
            TurnOff();
        }

    }

    private void TurnOn()
    {
        animator.SetBool("FanOn", true);
        if (windSpace != null) windSpace.enabled = true;
    }

    private void TurnOff()
    {
        animator.SetBool("FanOn", false);
        if (windSpace != null) windSpace.enabled = false;
    }
}
