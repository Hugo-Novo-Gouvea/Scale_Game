using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LogoController : MonoBehaviour
{
    public GameObject BackGround;
    public GameObject[] StartMenuBtn;

    private Animator animatorLogo;
    private Rigidbody2D rigidbobyLogo;

    private bool logoMovement, LogoAnimation, btnReady;
    private float initialPos = -40.22f, finalPos = -46.61f, distance, inicialVelocity = 3, brake;
    
    void Start()
    {
        animatorLogo = GetComponent<Animator>();
        rigidbobyLogo = GetComponent<Rigidbody2D>();

        logoMovement = false;
        LogoAnimation = false;
        btnReady = false;
        distance = finalPos - initialPos;
        distance = Mathf.Abs(distance);

        StartCoroutine(movementController());
    }

    void Update()
    {
        if (logoMovement == true && LogoAnimation == false)
            LogoAnimation = AnimationController();

        if (logoMovement == true && LogoAnimation == true && btnReady == false)
        {
            for (int i = 0; i < StartMenuBtn.Length; i++)
            {
                StartMenuBtn[i].SetActive(true);
                StartMenuBtn[i].GetComponent<BtnStart>().CallCoroutine();
            }
            btnReady = true;
        }

    }

    private IEnumerator movementController()
    {
        for (int i = 100; i > -1; i--)
        {
            brake = ((((float)i/100)* distance * inicialVelocity) / distance);
            rigidbobyLogo.velocity = new Vector3(0, -brake, 0);
            yield return new WaitForSeconds(0.038f);
        }
        logoMovement = true;
    }

    private bool AnimationController()
    {
        if (animatorLogo.GetCurrentAnimatorStateInfo(0).IsName("darkLogo")) //checks whether the "start" animation is already ended
            animatorLogo.SetBool("start", true);

        if (animatorLogo.GetCurrentAnimatorStateInfo(0).IsName("start")) //checks whether the "start" animation is already ended
            animatorLogo.SetBool("idle", true);

        if (animatorLogo.GetCurrentAnimatorStateInfo(0).IsName("idle")) //checks whether the "start" animation is already ended
        {
            BackGround.GetComponent<Animator>().SetBool("start", true);
            animatorLogo.SetBool("start", false);
            return (true);
        }
        else
            return (false);
        
    }
}
