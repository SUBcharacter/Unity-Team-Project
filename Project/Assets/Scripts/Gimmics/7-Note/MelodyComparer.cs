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

    //[SerializeField] private AudioClip[] melodyClips; // 음표 소리
    [SerializeField] private MelodyPlatform[] platforms;
    [SerializeField] private Sprite[] melodySprites; // 스프라이트 배열 추가
    [SerializeField] private GameObject door;           // 퍼즐 클리어 시 열릴 문
    private MelodyUI melodyUI;
    private Animator animator;

    public Vector3 initPos;

    [SerializeField] private int melodyLength = 3;      // 7개 중 3개가 랜덤으로 나옴

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
        animator = GetComponent<Animator>();
        melodyUI = GetComponent<MelodyUI>();
        initPos = transform.localPosition;
        GenerateMelodyPattern();
    }

    public void AddInputMelody(MelodyData md)
    {
        Debug.Log($"[MelodyComparer] 입력 받음: {md.noteMelody}");

        if (inputIndex < inputMelodys.Length)
        {
            Color fixedColor = new Color(md.color.r, md.color.g, md.color.b, 1f); // 확실하게 알파 고정

            inputMelodys[inputIndex] = new MelodyData(md.noteMelody, fixedColor, md.sprite);
            inputIndex++;

            Debug.Log($"[MelodyComparer] 현재 입력 수: {inputMelodys.Count(m => m != null)}");

            if (inputIndex >= correctMelodys.Length)
            {
                Debug.Log("[MelodyComparer] 입력 모두 완료 → 정답 체크 시작");
                CheckAnswer();
            }
        }
    }

    // 정답 비교 함수
    public void CheckAnswer()
    {
        bool isCorrectd = true;

        for (int i = 0; i < correctMelodys.Length; i++)
        {
            if (inputMelodys[i] == null || inputMelodys[i].noteMelody != correctMelodys[i].noteMelody)
            {
                Debug.Log("[MelodyComparer] 틀렸습니다!");
                isCorrectd = false;
                break;
            }
        }

        if (isCorrectd)
        {
            Debug.Log("[MelodyComparer] 퍼즐 클리어!");
            // 클리어 처리
            // animator.SetTrigger("Open");
            // if (door != null)
            // {
            //     door.SetActive(false);
            // }
        }
        else
        {
            Debug.Log("[MelodyComparer] 틀렸습니다!");
            StartCoroutine(ColorResetCoroutine());
        }
    }


    /// <summary>
    /// 랜덤으로 멜로디 답을 생성해주는 함수
    /// </summary>
    private void GenerateMelodyPattern()
    {

        NoteMelody[] allNotes = new NoteMelody[]
        {
            NoteMelody.Do, NoteMelody.Re, NoteMelody.Mi,
            NoteMelody.Fa, NoteMelody.Sol, NoteMelody.La, NoteMelody.Si
        };

        // 랜덤 셔플
        System.Array.Sort(allNotes, (a, b) => Random.value.CompareTo(Random.value));

        // 패턴 길이만큼 자르기
        correctMelodys = new MelodyData[melodyLength];
        inputMelodys = new MelodyData[melodyLength];
        inputIndex = 0;

        for (int i = 0; i < melodyLength; i++)
        {

            Color color = GetColor(allNotes[i]); // 효가 이미 만든 메서드
            Sprite sprite = GetSprite(allNotes[i]);
            Debug.Log($"[Generate] {i}번 음표 생성됨: {allNotes}, sprite: {sprite?.name}");
            correctMelodys[i] = new MelodyData(allNotes[i], color, sprite);
            //AudioClip clip = null;

            //if ((int)note < melodyClips.Length)
            //{
            //    clip = melodyClips[(int)note];
            //}
            //else
            //{
            //    Debug.LogWarning($"[MelodyComparer] {note}에 해당하는 AudioClip이 없음!");
            //}


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
            p.ResetPlatform(); // 발판 색 복원
        }
        GenerateMelodyPattern();
        animator.SetBool("Correct", false);
        transform.localPosition = initPos;
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
            plat.ResetPlatform(); // 원래 색상 복원
        }

        GenerateMelodyPattern();

        if (melodyUI != null)
        {
            melodyUI.StartMelody(correctMelodys.ToList());
            Debug.Log("[melodyComparer] 퍼즐 리셋됨 → UI 재시작");
        }
    }
}
