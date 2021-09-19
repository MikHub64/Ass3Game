using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public Animation left;
    public Animation right;
    public Animation up;
    public Animation down;

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
            left = gameObject.GetComponent<Animation>();
            tweener.addTween(pacStudent.transform, pacStudent.transform.position, new Vector3(6, 28, 0), 2);
        }
        if(pacStudent.transform.position == new Vector3(6, 28, 0))
        {
            tweener.addTween(pacStudent.transform, pacStudent.transform.position, new Vector3(6, 24, 0), 2);
        }
        if (pacStudent.transform.position == new Vector3(6, 24, 0))
        {
            tweener.addTween(pacStudent.transform, pacStudent.transform.position, new Vector3(1, 24, 0), 2);
        }
        if (pacStudent.transform.position == new Vector3(1, 24, 0))
        {
            tweener.addTween(pacStudent.transform, pacStudent.transform.position, new Vector3(1, 28, 0), 2);
        }
    }
}
