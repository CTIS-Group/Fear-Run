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
        switch (randomNum)
        {
            case 0:
                Instantiate(gameObjects[randomNum], new Vector3(-3f, 7f, 0f), Quaternion.identity);
                break;
            case 1:
                Instantiate(gameObjects[randomNum], new Vector3(0f,7f,0f), Quaternion.identity);
                break;
            case 2:
                Instantiate(gameObjects[randomNum], new Vector3(3f, 8f, 0f), Quaternion.identity);
                break;
            case 3:
                Instantiate(gameObjects[randomNum], new Vector3(0f, 7f, 0f), Quaternion.identity);
                break;
            case 4:
                Instantiate(gameObjects[randomNum], new Vector3(0f, 7f, 0f), Quaternion.identity);
                break;

        }
    }
}
