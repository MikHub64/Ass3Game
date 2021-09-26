using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip step;
    public bool playing = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Walk());
    }

    // Update is called once per frame
    IEnumerator Walk()
    {
        AudioSource audio = GetComponent<AudioSource>();
        while (playing == true)
        {
            audio.PlayOneShot(step);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
