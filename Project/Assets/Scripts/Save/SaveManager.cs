using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class SaveData
{
    public string sceneName;
    public Vector3 playerPos;
    public Vector3 cameraPos;
}

[Serializable]
public class SaveFile
{
    public SaveData slot;
}

public class SaveManager : MonoBehaviour
{
    public SaveData currentData;

    public Vector3 initCameraPos;
    public Vector3 initPlayerPos;

    public string path;

    private void Awake()
    {
        Debug.Log("���̺� �Ŵ��� �õ�");
        path = Path.Combine(Application.persistentDataPath, "Save.json");

        if (currentData == null)
            currentData = new SaveData();
        LoadData();
    }

    public void UpdateData(Vector3 playerPos, Vector3 cameraPos)
    {
        currentData.sceneName = SceneManager.GetActiveScene().name;
        currentData.playerPos = playerPos;
        currentData.cameraPos = cameraPos;
    }

    public void LoadData()
    {
        if(!File.Exists(path))
        {
            // �÷��̾� �� ī�޶� �ʱ� ��ġ
            currentData.sceneName = SceneManager.GetActiveScene().name;
            currentData.playerPos = initPlayerPos;
            currentData.cameraPos = initCameraPos;
            return;
        }
        string json = File.ReadAllText(path);
        SaveFile saveFile = JsonUtility.FromJson<SaveFile>(json);

        if(saveFile == null || saveFile.slot == null)
        {
            // ���̺� ���� �Ľ� ���н� �÷��̾� �� ī�޶� �ʱ� ��ġ
            currentData.sceneName = SceneManager.GetActiveScene().name;
            currentData.playerPos = initPlayerPos;
            currentData.cameraPos = initCameraPos;
            return;
        }
        currentData = saveFile.slot;
        if(currentData.sceneName != SceneManager.GetActiveScene().name)
        {
            SceneManager.LoadScene(currentData.sceneName);
        }
        
    }

    public void SaveData()
    {
        if(currentData == null)
        {
            return;
        }

        SaveFile saveFile = new SaveFile { slot = currentData };
        string json = JsonUtility.ToJson(saveFile, true);
        File.WriteAllText(path, json);
    }

    private void OnApplicationQuit()
    {
        SaveData();
        Debug.Log(path);
    }
}
