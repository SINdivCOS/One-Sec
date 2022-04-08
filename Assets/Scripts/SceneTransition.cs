using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public GameObject PauseMenu;
    public Animator transitionAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void loadScene(int num)
    {
        SceneManager.LoadSceneAsync(num);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)==true)
        {
            PauseMenu.SetActive(true);
        }
    }
}
