using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MelodyDoor : MonoBehaviour, IResetable
{
    [SerializeField] bool isOpen;
    [SerializeField] Animator animator;
    Vector3 pos;

    void Start()
    {
        pos = transform.position;
        isOpen = true;
        animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        isOpen = true;
        animator.SetTrigger("Clear");

    }

    public void CloseDoor()
    {
        isOpen = false;
        animator.SetTrigger("Enter");
    }

    public void Init()
    {
        isOpen = true;
        OpenDoor();
    }
}
