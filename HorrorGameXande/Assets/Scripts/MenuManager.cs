using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public EventSystem eventSystem;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelCred;

    public void Teleport(string tp)
    {
        SceneManager.LoadScene(tp);
    }
    
    public void SairJogo()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();
    }

    public void NextButton(GameObject button)
    {
        eventSystem.SetSelectedGameObject(button);
    }
}