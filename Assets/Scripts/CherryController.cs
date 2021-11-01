using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CherryController : MonoBehaviour
{
    public Tweener tweener;
    private float duration = 5f;
    private bool moving;

    private RectTransform ui;

    //private Vector3 top;
    //private Vector3 left;
    //private Vector3 bottom;
    //private Vector3 right;

    // Start is called before the first frame update
    void Start()
    {
        //ui = GameObject.Find("HUD").GetComponent<RectTransform>();

        //top = new Vector3();
        //left = new Vector3();
        //bottom = new Vector3();
        //right = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("CherrySpawn");
    }

    IEnumerator CherrySpawn()
    {
        if(moving == false)
        {
            //gameObject.transform.position = top;
            gameObject.transform.position = new Vector3(-20, 15, 0);

            moving = true;

            Move(new Vector3(transform.position.x + 60, transform.position.y, transform.position.z));

            yield return new WaitForSeconds(10);
            gameObject.SetActive(false);
            moving = false;
        }
    }

    private void Move(Vector3 target)
    {
        if (!tweener.TweenExists(transform))
        {
            tweener.AddTween(transform, transform.position, target, duration);
        }
    }
}
