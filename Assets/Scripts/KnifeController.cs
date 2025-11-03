using UnityEngine;

public class KnifeController : MonoBehaviour
{
    public Animator anim;
    public BackstabSystem backstab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Swing");
            backstab.TryAttack();
        }
    }
}
