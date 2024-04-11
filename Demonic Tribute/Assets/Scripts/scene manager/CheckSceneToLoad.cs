using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CheckSceneToLoad : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject gameWonScreen;

    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
        gameWonScreen.SetActive(false);
        Debug.Log(DayCounter.instance.hasWon);
    }

    // Update is called once per frame
    void Update()
    {
        /* if (DayCounter.instance.hasWon)
        {
            gameWonScreen.SetActive(true);
        }
        else 
        {
            gameOverScreen.SetActive(true);
        }
        */
    }
}
