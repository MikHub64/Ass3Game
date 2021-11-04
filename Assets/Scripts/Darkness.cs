using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : MonoBehaviour
{

    public PacStudentController pacStudentController;

    // Start is called before the first frame update
    void Start()
    {
        pacStudentController = GameObject.Find("PacStudent").GetComponent<PacStudentController>();
        gameObject.GetComponent<Light>().intensity = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (pacStudentController.powerPellet == true)
        {
            gameObject.GetComponent<Light>().intensity = 5;
        }
        else gameObject.GetComponent<Light>().intensity = 0;
    }
}
