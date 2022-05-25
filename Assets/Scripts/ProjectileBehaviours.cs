using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviours : MonoBehaviour
{
    public enum ProjectileList { ProjectileForClasses, ProjectileForQuizes, ProjectileForAssignments,
        ProjectileForFinal};

    public GameObject classParticle;
    public GameObject assignmentParticle;
    public GameObject quizParticle;


    private bool isTrigger = true;
    private string objectTag;
    private GameObject particleSys;
    public ProjectileList chooseProjectile = ProjectileList.ProjectileForClasses;

    private void Start()
    {
        ChooseObject();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isTrigger)
        {
            if(other.gameObject.tag == objectTag)
            {
                if (objectTag == "OnlineFinal")
                {
                    OnlineStaffsBehaviours.osb.GetDamageToFinalExam();
                }
                else
                {
                    ChooseParticle();
                    GameObject particle = Instantiate(particleSys, transform.position, transform.rotation);
                    Destroy(other.gameObject);
                    Destroy(gameObject);
                    Destroy(particle, 1.5f);
                    //Debug.Log(objectTag);
                }
            }
        }
    }

    private void ChooseObject()
    {
        switch (chooseProjectile)
        {
            case ProjectileList.ProjectileForClasses:
                objectTag = "OnlineClasses";
                break;
            case ProjectileList.ProjectileForQuizes:
                objectTag = "OnlineQuizes";
                break;
            case ProjectileList.ProjectileForAssignments:
                objectTag = "OnlineAssignments";
                break;
            case ProjectileList.ProjectileForFinal:
                objectTag = "OnlineFinal";
                break;
        }
    }

    private void ChooseParticle()
    {
        if(objectTag == "OnlineClasses")
        {
            particleSys = classParticle;
        }
        else if(objectTag == "OnlineAssignments")
        {
            particleSys = assignmentParticle;
        }
        else if(objectTag == "OnlineQuizes")
        {
            particleSys = quizParticle;
        }
    }
}
