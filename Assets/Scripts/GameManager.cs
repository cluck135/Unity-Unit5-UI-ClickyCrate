using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public int score;
    private float spawnRate = 1;
    void Start()
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        scoreText.text = "Score: " + score;
    }

    void Update()
    {

    }

    IEnumerator SpawnTarget() {
        while (true) {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0,targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    // Update is called once per frame
}
