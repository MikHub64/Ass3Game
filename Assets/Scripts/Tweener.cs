using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{

    private Tween activeTween;
    float distance;
    float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeTween != null && distance > 0.1f)
        {

            activeTween.Target.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, elapsedTime / activeTween.Duration);
            elapsedTime += Time.deltaTime;
        }

        if (activeTween != null && Vector3.Distance(activeTween.Target.position, activeTween.EndPos) <= 0.1f)
        {
            activeTween.Target.position = activeTween.EndPos;
            activeTween = null;
        }
    }

    public void addTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        if(activeTween == null)
        {
            activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration);
            distance = Vector3.Distance(activeTween.Target.position, activeTween.EndPos);
            elapsedTime = 0;
        }
    }
}
