using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Playing");
    }
}
