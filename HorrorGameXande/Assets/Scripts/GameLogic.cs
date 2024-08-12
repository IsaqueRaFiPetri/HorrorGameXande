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
        print(PlayerStats.instance.win);

        counter.GetComponent<TMP_Text>().text = migalhasCount + "/4";

        if (migalhasCount == 4)
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