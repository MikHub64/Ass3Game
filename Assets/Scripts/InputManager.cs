using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pacStudent;

    private Tweener tweener;

    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pacStudent.transform.position == new Vector3(1, 28, 0))
        {
            pacStudent.GetComponent<Animator>().Play("PacStudentRight");
            tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(6, 28, 0), 2);
        }
        if(pacStudent.transform.position == new Vector3(6, 28, 0))
        {
            pacStudent.GetComponent<Animator>().Play("PacStudentDown");
            tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(6, 24, 0), 2);
        }
        if (pacStudent.transform.position == new Vector3(6, 24, 0))
        {
            pacStudent.GetComponent<Animator>().Play("PacStudentLeft");
            tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(1, 24, 0), 2);
        }
        if (pacStudent.transform.position == new Vector3(1, 24, 0))
        {
            pacStudent.GetComponent<Animator>().Play("PacStudentUp");
            tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(1, 28, 0), 2);
        }
    }
}
