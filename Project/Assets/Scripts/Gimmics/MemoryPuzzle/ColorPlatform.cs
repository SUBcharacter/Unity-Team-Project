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
        Init();
    }

    public void Init()
    {
        if (symbolData != null)
        {
            Color fixedColor = symbolData.color;
            fixedColor.a = 1f;

            spriteRenderer.color = fixedColor;

            if (symbolData.sprite != null)
                spriteRenderer.sprite = symbolData.sprite;
            ResetPlatform();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        //if (isPressed || isInResetState) { return; } // �̹� �����ų� ���� ���̸� ����

        comparer.AddInput(symbolData);

        if(!isInResetState)
        {
            spriteRenderer.color = Color.yellow;
        }
        
    }
    #region ���� ���� ���� �ڵ�
    /// <summary>
    /// ���� ���� �Լ�
    /// </summary>
    public void ResetPlatform()
    {
        if (symbolData != null)
        {
            spriteRenderer.color = symbolData.color;
        }
    }

    /// <summary>
    /// Ʋ���� �� ���� �ʱ�ȭ���ִ� �Լ�
    /// </summary>
    /// <param name="color"></param>
    public void ResetColor(Color color)
    {
        StartCoroutine(ChangeColorRed(color));
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

#endregion
    /// <summary>
    /// �̰� ����
    /// </summary>
    /// <param name="color"></param>
    public void PassColor(Color color)
    {
        var fixedColor = color;
        fixedColor.a = 1f;
        spriteRenderer.color = fixedColor;
    }

}
