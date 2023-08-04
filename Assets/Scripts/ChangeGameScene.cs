using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeGameScene : MonoBehaviour
{
    public void ToCharacterScene()
    {
        SceneManager.LoadScene(2); //시작>캐릭터선택창으로 씬 변경
    }

    public void SceneChange()
    {
        SceneManager.LoadScene(1); // 캐릭터선택창>게임화면으로 씬 변경
    }

}
