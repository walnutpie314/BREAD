using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header(" # Player Info")]
    public int playerid;
    [Header(" # Game Object")]
    public Player player;
    
    public GameState gState;
    public GameObject gameOption;

    //���ӿ��� ����
    public bool isGameover = false;
    public GameObject gameoverUI;

    //[System.Serializable]
    //public struct GameOverMenu
    //{
    //    public GameObject Button;
    //}
    //public GameOverMenu gameOverMenu;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        //cvs = FindFirstObjectByType<Canvas>();
    }

    void Update()
    {
        //���ӿ������¿��� ��ư Ŭ���� 
        if(isGameover && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(2);//ĳ���ͼ���â���� ���ư�
        }
    }

    public class Player
    {
        internal object gameObject;
    }

    public enum GameState
    {
        Run,
        Pause,
        //GameOver
    }

    public void GameStart(int id)
    {
        playerid = id;
        gState = GameState.Run;

        gameObject.SetActive(true);
        //player.gameObject.SetActive(true); //�÷��̾� Ȱ��ȭ
        //Resume();

        //SceneManager.LoadScene(1);
    }


    //���� �ɼ�â ����
    public void OpenOptionWindow()
    {
        gameOption.SetActive(true);
        Time.timeScale = 0f;
        gState = GameState.Pause;
    }

    //����ϱ�
    public void CloseOptionWindow()
    {
        gameOption.SetActive(false);
        Time.timeScale = 1f;
        gState = GameState.Run;
    }

    //���ӿ��� �ڷ�ƾ
    //public void GameOver()
    //{
    //    StartCoroutine(GameOverRoutine());
    //}

    //private void StartCoroutine(IEnumerable enumerable)
    //{
    //    throw new NotImplementedException();
    //}

    //IEnumerable GameOverRoutine()
    //{
    //    gState = GameState.GameOver;
    //    yield return new WaitForSeconds(0.5f);
    //    Time.timeScale = 0f;

    //    Transform button = GetComponentInChildren<Transform>();
    //    button.gameObject.SetActive(true);
    //}

    //�ٽ��ϱ�
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1); //���Ӿ� �ҷ���
    }

     //�����ϱ�
     public void QuitGame()
    {
        Application.Quit(); // �����ߵǴµ�..?
    }

    //�÷��̾� ������ ���ӿ���
    public void OnPlayerArrived()
    { 
        isGameover = true;
        Time.timeScale = 0f;
        //cvs = FindObjectOfType < Canvas > ();
        GameObject cvs = GameObject.Find("Canvas");
        Instantiate(gameoverUI, cvs.transform);
        
        //gameoverUI.SetActive(true);
        Debug.Log("��ȣ");

        

    }


}

