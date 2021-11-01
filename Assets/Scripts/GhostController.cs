using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{

    public PacStudentController pacStudentController;
    public Tweener tweener;
    public Animator animator;
    public RuntimeAnimatorController normal;
    public RuntimeAnimatorController scared;

    private float duration = 0.5f;

    private static bool powerPellet;
    private static bool ghostKill;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        powerPellet = pacStudentController.powerPellet;
        ghostKill = pacStudentController.ghostKill;


        if (powerPellet == true)
        {
            StartCoroutine(Scared());

            if (ghostKill == true)
            {
                StartCoroutine(GhostKill());
            }
        }
    }

    private void Move(Vector3 target)
    {
        if (!tweener.TweenExists(transform))
        {
            tweener.AddTween(transform, transform.position, target, duration);
        }
    }

    IEnumerator Scared()
    {
        animator.runtimeAnimatorController = scared;
        yield return new WaitForSeconds(7);
        animator.Play("GhostFlashing");
        yield return new WaitForSeconds(3);
        animator.runtimeAnimatorController = normal;
        powerPellet = false;
    }

    IEnumerator GhostKill()
    {
        animator.runtimeAnimatorController = scared;
        animator.Play("GhostDefeat");
        yield return new WaitForSeconds(1);
        animator.Play("GhostDead");
        yield return new WaitForSeconds(5);
        animator.runtimeAnimatorController = normal;
        ghostKill = false;
    }
}
