using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeGameScene : MonoBehaviour
{
    public void ToCharacterScene()
    {
        SceneManager.LoadScene(2); //����>ĳ���ͼ���â���� �� ����
    }

    public void SceneChange()
    {
        SceneManager.LoadScene(1); // ĳ���ͼ���â>����ȭ������ �� ����
    }

}
