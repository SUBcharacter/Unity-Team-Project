using System.Collections;
using System.Runtime.Versioning;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FanSwitch : MonoBehaviour, IResetable
{
    // �� ��ũ��Ʈ�� Fan �θ� ���� �ִٸ� ����ġ ��� ����

    // Fan�� isOnWhenStart�� true��� ����ġ ������ �� "time��ŭ ����"
    // Fan�� isOnWhenStart�� false��� ����ġ ������ �� "time��ŭ ����"

    [SerializeField] FanController fan;
    [SerializeField] float time = 4.0f;

    [SerializeField] TilemapRenderer pushTile;
    [SerializeField] TilemapRenderer noPushTile;

    void Start()
    {
        fan = GetComponentInChildren<FanController>();

        noPushTile.enabled = true;
        pushTile.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �Ϸ� �����ؾ���
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FanTimer());
        }
    }

    IEnumerator FanTimer()
    {
        noPushTile.enabled = false;
        pushTile.enabled = true;

        if (fan.isOnWhenStart) { fan.TurnOff(); }
        else { fan.TurnOn(); }

        yield return new WaitForSeconds(time);

        if (fan.isOnWhenStart) { fan.TurnOn(); }
        else { fan.TurnOff(); }

        noPushTile.enabled = true;
        pushTile.enabled = false;
    }

    public void Init()
    {
        StopCoroutine(FanTimer());

        noPushTile.enabled = true;
        pushTile.enabled = false;
    }
}
