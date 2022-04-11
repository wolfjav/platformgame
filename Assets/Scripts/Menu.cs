using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button play;

    // Start is called before the first frame update
    void Start()
    {
        play.onClick.AddListener(OnPlayClick);
    }

    void OnPlayClick()
    {   
        SceneManager.LoadScene(1);
    }
}
