using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileChooser : MonoBehaviour
{
    public Sprite greenProjectile;
    public Sprite blueProjectile;
    public Sprite pinkProjectile;
    public Sprite redProjectile;

    public Image projectileShowingImage;

    public static ProjectileChooser projectileChooser;

    // Start is called before the first frame update
    void Start()
    {
        projectileChooser = this.gameObject.GetComponent<ProjectileChooser>();

        SetProjectile("green");
    }

    public void SetProjectile(string projectileType)
    {
        if(projectileType == "green")
        {
            projectileShowingImage.sprite = greenProjectile;
        }
        else if(projectileType == "blue")
        {
            projectileShowingImage.sprite = blueProjectile;
        }
        else if (projectileType == "pink")
        {
            projectileShowingImage.sprite = pinkProjectile;
        }
        else if (projectileType == "red")
        {
            projectileShowingImage.sprite = redProjectile;
        }
    }
}
