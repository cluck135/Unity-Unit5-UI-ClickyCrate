using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    // Start is called before the first frame update
    private Button button;
    private GameManager gameManagerScript; 
    private int difficulty;

    void Start()
    {
        button = GetComponent<Button>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();

        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void SetDifficulty() {
        Debug.Log(gameObject.name + " was clicked");
        if(gameObject.CompareTag("Easy")){
            difficulty = 1;
            gameManagerScript.StartGame(difficulty);
        }
        else if (gameObject.CompareTag("Medium")){
            difficulty = 2;
            gameManagerScript.StartGame(difficulty);
        }
        else if(gameObject.CompareTag("Hard")){
            difficulty = 3;
            gameManagerScript.StartGame(difficulty);
        }
    }
    void Update()
    {
        
    }
}
