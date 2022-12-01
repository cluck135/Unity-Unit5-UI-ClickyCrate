using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody targetRb;
    private float minSpeed = 8;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -1;
    public ParticleSystem explosionParticle;
    private GameManager gameManagerScript;

    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
           
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, 0);
    }

    private void OnMouseDown() {
        if(gameManagerScript.isGameActive){
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            if(gameObject.CompareTag("Bad 1")) {
                gameManagerScript.UpdateScore(-5);
            }
            else {
                gameManagerScript.UpdateScore(1);
            }
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(!gameObject.CompareTag("Bad 1")){
            gameManagerScript.GameOver();
        }
        Destroy(gameObject);
    }
}
