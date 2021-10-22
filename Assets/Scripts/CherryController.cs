using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    public GameObject cherry;
    public Tweener tweener;
    private float duration = 5f;
    private bool moving;

    // Start is called before the first frame update
    void Start()
    {
        
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
            moving = true;
            Instantiate(cherry, new Vector3(20, 0, 0), Quaternion.identity);
            Move(new Vector3(30, 0, 0));
            yield return new WaitForSeconds(10);
            Destroy(cherry);
            moving = false;
        }
    }

    private void Move(Vector3 target)
    {
        if (!tweener.TweenExists(cherry.transform))
        {
            tweener.AddTween(cherry.transform, cherry.transform.position, target, duration);
        }
    }
}
