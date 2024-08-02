using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public void Teleport(string tp) //No INSPECTOR, coloque o nome da cena
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(tp);
    }
    public void SairJogo()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();
    }


}
