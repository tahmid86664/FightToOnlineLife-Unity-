using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathZone : MonoBehaviour
{
    //public
    public GameObject messageCanvas;
    public Text messageText;

    //private
    private float maxDistanceX = 15f;
    private float minDistanceX = -15f;
    private float maxDistanceZ = 15f;
    private float minDistanceZ = -15f;
    private float distanceY = 0.65f;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "OnlineClasses" || other.gameObject.tag == "OnlineAssignments"
            || other.gameObject.tag == "OnlineQuizes" || other.gameObject.tag == "OnlineFinal")
        {
            //Destroy(other.gameObject);
            //if the staffs in death zone then it will be spawned again in the floor
            other.gameObject.transform.position = new Vector3(Random.Range(minDistanceX, maxDistanceX),
                distanceY, Random.Range(minDistanceZ, maxDistanceZ));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //isTrigger = false;
        if (other.gameObject.tag == "Player")
        {
            GameManager.gm.inZone = false;
            Debug.Log("Exit");

            messageCanvas.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.gm.inZone = true;
            //isTrigger = false;

            messageCanvas.SetActive(true);
            messageText.text = "Covid!!!\nGo Home!";
        }
    }

}
