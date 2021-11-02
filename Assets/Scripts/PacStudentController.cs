using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PacStudentController : MonoBehaviour
{
    private char lastInput = '.';
    private char currentInput = '.';
    public Tweener tweener;
    private float duration = 0.5f;
    public AudioSource audioSource;
    public AudioClip footstepClip;
    public AudioClip wallClip;
    public AudioClip pelletClip;
    private bool playing = false;
    public Animator animator;
    private bool pause = true;

    public SaveGameManager saveManager;
    public GameMenu gameMenu;

    public bool powerPellet = false;
    private bool dead = false;

    public bool ghostKill = false;

    public GameObject cherry;

    public static float time = 0;

    public static int score { get; set; }
    private Text scoreTxt;

    private Text gameOverTxt;
    private Text startTimerTxt;
    private GameObject scaredTimer;
    private Text scaredTimerTxt;
    private Text timeTxt;

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
        saveManager = GameObject.Find("Managers").GetComponent<SaveGameManager>();
        gameMenu = GameObject.Find("Managers").GetComponent<GameMenu>();

        position = new int[] { 1, 1 };
        scoreTxt = GameObject.Find("ScoreNum").GetComponent<Text>();
        gameOverTxt = GameObject.Find("Game Over").GetComponent<Text>();
        startTimerTxt = GameObject.Find("StartTimer").GetComponent<Text>();
        scaredTimer = GameObject.Find("ScaredTimer");
        timeTxt = GameObject.Find("Timer").GetComponent<Text>();
        scaredTimerTxt = GameObject.Find("TimerScared").GetComponent<Text>();
        scaredTimer.SetActive(false);
        animator.speed = 0;

        score = 0;

        cherry = GameObject.Find("Cherry");
        cherry.SetActive(false);

        StartCoroutine("StartTimer");

    }

    // Update is called once per frame
    void Update()
    {
        if (!pause)
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
                if (position[0] == 14 && position[1] == 0)
                {
                    transform.position = new Vector3(transform.position.x + 26, transform.position.y, transform.position.z);
                    position[1] = 26;
                }

                if (position[0] == 14 && position[1] == 27)
                {
                    transform.position = new Vector3(transform.position.x - 26, transform.position.y, transform.position.z);
                    position[1] = 1;
                }

                if (dead)
                {
                    transform.position = new Vector3(1.0f, 28.0f, transform.position.z);
                    animator.Play("PacStudentRight");
                    position = new int[] { 1, 1 };
                    dead = false;
                }
                TryMove(lastInput);
            }

            StartCoroutine(FootstepAudio());

            if (lastInput != '.')
            {
                StartCoroutine(WallSound());
            }

            if (cherry.activeInHierarchy == false)
            {
                cherry.SetActive(true);
            }

            timeTxt.text = timeFormat(time);
            time += Time.deltaTime;
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
        if (!pause)
        {
            if (key.Equals('W'))
            {
                if (levelMap[position[0] - 1, position[1]] == 0 || levelMap[position[0] - 1, position[1]] == 5 || levelMap[position[0] - 1, position[1]] == 6)
                {
                    Move(transform.position + new Vector3(0.0f, 1.0f, 0.0f));
                    position[0]--;
                    animator.speed = 1;
                    animator.Play("PacStudentUp");
                    Debug.Log(lastInput);
                    currentInput = lastInput;
                }
                else CurrentMove(currentInput);

            }
            if (key.Equals('A')) 
            {
                if (levelMap[position[0], position[1] - 1] == 0 || levelMap[position[0], position[1] - 1] == 5 || levelMap[position[0], position[1] - 1] == 6)
                {
                    Move(transform.position + new Vector3(-1.0f, 0.0f, 0.0f));
                    position[1]--;
                    animator.speed = 1;
                    animator.Play("PacStudentLeft");
                    Debug.Log(lastInput);
                    currentInput = lastInput;
                }
                else CurrentMove(currentInput);

            }
            if (key.Equals('S'))
            {
                if (levelMap[position[0] + 1, position[1]] == 0 || levelMap[position[0] + 1, position[1]] == 5 || levelMap[position[0] + 1, position[1]] == 6)
                    {
                    Move(transform.position + new Vector3(0.0f, -1.0f, 0.0f));
                    position[0]++;
                    animator.speed = 1;
                    animator.Play("PacStudentDown");
                    Debug.Log(lastInput);
                    currentInput = lastInput;
                }
                else CurrentMove(currentInput);

            }
            if (key.Equals('D'))
                {
                if (levelMap[position[0], position[1] + 1] == 0 || levelMap[position[0], position[1] + 1] == 5 || levelMap[position[0], position[1] + 1] == 6)
                {
                    Move(transform.position + new Vector3(1.0f, 0.0f, 0.0f));
                    position[1]++;
                    animator.speed = 1;
                    animator.Play("PacStudentRight");
                    Debug.Log(lastInput);
                    currentInput = lastInput;
                }
                else CurrentMove(currentInput);
            }
        }
    }

    private void CurrentMove(char key)
    {
        if (!pause)
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
                else animator.speed = 0;
            }

            if (key.Equals('A'))
            {
                if (levelMap[position[0], position[1] - 1] == 0 || levelMap[position[0], position[1] - 1] == 5 || levelMap[position[0], position[1] - 1] == 6)
                {
                    Move(transform.position + new Vector3(-1.0f, 0.0f, 0.0f));
                    position[1]--;
                    animator.speed = 1;
                    animator.Play("PacStudentLeft");
                }
                else animator.speed = 0;
            }

            if (key.Equals('S'))
            {
                if (levelMap[position[0] + 1, position[1]] == 0 || levelMap[position[0] + 1, position[1]] == 5 || levelMap[position[0] + 1, position[1]] == 6)
                {
                    Move(transform.position + new Vector3(0.0f, -1.0f, 0.0f));
                    position[0]++;
                    animator.speed = 1;
                    animator.Play("PacStudentDown");
                }
                else animator.speed = 0;
            }

            if (key.Equals('D'))
            {
                if (levelMap[position[0], position[1] + 1] == 0 || levelMap[position[0], position[1] + 1] == 5 || levelMap[position[0], position[1] + 1] == 6)
                {
                    Move(transform.position + new Vector3(1.0f, 0.0f, 0.0f));
                    position[1]++;
                    animator.speed = 1;
                    animator.Play("PacStudentRight");
                }
                else animator.speed = 0;
            }
        }
    }

    IEnumerator WallSound()
    {
        if (!tweener.TweenExists(transform) && playing == false)
        {
            audioSource.clip = wallClip;
            playing = true;
            audioSource.Play();
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
            yield return new WaitForSeconds(0.5f);
            audioSource.Stop();
            gameObject.GetComponentInChildren<ParticleSystem>().Stop();
            playing = false;
        }
    }

    IEnumerator FootstepAudio()
    {
        if (tweener.TweenExists(transform) && playing == false)
        {
            audioSource.clip = footstepClip;
            playing = true;
            audioSource.Play();
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
            yield return new WaitForSeconds(0.5f);
            audioSource.Stop();
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
            cherry.SetActive(false);
            score += 100;
            scoreTxt.text = score.ToString();
        }

        if (other.gameObject.CompareTag("PowerPellet"))
        {
            other.gameObject.SetActive(false);
            scaredTimer.SetActive(true);
            StartCoroutine("ScaredTimer");
        }

        if (other.gameObject.CompareTag("Ghost"))
        {
            if (powerPellet == true)
            {
                ghostKill = true;
                //MUSIC CHANGE
                score += 300;
                scoreTxt.text = score.ToString();
                StartCoroutine("GhostDeathTimer");
                //TIMER FOR RESPAWN
            }
            else
            {
                if (GameObject.Find("Life 3") != null)
                {
                    StartCoroutine("PacDeath");
                    GameObject.Find("Life 3").SetActive(false);
                }
                else if (GameObject.Find("Life 2") != null)
                {
                    StartCoroutine("PacDeath");
                    GameObject.Find("Life 2").SetActive(false);
                }
                else if (GameObject.Find("Life 1") != null)
                {
                    GameObject.Find("Life 1").SetActive(false);
                    gameOverTxt.text = "Game Over";
                    animator.Play("PacStudentDead");
                    saveManager.SaveScore();
                    saveManager.SaveTime();
                    gameMenu.saved = true;
                    pause = true;
                    Invoke("GameOver", 3.0f);
                }


            }
        }
    }

    IEnumerator StartTimer()
    {
        animator.speed = 0;
        startTimerTxt.text = "3";
        yield return new WaitForSeconds(1);
        startTimerTxt.text = "2";
        yield return new WaitForSeconds(1);
        startTimerTxt.text = "1";
        yield return new WaitForSeconds(1);
        startTimerTxt.text = "GO!";
        yield return new WaitForSeconds(1);
        startTimerTxt.text = null;
        animator.speed = 1;
        pause = false;
        cherry.SetActive(true);
    }

    IEnumerator ScaredTimer()
    {

        powerPellet = true;

        for (int i = 10; i >= 0; i--)
        {
            scaredTimerTxt.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        scaredTimer.SetActive(false);
        powerPellet = false;
    }

    IEnumerator GhostDeathTimer()
    {
        for (int i = 5; i >= 0; i--)
        {
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator PacDeath()
    {
        pause = true;
        animator.Play("PacStudentDead");
        //particle effect
        yield return new WaitForSeconds(3);
        pause = false;
        lastInput = '.';
        currentInput = '.';
        dead = true;
    }

    private void GameOver()
    {
        SceneManager.LoadScene("StartScene");
    }

    public string timeFormat(float time)
    {
        int min = (int)time / 60;
        int sec = (int)time - 60 * min;
        int ms = (int)(1000 * (time - min * 60 - sec));
        return string.Format("{0:00}:{1:00}:{2:000}", min, sec, ms);
    }
}