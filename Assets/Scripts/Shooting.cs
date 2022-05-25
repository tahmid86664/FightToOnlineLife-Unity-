using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefabForClass;
    public GameObject projectilePrefabForQuiz;
    public GameObject projectilePrefabForAssignments;
    public GameObject projectilePrefabForFinal;

    public float projectileForce;
    public Transform shootPosition;
    //public Image projectileShowingImage;
    public AudioClip projectileSound;

    private enum ProjectileList { classProjectile, quizProjectile, assignmentProjectile,
    finalProjectile};
    private ProjectileList chooseProjectile = ProjectileList.classProjectile;
    private int projectileChooser = 1;


    //continous shooting
    private float nextTimeToFire;
    private float fireRate = 5f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            projectileChooser += 1;
            if(projectileChooser > 4)
            {
                projectileChooser = 1;
            }
            switch (projectileChooser)
            {
                case 1:
                    chooseProjectile = ProjectileList.classProjectile;
                    Debug.Log("Class");
                    ProjectileChooser.projectileChooser.SetProjectile("green");
                    break;
                case 2:
                    chooseProjectile = ProjectileList.quizProjectile;
                    Debug.Log("quiz");
                    ProjectileChooser.projectileChooser.SetProjectile("blue");
                    break;
                case 3:
                    chooseProjectile = ProjectileList.assignmentProjectile;
                    Debug.Log("assignment");
                    ProjectileChooser.projectileChooser.SetProjectile("pink");
                    break;
                case 4:
                    chooseProjectile = ProjectileList.finalProjectile;
                    Debug.Log("final");
                    ProjectileChooser.projectileChooser.SetProjectile("red");
                    break;
            }
            
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            if(projectileSound != null)
            {
                AudioSource.PlayClipAtPoint(projectileSound, transform.position);
            }
        }
    }

    private void Shoot()
    {
        switch (chooseProjectile)
        {
            case ProjectileList.classProjectile:
                GameObject projectile = Instantiate(projectilePrefabForClass, shootPosition.position, shootPosition.rotation);
                projectile.gameObject.GetComponent<Rigidbody>().AddForce(shootPosition.forward * projectileForce, ForceMode.VelocityChange);
                break;
            case ProjectileList.quizProjectile:
                GameObject projectileQ = Instantiate(projectilePrefabForQuiz, shootPosition.position, shootPosition.rotation);
                projectileQ.gameObject.GetComponent<Rigidbody>().AddForce(shootPosition.forward * projectileForce, ForceMode.VelocityChange);
                break;
            case ProjectileList.assignmentProjectile:
                GameObject projectileA = Instantiate(projectilePrefabForAssignments, shootPosition.position, shootPosition.rotation);
                projectileA.gameObject.GetComponent<Rigidbody>().AddForce(shootPosition.forward * projectileForce, ForceMode.VelocityChange);
                break;
            case ProjectileList.finalProjectile:
                GameObject projectileF = Instantiate(projectilePrefabForFinal, shootPosition.position, shootPosition.rotation);
                projectileF.gameObject.GetComponent<Rigidbody>().AddForce(shootPosition.forward * projectileForce, ForceMode.VelocityChange);
                break;
        }
    }
}
