using UnityEngine;

public class SwitchComparer : MonoBehaviour, IResetable
{
    public static SwitchComparer Instance;

    [SerializeField] private MirrorExitDoor mirrorExitDoor;
    [SerializeField] private SwitchButton[] switches; // ������ ��ư��

    public void Init()
    {
        mirrorExitDoor.CloseDoor();
    }

    private void Awake()
    {
        Instance = this;
    }

    public void CheckSwitches()
    {
        if (mirrorExitDoor.IsOpen) 
        { 
            Debug.Log("�̹� �� ����");
            return; 
        } // �̹� �� �������� �ٽ� üũ �� ��

        foreach (var s in switches)
        {
            if (!s.IsPressed)
            {
                Debug.Log($"[SwitchComparer] ����ġ {s.gameObject.name} ��(��) ���� �� ����");
                return;
            }// �ϳ��� �� �������� �׳� ����
        }

        Debug.Log("[SwitchComparer] ��� ����ġ�� ���� �� �ⱸ ����");
        mirrorExitDoor.OpenDoor(); // �� �� �������� �� ����
    }

   
}
