using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ‚ 
public class GameManager1 : MonoBehaviour
{
    public string _sceneName = "SampleScene";
    [SerializeField]
    private string nextSceneName;
    public void LoadScene()
    {
        Debug.Log("Load Scene.");
        SceneManager.LoadScene(_sceneName);
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}