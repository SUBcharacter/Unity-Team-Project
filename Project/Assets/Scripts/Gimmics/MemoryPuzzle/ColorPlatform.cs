using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColorPlatform : MonoBehaviour
{
    public SymbolData symbolData;  // 이 발판이 가진 심볼
    [SerializeField] private SymbolComparer comparer; // 인스펙터 연결

    private SpriteRenderer spriteRenderer;

    private bool isPressed;
    private bool isInResetState = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // 발판 초기 색/스프라이트 반영
        if (symbolData != null)
        {
            Color fixedColor = symbolData.color;
            fixedColor.a = 1f;

            spriteRenderer.color = fixedColor;

            if (symbolData.sprite != null)
                spriteRenderer.sprite = symbolData.sprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;

            // 누르면 하이라이트 효과
            
            // 여기다 전달을 해줘야한다는건데 
        }
        comparer.AddInput(symbolData);
        if(!isInResetState)
        {
            spriteRenderer.color = Color.yellow;
        }
        
    }

    // 트리거 

    public void ResetPlatform()
    {
        if (symbolData != null)
        {
            spriteRenderer.color = symbolData.color;
        }
    }

    public void ResetColor(Color color)
    {
        //var fixedColor = color;
        //fixedColor.a = 1f;
        //spriteRenderer.color = fixedColor;
        StartCoroutine(ChangeColorRed(color));
    }

    public void PassColor(Color color)
    {
        var fixedColor = color;
        fixedColor.a = 1f;
        spriteRenderer.color = fixedColor;
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

    //IEnumerator HighLight(Color color, float d)
    //{
    //    yield

    //}
}
