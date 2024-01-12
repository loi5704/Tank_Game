using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SAVESYSTEM : MonoBehaviour
{
    public TMP_InputField inputField;
    public void SaveData()
    {
        PlayerPrefs.SetString("PLAYER_NAME", inputField.text);
    }
    public void LoadData()
    {
        inputField.text=PlayerPrefs.GetString("PLAYER_NAME");
    }
    public void DeleData()
    {
        PlayerPrefs.DeleteKey("PLAYER_NAME");
    }
        
}
