using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingObstacle : MonoBehaviour
{

    [SerializeField]
    float thresholdToFall = 2f;
    [SerializeField]
    float fallSpeed = 10f;
    [SerializeField]
    float totalRotation = 90f;
    private GameObject player;
    private bool isTriggered;

    void Start()
    {
        isTriggered = false;
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            print("Player object could not found in Dropping Column.");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTriggered && this.transform.position.y - player.transform.position.y <= thresholdToFall)
        {
            isTriggered = true;
            StartCoroutine(Fade());
        }
    }

    void FadeInitiator()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        int limit = (int)totalRotation / (int)fallSpeed;
        for (int z = 0; z <= limit; z++)
        {
            transform.SetPositionAndRotation(this.transform.position, Quaternion.Euler(0, 0, -fallSpeed * z));
            yield return new WaitForFixedUpdate();
        }
        yield return null;
    }
}
