using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PacStudentController : MonoBehaviour
{
    private char lastInput = '.';
    private char currentInput;
    public Tweener tweener;
    private float duration = 0.5f;
    public AudioSource footstepSource;
    public AudioClip footstep;
    public AudioSource wallSource;
    public AudioClip wall;
    private bool playing = false;
    public Animator animator;

    public int score = 0;
    private Text scoreTxt;

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
        scoreTxt = GameObject.Find("ScoreNum").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            lastInput = 'W';
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            lastInput = 'A';
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            lastInput = 'S';
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            lastInput = 'D';
        }


        if (!tweener.TweenExists(transform))
        {
            TryMove(lastInput);
        }

        StartCoroutine(FootstepAudio());

        if(lastInput != '.')
        {
            StartCoroutine(WallSound());
        }


        if(position[0] == 14 && position[1] - 1 == 0)
        {
            transform.position = new Vector2(transform.position.x + 24, transform.position.y);
            position[0] = 14;
            position[1] = 24;
        }

        if (position[0] == 14 && position[1] + 1 == 28)
        {
            transform.position = new Vector2(transform.position.x - 24, transform.position.y);
            position[0] = 14;
            position[1] = 1;
        }
    }

    private void Move(Vector3 target)
    {
        if (!tweener.TweenExists(transform))
        {
            tweener.AddTween(transform, transform.position, target, duration);
        }
    }

    private void TryMove(char key)
    {
        if (!tweener.TweenExists(transform))
        {
            if (key.Equals('W') && key != currentInput)
            {
                if (levelMap[position[0] - 1, position[1]] == 0 || levelMap[position[0] - 1, position[1]] == 5 || levelMap[position[0] - 1, position[1]] == 6)
                {
                    Move(transform.position + new Vector3(0.0f, 1.0f, 0.0f));
                    currentInput = lastInput;
                    position[0]--;
                    animator.speed = 1;
                    animator.Play("PacStudentUp");
                    Debug.Log("lastUp");
                }
                else CurrentMove(currentInput);

            }
            if (levelMap[position[0], position[1] - 1] == 0 || levelMap[position[0], position[1] - 1] == 5 || levelMap[position[0], position[1] - 1] == 6)
            {
                if (key.Equals('A') && key != currentInput)
                {
                    Move(transform.position + new Vector3(-1.0f, 0.0f, 0.0f));
                    currentInput = lastInput;
                    position[1]--;
                    animator.speed = 1;
                    animator.Play("PacStudentLeft");
                    Debug.Log("lastLeft");
                }
                else CurrentMove(currentInput);

            }
            if (levelMap[position[0] + 1, position[1]] == 0 || levelMap[position[0] + 1, position[1]] == 5 || levelMap[position[0] + 1, position[1]] == 6)
            {
                if (key.Equals('S') && key != currentInput)
                {
                    Move(transform.position + new Vector3(0.0f, -1.0f, 0.0f));
                    currentInput = lastInput;
                    position[0]++;
                    animator.speed = 1;
                    animator.Play("PacStudentDown");
                    Debug.Log("lastDown");
                }
                else CurrentMove(currentInput);
            }
            if (levelMap[position[0], position[1] + 1] == 0 || levelMap[position[0], position[1] + 1] == 5 || levelMap[position[0], position[1] + 1] == 6)
            {
                if (key.Equals('D') && key != currentInput)
                {
                    Move(transform.position + new Vector3(1.0f, 0.0f, 0.0f));
                    currentInput = lastInput;
                    position[1]++;
                    animator.speed = 1;
                    animator.Play("PacStudentRight");
                    Debug.Log("lastRight");
                }
                else CurrentMove(currentInput);
            }
        }
    }

    private void CurrentMove(char key)
    {
        if (!tweener.TweenExists(transform))
        {
            if (key.Equals('W'))
            {
                if (levelMap[position[0] - 1, position[1]] == 0 || levelMap[position[0] - 1, position[1]] == 5 || levelMap[position[0] - 1, position[1]] == 6)
                {
                    Move(transform.position + new Vector3(0.0f, 1.0f, 0.0f));
                    position[0]--;
                    animator.speed = 1;
                    animator.Play("PacStudentUp");
                }
                else
                {
                    animator.speed = 0;

                    Debug.Log(position[0] + "" + position[1]);
                }

            }
            if (levelMap[position[0], position[1] - 1] == 0 || levelMap[position[0], position[1] - 1] == 5 || levelMap[position[0], position[1] - 1] == 6)
            {
                if (key.Equals('A'))
                {
                    Move(transform.position + new Vector3(-1.0f, 0.0f, 0.0f));
                    position[1]--;
                    animator.speed = 1;
                    animator.Play("PacStudentLeft");
                }
                else
                {
                    animator.speed = 0;
                    Debug.Log(position[0] + "" + position[1]);
                }

            }
            if (levelMap[position[0] + 1, position[1]] == 0 || levelMap[position[0] + 1, position[1]] == 5 || levelMap[position[0] + 1, position[1]] == 6)
            {
                if (key.Equals('S'))
                {
                    Move(transform.position + new Vector3(0.0f, -1.0f, 0.0f));
                    position[0]++;
                    animator.speed = 1;
                    animator.Play("PacStudentDown");
                }
                else
                {
                    animator.speed = 0;

                    Debug.Log(position[0] + "" + position[1]);
                }
            }
            if (levelMap[position[0], position[1] + 1] == 0 || levelMap[position[0], position[1] + 1] == 5 || levelMap[position[0], position[1] + 1] == 6)
            {
                if (key.Equals('D'))
                {
                    Move(transform.position + new Vector3(1.0f, 0.0f, 0.0f));
                    position[1]++;
                    animator.speed = 1;
                    animator.Play("PacStudentRight");
                }
                else
                {
                    animator.speed = 0;

                    Debug.Log(position[0] + "" + position[1]);
                }
            }
        }
    }

    IEnumerator WallSound()
    {
        if (!tweener.TweenExists(transform) && playing == false)
        {
            playing = true;
            wallSource.Play();
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
            yield return new WaitForSeconds(0.5f);
            wallSource.Stop();
            gameObject.GetComponentInChildren<ParticleSystem>().Stop();
            playing = false;
        }
    }

    IEnumerator FootstepAudio()
    {
        if (tweener.TweenExists(transform) && playing == false)
        {
            playing = true;
            footstepSource.Play();
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
            yield return new WaitForSeconds(0.5f);
            footstepSource.Stop();
            gameObject.GetComponentInChildren<ParticleSystem>().Stop();
            playing = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pellet"))
        {
            other.gameObject.SetActive(false);
            score += 10;
            scoreTxt.text = score.ToString();
        }

        if (other.gameObject.CompareTag("Cherry"))
        {
            other.gameObject.SetActive(false);
            score += 100;
            scoreTxt.text = score.ToString();
        }

        if (other.gameObject.CompareTag("PowerPellet"))
        {
            other.gameObject.SetActive(false);
            //??
        }
        if (other.gameObject.CompareTag("Ghost"))
        {
            /**if(PELLET ACTIVE){
                GHOST DIES
                MUSIC CHANGE
                score += 300;
                scoreTxt.text = score.ToString();
                TIMER FOR RESPAWN
            } else **/
            {
                if (GameObject.Find("Life 3") != null)
                {
                    GameObject.Find("Life 3").SetActive(false);
                }
                else if (GameObject.Find("Life 2") != null)
                {
                    GameObject.Find("Life 2").SetActive(false);
                }
                else if (GameObject.Find("Life 1") != null)
                {
                    GameObject.Find("Life 1").SetActive(false);
                }

                //transform.position = new Vector2(1.0f, 28.0f);
                //position = new int[]{ 1, 1 };
            }

            
        }
    }
}