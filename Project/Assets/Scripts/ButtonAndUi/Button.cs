using UnityEngine;

public class Button : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("StartGame");
        // 스테이지 1으로 씬 변환 코드 넣으면 됨
    }

    public void ExitGame()
    {
        Debug.Log("ExitGame");
        // Application.Quit();
        // 세이브 파일도 삭제해야하나?
    }
}
