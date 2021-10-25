using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    public GameObject cherry;
    public Tweener tweener;
    private float duration = 5f;
    private bool moving;
    private float timeElapsed;

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
            GameObject cherryObj = Instantiate(cherry, new Vector3(13, 18, 0), Quaternion.identity);

            if(timeElapsed < duration)
            {
                cherryObj.transform.position = Vector3.Lerp(cherryObj.transform.position, new Vector3(30, 0, 0), timeElapsed/duration);
                timeElapsed += Time.deltaTime;
            }

            yield return new WaitForSeconds(10);
            DestroyImmediate(cherryObj, true);
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
