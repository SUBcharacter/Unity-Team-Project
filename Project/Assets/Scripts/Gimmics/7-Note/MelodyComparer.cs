using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static MelodyData;

public class MelodyComparer : MonoBehaviour, IResetable
{
    public MelodyData[] correctMelodys;
    public MelodyData[] inputMelodys;

    [SerializeField] private AudioClip[] melodyClips; // ��ǥ �Ҹ�
    [SerializeField] private MelodyPlatform[] platforms;
    [SerializeField] private Sprite[] melodySprites; // ��������Ʈ �迭 �߰�

    [SerializeField] BooTrigger booTrigger;
    private MelodyUI melodyUI;
    private Animator animator;

    ExitDoor exitDoor; 

    public Vector3 initPos;

    [SerializeField] private int melodyLength = 3;      // 7�� �� 3���� �������� ����



    private int inputIndex = 0;
    private float resetTime = 1f;
    

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        ResetMelody();
    }

    private void Awake()
    {
        if(exitDoor == null)
        {
            exitDoor = FindAnyObjectByType<ExitDoor>();
        }
       
        animator = GetComponent<Animator>();
        melodyUI = GetComponent<MelodyUI>();
        initPos = transform.localPosition;
        GenerateMelodyPattern();
    }

    public void AddInputMelody(MelodyData md)
    {
        Debug.Log($"[MelodyComparer] �Է� ����: {md.noteMelody}");

        if (inputIndex < inputMelodys.Length)
        {
            Color fixedColor = new Color(md.color.r, md.color.g, md.color.b, 1f); // Ȯ���ϰ� ���� ����

            inputMelodys[inputIndex] = new MelodyData(md.noteMelody, fixedColor, md.noteAudio, md.sprite);
            inputIndex++;

            Debug.Log($"[MelodyComparer] ���� �Է� ��: {inputMelodys.Count(m => m != null)}");

            if (inputIndex >= correctMelodys.Length)
            {
                Debug.Log("[MelodyComparer] �Է� ��� �Ϸ� �� ���� üũ ����");
                CheckAnswer();
            }
        }
    }

    // ���� �� �Լ�
    public void CheckAnswer()
    {
        bool isCorrectd = true;

        for (int i = 0; i < correctMelodys.Length; i++)
        {
            if (inputMelodys[i] == null || inputMelodys[i].noteMelody != correctMelodys[i].noteMelody)
            {
                Debug.Log("[MelodyComparer] Ʋ����");
                isCorrectd = false;
                break;
            }
        }

        if (isCorrectd)
        {
            booTrigger.DeactivateShy();
            Debug.Log("[MelodyComparer] ���� Ŭ����!");

            foreach (var plat in platforms)
            {
                plat.SetClearedState();
            }
            //Ŭ���� ó��
            

            if (exitDoor != null)
            {
                Debug.Log("�� Ȱ��ȭ ��");
                exitDoor.OpenDoor();
            }
        }
        else
        {
            Debug.Log("[MelodyComparer] Ʋ����");
            StartCoroutine(ColorResetCoroutine());
        }
    }


    /// <summary>
    /// �������� ��ε� ���� �������ִ� �Լ�
    /// </summary>
    private void GenerateMelodyPattern()
    {

        NoteMelody[] allNotes = new NoteMelody[]
        {
            NoteMelody.Do, NoteMelody.Re, NoteMelody.Mi,
            NoteMelody.Fa, NoteMelody.Sol, NoteMelody.La, NoteMelody.Si
        };

        // ���� ����
        System.Array.Sort(allNotes, (a, b) => Random.value.CompareTo(Random.value));

        // ���� ���̸�ŭ �ڸ���
        correctMelodys = new MelodyData[melodyLength];
        inputMelodys = new MelodyData[melodyLength];
        inputIndex = 0;

        for (int i = 0; i < melodyLength; i++)
        {
            NoteMelody note = allNotes[i];
            Color color = GetColor(note);
            Sprite sprite = GetSprite(note);

            AudioClip clip = (int)note < melodyClips.Length ? melodyClips[(int)note] : null;

            if (clip == null)
                Debug.LogWarning($"[MelodyComparer] {note}�� �´� AudioClip�� melodyClips�� ����!");

            correctMelodys[i] = new MelodyData(note, color, clip, sprite);
        }

    }

    public void ResetMelody()
    {
        inputIndex = 0;
        for (int i = 0; i < inputMelodys.Length; i++)
        {
            inputMelodys[i] = null;
        }

      

        foreach (var p in platforms)
        {
            p.ResetPlatform(); // ���� �� ����
        }
        GenerateMelodyPattern();
        animator.SetBool("Correct", false);
        transform.localPosition = initPos;

        //// UI �ٽ� �����ֱ�
        //if (melodyUI != null)
        //{
        //    melodyUI.StopAllCoroutines(); // Ȥ�� ���� �ڷ�ƾ ���������� �ߴ�
        //    melodyUI.StartMelody(correctMelodys.ToList());
        //}
    }

    private Color GetColor(NoteMelody noteMelody)
    {
        switch (noteMelody)
        {
            case NoteMelody.Do: return Color.red;
            case NoteMelody.Re: return new Color(1f, 0.5f, 0f, 1f); // Orange
            case NoteMelody.Mi: return Color.yellow;
            case NoteMelody.Fa: return Color.green;
            case NoteMelody.Sol: return Color.blue;
            case NoteMelody.La: return new Color(0f, 0f, 128f/ 255f, 1f); // Indigo
            case NoteMelody.Si: return new Color(0.56f, 0f, 1f, 1f); // Violet
            default: return Color.white;
        }
    }

    private Sprite GetSprite(NoteMelody noteMelody)
    {
        switch (noteMelody)
        {
            case NoteMelody.Do: return melodySprites.Length > 0 ? melodySprites[0] : null;
            case NoteMelody.Re: return melodySprites.Length > 1 ? melodySprites[1] : null;
            case NoteMelody.Mi: return melodySprites.Length > 2 ? melodySprites[2] : null;
            case NoteMelody.Fa: return melodySprites.Length > 3 ? melodySprites[3] : null;
            case NoteMelody.Sol: return melodySprites.Length > 4 ? melodySprites[4] : null;
            case NoteMelody.La: return melodySprites.Length > 5 ? melodySprites[5] : null;
            case NoteMelody.Si: return melodySprites.Length > 6 ? melodySprites[6] : null;

            default: return null;
        }
    }

    IEnumerator ColorResetCoroutine()
    {
        foreach (var plat in platforms)
        {
            Debug.Log($"{plat.gameObject.name} -> Red");
            plat.ResetColor(Color.red);
        }
        yield return new WaitForSeconds(resetTime);

        foreach (var plat in platforms)
        {
            plat.ResetPlatform(); // ���� ���� ����
        }

        if (booTrigger != null)
        {
            booTrigger.ActivateShy();  
        }
        GenerateMelodyPattern();

        if (melodyUI != null)
        {
            melodyUI.StartMelody(correctMelodys.ToList());
            Debug.Log("[melodyComparer] ���� ���µ� �� UI �����");
        }
    }
}
