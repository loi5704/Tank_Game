using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinBehavior : MonoBehaviour
{
    public void DestroyHelper()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(3);
    }
}