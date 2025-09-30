using System.Collections;
using UnityEngine;
using static MelodyData;
[RequireComponent(typeof(SpriteRenderer))]
public class MelodyPlatform : MonoBehaviour, IResetable
{
    public MelodyData melodyData;  // �� ������ ���� ��ǥ
    [SerializeField] private MelodyComparer comparer; // �ν����� ����
    private AudioSource audioSource;


    private SpriteRenderer spriteRenderer;
    private bool isPressed = false;
    private bool isInResetState = false;
    private bool isCleared = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        // ���� �ʱ� ��/��������Ʈ �ݿ�
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
        isCleared = false;

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

        if (!isInResetState && !isPressed && !isCleared)
        {
            isPressed = true;
            spriteRenderer.color = Color.white;

            if (melodyData.noteAudio != null && audioSource != null)
            {
                audioSource.PlayOneShot(melodyData.noteAudio); // ���� �Ҹ� ���
            }


            // �Է°� MelodyComparer�� ����
            if (comparer != null)
            {
                comparer.AddInputMelody(melodyData);
                Debug.Log("[MelodyPlatform] �Է°� ���޵�: " + melodyData.noteMelody);
            }
            else
            {
                Debug.LogWarning("[MelodyPlatform] comparer�� ������� �ʾ���!");
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

            //if (melodyData.sprite != null)
            //    spriteRenderer.sprite = melodyData.sprite;

            //// ������� ���߰� �ʹٸ�
            //if (audioSource != null)
            //    audioSource.Stop();
        }
    }

    public void ResetColor(Color color)
    {
        StartCoroutine(ChangeColorRed(color));
    }

    public void SetClearedState()
    {
        isCleared = true;
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
}
