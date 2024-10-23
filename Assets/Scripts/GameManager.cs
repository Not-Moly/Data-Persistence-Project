using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void onNameInputChanged(string username)
    {
        ScoreManager.Instance.username = username;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
#if UNITY_EDITOR
      EditorApplication.ExitPlaymode();
#else
        Application.quit();
#endif
        ;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
