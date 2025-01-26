using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playAnimation();
        }
    }
    public void playAnimation()
    {
        // Check if the animation is playing
        if (anim != null)
        {
            anim.Play("Base Layer.ArmSwing", 0, 0f);

        }
        //Set timer to perform some thing after the animation
        StartCoroutine(AfterAnimation());
    }

    private IEnumerator AfterAnimation()
    {
        
        yield return new WaitForSeconds(0.5f);

        //Place the code here to perform things after the animation
        Debug.Log("Display after animation");
    }
}
