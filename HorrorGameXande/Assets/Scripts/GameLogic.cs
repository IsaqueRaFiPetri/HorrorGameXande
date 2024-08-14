using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public GameObject counter;
    
    public int migalhasCount;

    public string tp;

    void Start()
    {
        migalhasCount = 0;
        PlayerStats.instance.win = false;
    }
    void Update()
    {
        counter.GetComponent<TMP_Text>().text = migalhasCount + "/10";

        if (migalhasCount == 10)
        {
            PlayerStats.instance.win = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (PlayerStats.instance.win && other.CompareTag("Player"))
        {
            SceneManager.LoadScene(tp);
        }
    }
}