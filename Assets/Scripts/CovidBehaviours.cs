using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CovidBehaviours : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 0f;
    public float minDistanceToChase = 0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gm.inZone == true)
        {
            //Debug.Log("In condition" + GameManager.gm.inZone);
            FollowPlayer();
        }
        //Debug.Log(GameManager.gm.inZone);
    }

    void FollowPlayer()
    {
        transform.LookAt(target);
        //Debug.Log("Following");
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance >= minDistanceToChase)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    /*public void SetTarget(Transform target)
    {
        this.target = target;
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Game Over");
            GameManager.gm.LoadGameOverSceneCovid();
        }
    }
}
