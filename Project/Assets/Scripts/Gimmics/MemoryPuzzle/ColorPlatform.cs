using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColorPlatform : MonoBehaviour
{
    public SymbolData symbolData;  // �� ������ ���� �ɺ�
    [SerializeField] private SymbolComparer comparer; // �ν����� ����

    private SpriteRenderer spriteRenderer;

    private bool isPressed;
    private bool isInResetState = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // ���� �ʱ� ��/��������Ʈ �ݿ�
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

            // ������ ���̶���Ʈ ȿ��
            
            // ����� ������ ������Ѵٴ°ǵ� 
        }
        comparer.AddInput(symbolData);
        if(!isInResetState)
        {
            spriteRenderer.color = Color.yellow;
        }
        
    }

    // Ʈ���� 

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

        // ���������� �ٲ�
        spriteRenderer.color = color;

        yield return new WaitForSeconds(1f); // ������ ���� �ð�

        ResetPlatform(); // ���� �� ����
        isInResetState = false;
    }

    //IEnumerator HighLight(Color color, float d)
    //{
    //    yield

    //}
}
