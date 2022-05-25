using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class OnlineStaffsBehaviours : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 0f;
    public float minDistanceToChase = 0f;
    public float damageToPlayer = 0f;

    //for final Exam
    public bool isFinalExam = false;
    public float finalExamHealth = 10f;
    public GameObject finalExamParticle;

    public HealthBar healthBar;

    public static OnlineStaffsBehaviours osb;

    private float currentFinalExamHealth;

    // Start is called before the first frame update
    void Start()
    {
        osb = this.gameObject.GetComponent<OnlineStaffsBehaviours>();

        if (isFinalExam)
        {
            SetFinalExamHealth();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gm.inZone == false)
            FollowPlayer();
    }

    void FollowPlayer()
    {
        transform.LookAt(target);

        float distance = Vector3.Distance(transform.position, target.position);
        if(distance >= minDistanceToChase)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void SetFinalExamHealth()
    {
        currentFinalExamHealth = finalExamHealth;
        healthBar.SetMaxHealth(finalExamHealth);
    }

    public void GetDamageToFinalExam()
    {
        currentFinalExamHealth -= 1;
        healthBar.SetHealth(currentFinalExamHealth);
        if(currentFinalExamHealth < 0)
        {
            DestroyFinalExam();
        }
    }

    public void DestroyFinalExam()
    {
        Debug.Log("Congratulations");
        Destroy(gameObject);
        showParticle();
        
        int millisec = 2000;
        Thread.Sleep(millisec);
        GameManager.gm.LoadCongtratulationScene();
    }

    public void showParticle()
    {
        GameObject particle = Instantiate(finalExamParticle, transform.position, transform.rotation);
        Destroy(particle, 1.5f);
    }

    /*public void GameIsOver()
    {
        //yield return new WaitForSeconds(1.5f);
        Debug.Log("Game is over");
        GameManager.gm.LoadCongtratulationScene();
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Enemy Hit!!!");
            collision.gameObject.GetComponent<Health>().TakeDamage(damageToPlayer); 
        }
    }
}
