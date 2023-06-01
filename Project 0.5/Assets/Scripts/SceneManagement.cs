
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private void Start()
    {
       
    }
    public void LoadScene(string input)
    {
        if (input == "1")
        {
            SceneManager.LoadScene(1);
        }
        if (input == "Quit")
        {
            Application.Quit();
        }

    }
    private void Update()
    {
        bool i = WaveSpawn.gameWon;
    
        if (i)
        {
            SceneManager.LoadScene(2);
        }

    }
}
