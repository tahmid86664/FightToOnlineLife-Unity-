using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform target;

    public GameObject classToSpawn;
    public GameObject assignmentToSpawn;
    public GameObject quizToSpawn;
    public GameObject finalExamToSpawn;

    public float minDistanceX = 0f;
    public float maxDistanceX = 0f;
    public float minDistanceZ = 0f;
    public float maxDistanceZ = 0f;
    public float distanceY = 0.6f;

    public int maxClasses = 10;
    public int maxQuizes = 4;
    public int minAssignmentsNumber = 0;
    public int maxAssignmentsNumber = 0;

    public float minTimeToSpawn = 0f;
    public float maxTimeToSpawn = 0f;

    private float saveTime;
    private float timeBetweenSpawn;
    private int currentClasses;
    private int currentQuizes;
    private int currentAssignments;
    private bool takeAssignments = true;
    private bool takeFinal;
    private bool takeQuizes = true;
    private bool takeClasses = true;

    private int maxAssignments;

    // Start is called before the first frame update
    void Start()
    {
        takeFinal = true;

        currentClasses = 0;
        currentAssignments = 0;
        currentQuizes = 0;
        maxAssignments = Random.Range(minAssignmentsNumber, maxAssignmentsNumber);

        saveTime = Time.time;
        timeBetweenSpawn = Random.Range(minTimeToSpawn, maxTimeToSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - saveTime >= timeBetweenSpawn)
        {
            Spawning();

            saveTime = Time.time;
            timeBetweenSpawn = Random.Range(minTimeToSpawn, maxTimeToSpawn);
        }
    }

    private void Spawning()
    {
        Vector3 spawningPos;
        //randoooommmm positionnnn for classes
        spawningPos.x = Random.Range(minDistanceX, maxDistanceX);
        spawningPos.y = distanceY;
        spawningPos.z = Random.Range(minDistanceZ, maxDistanceZ);

        if (takeClasses)
        {
            //instantiate classes
            GameObject spawnObj = Instantiate(classToSpawn, spawningPos, transform.rotation);
            if (target != null)
            {
                spawnObj.gameObject.GetComponent<OnlineStaffsBehaviours>().SetTarget(target);
            }
            currentClasses += 1; //increament of online classes
        }

        //check for assignmnet
        if(currentClasses >= maxClasses && takeAssignments == true)
        {
            //randooommm positionnn for the Assssssignmeent
            spawningPos.x = Random.Range(minDistanceX, maxDistanceX);
            spawningPos.y = distanceY;
            spawningPos.z = Random.Range(minDistanceZ, maxDistanceZ);

            GameObject spawnA = Instantiate(assignmentToSpawn, spawningPos, transform.rotation);
            if (target != null)
            {
                spawnA.gameObject.GetComponent<OnlineStaffsBehaviours>().SetTarget(target);
            }
            currentAssignments += 1;
            //after taking all assignments,
            //now time to take a quiz
            if(currentAssignments >= maxAssignments && takeQuizes) // after 3 assignments, taking assignments will turn off
            {
                //randooommm positionnn for the Quizes
                spawningPos.x = Random.Range(minDistanceX, maxDistanceX);
                spawningPos.y = distanceY;
                spawningPos.z = Random.Range(minDistanceZ, maxDistanceZ);

                GameObject spawnQ = Instantiate(quizToSpawn, spawningPos, transform.rotation);
                if (target != null)
                {
                    spawnQ.gameObject.GetComponent<OnlineStaffsBehaviours>().SetTarget(target);
                }
                currentQuizes += 1;

                currentAssignments = 0;
                //change the maxAssignments number also
                maxAssignments = Random.Range(minAssignmentsNumber, maxAssignmentsNumber);
                currentClasses = 0;
            }

        }
        // after taking all quizes
        //its time to take Semester Final
        if(currentQuizes >= maxQuizes && takeFinal == true)
        {
            //randooommm positionnn for the Final Exam
            spawningPos.x = Random.Range(minDistanceX, maxDistanceX);
            spawningPos.y = distanceY;
            spawningPos.z = Random.Range(minDistanceZ, maxDistanceZ);

            GameObject spawnF = Instantiate(finalExamToSpawn, spawningPos, transform.rotation);
            if (target != null)
            {
                spawnF.gameObject.GetComponent<OnlineStaffsBehaviours>().SetTarget(target);
            }
            takeFinal = false;
            takeClasses = false;
            takeAssignments = false;
            takeQuizes = false;
            //currentQuizes = 0;
        }

        //spawnObj.transform.parent = gameObject.transform;
    }
}
