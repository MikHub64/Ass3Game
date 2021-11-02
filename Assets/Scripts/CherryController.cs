using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CherryController : MonoBehaviour
{
    public Tweener tweener;
    private float duration = 9f;
    private bool moving;

    private RectTransform hudBounds;

    private Vector3 top;
    private Vector3 left;
    private Vector3 bottom;
    private Vector3 right;

    private int position;

    // Start is called before the first frame update
    void Start()
    {
        hudBounds = GameObject.Find("HUD").GetComponent<RectTransform>();
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
            top = new Vector3(Random.Range(0, hudBounds.rect.width * hudBounds.localScale.x), hudBounds.rect.height * hudBounds.localScale.y, 0);
            left = new Vector3(-15, Random.Range(0, hudBounds.rect.height * hudBounds.localScale.y), 0);
            bottom = new Vector3(Random.Range(0, hudBounds.rect.width * hudBounds.localScale.x), -5, 0);
            right = new Vector3(hudBounds.rect.width * hudBounds.localScale.x, Random.Range(0, hudBounds.rect.height * hudBounds.localScale.y), 0);

            position = Random.Range(0, 4);

            if(position == 0)
            {
                gameObject.transform.position = top;
                moving = true;
                Move(bottom);
            }
            if (position == 1)
            {
                gameObject.transform.position = left;
                moving = true;
                Move(right);
            }
            if (position == 2)
            {
                gameObject.transform.position = bottom;
                moving = true;
                Move(top);
            }
            if (position == 3)
            {
                gameObject.transform.position = right;
                moving = true;
                Move(left);
            }

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
