using System.Collections;
using UnityEngine;
using static MelodyData;
[RequireComponent(typeof(SpriteRenderer))]
public class MelodyPlatform : MonoBehaviour, IResetable
{
    public MelodyData melodyData;  // 이 발판이 가진 음표
    [SerializeField] private MelodyComparer comparer; // 인스펙터 연결

    private SpriteRenderer spriteRenderer;
    private bool isPressed = false;
    private bool isInResetState = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // 발판 초기 색/스프라이트 반영
        if (melodyData != null)
        {
            Color fixedColor = melodyData.color;
            fixedColor.a = 1f;

            spriteRenderer.color = fixedColor;

            if (melodyData.sprite != null)
                spriteRenderer.sprite = melodyData.sprite;
            ResetPlatform();
        }
        //Init();
    }

    public void Init()
    {
        if (melodyData != null)
        {
            Color fixedColor = melodyData.color;
            fixedColor.a = 1f;

            spriteRenderer.color = fixedColor;

            if (melodyData.sprite != null)
                spriteRenderer.sprite = melodyData.sprite;
            ResetPlatform();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player")) return;

        if (!isInResetState && !isPressed)
        {
            isPressed = true;
            spriteRenderer.color = Color.yellow;

            // 입력값 MelodyComparer로 전달
            if (comparer != null)
            {
                comparer.AddInputMelody(melodyData);
                Debug.Log("[MelodyPlatform] 입력값 전달됨: " + melodyData.noteMelody);
            }
            else
            {
                Debug.LogWarning("[MelodyPlatform] comparer가 연결되지 않았음!");
            }
        }
    }


    public void ResetPlatform()
    {
        if (melodyData != null)
        {
            isPressed = false;
            isInResetState = false;
            spriteRenderer.color = melodyData.color;
        }
    }

    public void ResetColor(Color color)
    {
        StartCoroutine(ChangeColorRed(color));
    }

    IEnumerator ChangeColorRed(Color color)
    {
        isInResetState = true;

        // 빨간색으로 바꿈
        spriteRenderer.color = color;

        yield return new WaitForSeconds(1f); // 빨간색 유지 시간

        ResetPlatform(); // 원래 색 복원
        isInResetState = false;
    }
}
