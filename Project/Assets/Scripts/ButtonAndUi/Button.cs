using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public SaveManager save;

    public void StartGame()
    {
        Debug.Log("StartGame");
        SceneManager.LoadScene(save.currentData.lastScene);
        // �������� 1���� �� ��ȯ �ڵ� ������ ��
    }

    public void ExitGame()
    {
        Debug.Log("ExitGame");
        Application.Quit();
        // ���̺� ���ϵ� �����ؾ��ϳ�?
    }
}
