using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    public void LV1()
    {

        SceneManager.LoadScene(1);

    }

    public void LV2()
    {
        SceneManager.LoadScene(2);

    }

    public void Menu()
    {
        SceneManager.LoadScene(6);
    }
    public void Ranking()
    {
        SceneManager.LoadScene(5);
    }

    public void GameMode()
    {
        SceneManager.LoadScene(0);
    }

    public void AboutUs() 
    {
        SceneManager.LoadScene(7);
    }

    public void Exit()
    {
        SceneManager.LoadScene(6);
    }    
}




