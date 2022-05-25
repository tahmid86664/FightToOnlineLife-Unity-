using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Congratulation : MonoBehaviour
{
    public Text message;

    private string marry;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.gender.ToUpper() == "MALE")
            marry = "Wife";
        else if (GameManager.gender.ToUpper() == "FEMALE")
            marry = "Husband";
        
        message.text = "Hey, You'll have no graduation\n" +
                        "and You've got Online " + marry + "\n" +
                        "Lead a happy Online life.\n" +
                        "Stay Home\n" +
                        "Stay Safe\n\n" +
                        "Sorry for wasting your time";
    }

}
