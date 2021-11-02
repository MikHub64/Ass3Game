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
    public RuntimeAnimatorController flashing;

    private float duration = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (pacStudentController.powerPellet == true)
        {
            StartCoroutine(Scared());

            if (pacStudentController.ghostKill == true)
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
        //animator.runtimeAnimatorController = flashing;
        yield return new WaitForSeconds(3);
        animator.runtimeAnimatorController = normal;
        pacStudentController.powerPellet = false;
    }

    IEnumerator GhostKill()
    {
        animator.runtimeAnimatorController = scared;
        animator.Play("GhostDefeat");
        yield return new WaitForSeconds(1);
        animator.Play("GhostDead");
        yield return new WaitForSeconds(5);
        animator.runtimeAnimatorController = normal;
        pacStudentController.ghostKill = false;
    }
}
