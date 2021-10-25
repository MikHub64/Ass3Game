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

    public int[,] levelMap =
    {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7,7,2,2,2,2,2,2,2,2,2,2,2,2,1},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4,4,5,5,5,5,5,5,5,5,5,5,5,5,2},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4,4,5,3,4,4,4,3,5,3,4,4,3,5,2},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4,4,5,4,0,0,0,4,5,4,0,0,4,6,2},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3,3,5,3,4,4,4,3,5,3,4,4,3,5,2},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4,4,4,4,3,5,3,3,5,3,4,4,3,5,2},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3,3,4,4,3,5,4,4,5,3,4,4,3,5,2},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,5,5,2},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4,4,0,3,4,4,3,4,5,1,2,2,2,2,1},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3,3,0,3,4,4,3,4,5,2,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0,0,0,0,0,0,4,4,5,2,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0,0,4,4,3,0,4,4,5,2,0,0,0,0,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0,0,0,0,4,0,3,3,5,1,2,2,2,2,2},
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0,0,0,0,4,0,0,0,5,0,0,0,0,0,0},
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0,0,0,0,4,0,0,0,5,0,0,0,0,0,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0,0,0,0,4,0,3,3,5,1,2,2,2,2,2},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0,0,4,4,3,0,4,4,5,2,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0,0,0,0,0,0,4,4,5,2,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3,3,0,3,4,4,3,4,5,2,0,0,0,0,0},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4,4,0,3,4,4,3,4,5,1,2,2,2,2,1},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,5,5,2},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3,3,4,4,3,5,4,4,5,3,4,4,3,5,2},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4,4,4,4,3,5,3,3,5,3,4,4,3,5,2},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3,3,5,3,4,4,4,3,5,3,4,4,3,5,2},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4,4,5,4,0,0,0,4,5,4,0,0,4,6,2},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4,4,5,3,4,4,4,3,5,3,4,4,3,5,2},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4,4,5,5,5,5,5,5,5,5,5,5,5,5,2},
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7,7,2,2,2,2,2,2,2,2,2,2,2,2,1},
    };

    private int[] position;

    // Start is called before the first frame update
    void Start()
    {
        position = new int[] { 1, 1 };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            lastInput = 'W';
            if (levelMap[position[0]-1, position[1]] == 0 || levelMap[position[0]-1, position[1]] == 5 || levelMap[position[0]-1, position[1]] == 6)
            {
                position[0]--;
                Move(transform.position + new Vector3(0.0f, 1.0f, 0.0f));
                animator.speed = 1;
            }
            else animator.speed = 0;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            lastInput = 'A';
            if (levelMap[position[0], position[1]-1] == 0 || levelMap[position[0], position[1]-1] == 5 || levelMap[position[0], position[1]-1] == 6)
            {
                position[1]--;
                Move(transform.position + new Vector3(-1.0f, 0.0f, 0.0f));
                animator.speed = 1;
            }
            else animator.speed = 0;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            lastInput = 'S';
            if (levelMap[position[0]+1, position[1]] == 0 || levelMap[position[0]+1, position[1]] == 5 || levelMap[position[0]+1, position[1]] == 6)
            {
                position[0]++;
                Move(transform.position + new Vector3(0.0f, -1.0f, 0.0f));
                animator.speed = 1;
            }
            else animator.speed = 0;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            lastInput = 'D';
            if (levelMap[position[0], position[1]+1] == 0 || levelMap[position[0], position[1]+1] == 5 || levelMap[position[0], position[1]+1] == 6)
            {
                position[1]++;
                Move(transform.position + new Vector3(1.0f, 0.0f, 0.0f));
                animator.speed = 1;
            }
            else animator.speed = 0;
        }

        if (!tweener.TweenExists(transform))
        {
            if (levelMap[position[0] - 1, position[1]] == 0 || levelMap[position[0] - 1, position[1]] == 5 || levelMap[position[0] - 1, position[1]] == 6)
            {
                if (lastInput.Equals('W'))
                {
                    position[0]--;
                    Move(transform.position + new Vector3(0.0f, 1.0f, 0.0f));
                    animator.speed = 1;
                    animator.Play("PacStudentUp");
                }

            }
            if (levelMap[position[0], position[1] - 1] == 0 || levelMap[position[0], position[1] - 1] == 5 || levelMap[position[0], position[1] - 1] == 6)
            {
                if (lastInput.Equals('A')) 
                {
                    position[1]--;
                    Move(transform.position + new Vector3(-1.0f, 0.0f, 0.0f));
                    animator.speed = 1;
                    animator.Play("PacStudentLeft");
                }

            }
            if (levelMap[position[0] + 1, position[1]] == 0 || levelMap[position[0] + 1, position[1]] == 5 || levelMap[position[0] + 1, position[1]] == 6)
            {
                if (lastInput.Equals('S'))
                {
                    position[0]++;
                    Move(transform.position + new Vector3(0.0f, -1.0f, 0.0f));
                    animator.speed = 1;
                    animator.Play("PacStudentDown");
                }
            }
            if (levelMap[position[0], position[1] + 1] == 0 || levelMap[position[0], position[1] + 1] == 5 || levelMap[position[0], position[1] + 1] == 6)
            {
                if (lastInput.Equals('D')) 
                {
                    position[1]++;
                    Move(transform.position + new Vector3(1.0f, 0.0f, 0.0f));
                    animator.speed = 1;
                    animator.Play("PacStudentRight");
                }
            }
        }

        Debug.Log(levelMap[position[0], position[1] + 1]);
        Debug.Log(levelMap[position[0], position[1] - 1]);
        Debug.Log(levelMap[position[0] + 1, position[1]]);
        Debug.Log(levelMap[position[0] - 1, position[1]]);
        Debug.Log(position[0] + " " + position[1]);

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

    private void Up()
    {
        if (lastInput.Equals('W'))
        {
            if (levelMap[position[0] - 1, position[1]] == 0 || levelMap[position[0] - 1, position[1]] == 5 || levelMap[position[0] - 1, position[1]] == 6)
            {
                position[0]--;
                Move(transform.position + new Vector3(0.0f, 1.0f, 0.0f));
                animator.speed = 1;
            }
            else animator.speed = 0;
            animator.Play("PacStudentUp");
        }
    }

    private void Left()
    {
        if (lastInput.Equals('A'))
        {
            if (levelMap[position[0], position[1] - 1] == 0 || levelMap[position[0], position[1] - 1] == 5 || levelMap[position[0], position[1] - 1] == 6)
            {
                position[1]--;
                Move(transform.position + new Vector3(-1.0f, 0.0f, 0.0f));
                animator.speed = 1;
            }
            else animator.speed = 0;
            animator.Play("PacStudentLeft");
        }
    }

    private void Down()
    {
        if (lastInput.Equals('S'))
        {
            if (levelMap[position[0] + 1, position[1]] == 0 || levelMap[position[0] + 1, position[1]] == 5 || levelMap[position[0] + 1, position[1]] == 6)
            {
                position[0]++;
                Move(transform.position + new Vector3(0.0f, -1.0f, 0.0f));
                animator.speed = 1;
            }
            else animator.speed = 0;
            animator.Play("PacStudentDown");
        }
    }

    private void Right()
    {
        if (lastInput.Equals('D'))
        {
            if (levelMap[position[0], position[1] + 1] == 0 || levelMap[position[0], position[1] + 1] == 5 || levelMap[position[0], position[1] + 1] == 6)
            {
                position[1]++;
                Move(transform.position + new Vector3(1.0f, 0.0f, 0.0f));
                animator.speed = 1;
            }
            else animator.speed = 0;
            animator.Play("PacStudentRight");
        }
    }
}
