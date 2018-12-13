using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashingObstacle : MonoBehaviour {
    
    [SerializeField]
    float dashSpeed = 1f;
    [SerializeField]
    [Range(0.0f, 2.0f)]
    float backOffSpeed = 1f;
    [SerializeField]
    float backOffTime = 2f;
    private GameObject player;
    Vector3 distanceVector;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            print("Player object could not found in Dropping Column.");
            Destroy(this);
        }
        StartCoroutine(Prepare());
    }
	

    IEnumerator Prepare()
    {
        float time = Time.time;
        while (time + backOffTime > Time.time)
        {
            distanceVector = new Vector3(this.transform.position.x - player.transform.position.x, this.transform.position.y - player.transform.position.y);
            float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * 180 / Mathf.PI;
            this.transform.rotation = Quaternion.Euler(0, 0, angle - 45); //-135 for left dash

            distanceVector.Normalize();
            this.transform.position = this.transform.position + distanceVector / 100 * backOffSpeed;
            yield return new WaitForFixedUpdate();
        }
        StartCoroutine(Dash());
        yield return null;
    }

    IEnumerator Dash()
    {
        while (true)
        {
            this.transform.position = this.transform.position - distanceVector * dashSpeed;
            yield return new WaitForFixedUpdate();
        }
    }
}
