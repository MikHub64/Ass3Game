using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScaling : MonoBehaviour
{
    public GameObject lives;
    public GameObject score;
    public GameObject time;
    public GameObject scaredTime;
    public GameObject exit;

    public Canvas hud;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform hudBounds = hud.GetComponent<RectTransform>();

        exit.transform.position = new Vector3(-5, hudBounds.rect.height * hudBounds.localScale.y - 5, 0);

        lives.transform.position = new Vector3(29, hudBounds.rect.height * hudBounds.localScale.y - 5, 0);
        score.transform.position = new Vector3(30, hudBounds.rect.height * hudBounds.localScale.y - 10, 0);
        time.transform.position = new Vector3(30, hudBounds.rect.height * hudBounds.localScale.y - 15, 0);
        scaredTime.transform.position = new Vector3(30, hudBounds.rect.height * hudBounds.localScale.y - 20, 0);
    }
}