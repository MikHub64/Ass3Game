using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    private char lastInput;
    private char currentInput;
    public Tweener tweener;
    private float duration = 0.5f;
    public AudioSource footstepSource;
    public AudioClip footstep;
    private bool playing = false;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            lastInput = 'W';
            Move(transform.position + new Vector3(0.0f, 1.0f, 0.0f));
            animator.speed = 1;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            lastInput = 'A';
            Move(transform.position + new Vector3(-1.0f, 0.0f, 0.0f));
            animator.speed = 1;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            lastInput = 'S';
            Move(transform.position + new Vector3(0.0f, -1.0f, 0.0f));
            animator.speed = 1;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            lastInput = 'D';
            Move(transform.position + new Vector3(1.0f, 0.0f, 0.0f));
            animator.speed = 1;
        }

        if (!tweener.TweenExists(transform))
        {
            if (lastInput.Equals('W'))
            {
                Move(transform.position + new Vector3(0.0f, 1.0f, 0.0f));
                animator.Play("PacStudentUp");
            }
            if (lastInput.Equals('A'))
            {
                Move(transform.position + new Vector3(-1.0f, 0.0f, 0.0f));
                animator.Play("PacStudentLeft");
            }
            if (lastInput.Equals('S'))
            {
                Move(transform.position + new Vector3(0.0f, -1.0f, 0.0f));
                animator.Play("PacStudentDown");
            }
            if (lastInput.Equals('D'))
            {
                Move(transform.position + new Vector3(1.0f, 0.0f, 0.0f));
                animator.Play("PacStudentRight");
            }
        }

        StartCoroutine(FootstepAudio());
    }

    private void Move(Vector3 target)
    {
        if (!tweener.TweenExists(transform))
        {
                currentInput = lastInput;
                tweener.AddTween(transform, transform.position, target, duration);
        }
    }

    private bool Walkable()
    {
        return true;
    }

    IEnumerator FootstepAudio()
    {
        if (tweener.TweenExists(transform) && playing == false){
            playing = true;
            footstepSource.Play();
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
            yield return new WaitForSeconds(0.5f);
            footstepSource.Stop();
            gameObject.GetComponentInChildren<ParticleSystem>().Stop();
            playing = false;
        }
    }
}
