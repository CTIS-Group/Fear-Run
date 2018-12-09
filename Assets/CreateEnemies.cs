using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemies : MonoBehaviour {
    [SerializeField] //UPROPERTY(EditAnywhere)
    GameObject[] gameObjects;
    int randomNum;
    // Use this for initialization
    void Start () {
        InvokeRepeating("CreateRandomEnemies", 2.0f, 4f);
    }
	
	// Update is called once per frame
	void Update () {

    }

    private void CreateRandomEnemies()
    {
        randomNum = Random.Range(0, gameObjects.Length);
        print(randomNum);
        switch (randomNum)
        {
            case 0:
                Instantiate(gameObjects[randomNum], new Vector3(Random.Range(-2f, 2f), 7f, 0f), Quaternion.Euler(0f, 0f, -90f));
                break;
            case 1:
                Instantiate(gameObjects[randomNum], new Vector3(Random.Range(-2f, 2f), 7f, 0f), Quaternion.Euler(0f, 0f, -90f));
                break;
            case 2:
                Instantiate(gameObjects[randomNum], new Vector3(4f, Random.Range(0f, 2f), 0f), Quaternion.Euler(180f, 0f, 180f));
                break;
            case 3:
                Instantiate(gameObjects[randomNum], new Vector3(-4f, Random.Range(0f, 2f), 0f), Quaternion.identity);
                break;
        }
    }
}
