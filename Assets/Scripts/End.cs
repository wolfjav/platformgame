using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public Button menu;
    public Button exit;

    // Start is called before the first frame update
    void Start()
    {
        menu.onClick.AddListener(OnMenuClick);
        exit.onClick.AddListener(OnExitClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMenuClick()
    {
        SceneManager.LoadScene(0);
    }
    void OnExitClick()
    {
        Application.Quit();
    }
}
