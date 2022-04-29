using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DancingScript : MonoBehaviour
{
    [Header("Extra Animations")]
    public string CAnimation = "Action Idle To Standing Idle"; //Cancel to this Animation
    [Header("Animations by First, Second, Third Button")]
    public List<string> FAnimationList = new List<string>();
    public List<string> SAnimationList = new List<string>();
    public List<string> TAnimationList = new List<string>();

    Animator anim;

    private int animphase = 0;

    bool animState;

    public CameraControls CControlScript;

    private static List<string> nextInQueue = new List<string>(); //A list to hold the next animation we would like to play.

    public Text currentAnimText;
    public Text nextAnimText;

    public void Start()
    {
        anim = GetComponent<Animator>(); //Gets the animator of the object that this script is connected to

        FAnimationList.Add("Breakdance Uprock Start");
        FAnimationList.Add("Silly Dancing");
        FAnimationList.Add("Breakdance 1990 (3)");

        SAnimationList.Add("Robot Hip Hop Dance");
        SAnimationList.Add("Breakdance 1990 (2)");
        SAnimationList.Add("Breakdance Uprock End");

        TAnimationList.Add("Breakdance 1990 (1)");
        TAnimationList.Add("Breakdance Freeze Var 4");
        TAnimationList.Add("Dancing Twerk");

        CControlScript = GameObject.Find("CM StateDrivenCamera1").GetComponent<CameraControls>();
        currentAnimText = GameObject.Find("CurrentAnimText").GetComponent<Text>();
        nextAnimText = GameObject.Find("NextAnimText").GetComponent<Text>();
    }

    void Update()
    {
        AnimatorClipInfo[] animinfo; //Gets current animations info and connects it to the currentAnim var
        animinfo = this.anim.GetCurrentAnimatorClipInfo(0);
        string currentAnim;
        currentAnim = animinfo[0].clip.name;

        currentAnimText.text = "Current Move = " + currentAnim;
        if (nextInQueue.Count != 0)
        {
            nextAnimText.text = "Next Move = " + nextInQueue[0];
        }
        
        Debug.Log("Animphase " + animphase);

        if (!(CControlScript.groundedCam))
        {

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || anim.GetCurrentAnimatorStateInfo(0).IsName(CAnimation)) { animState = false; }
            else { animState = true; }
            //Character is constantly playing an animation (Idle at all times) so if current
            //animation name is Idle we set the animation state to False as in not playing and else to true.

            if (!animState)
            {
                if (nextInQueue.Count != 0) //If we have a next animation
                {
                    anim.Play(nextInQueue[0]); //Play the first and only item in our list of next animations
                    animphase++; //Increasing animphase with every animation we're doing
                    nextInQueue.Clear(); //and clear the list once again because we already played it
                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                nextInQueue.Clear(); //Clear the list because we'r going to cancel any animation
                anim.Play(CAnimation); //Cancel animation and return to Idle
                animphase = 0; //setting animation phase to 0 because we've canceled all animations
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (animState) //Is there was any animation playing atm
                {
                    nextInQueue.Clear(); //Clear the list because we only need one item in it 
                    nextInQueue.Add(FAnimationList[animphase]); //Add to the list after clearing it, so we can use it later on
                }
                else //If there was no animation playing atm it will play selected animation right off
                {
                    anim.Play(FAnimationList[0]);
                    animphase = 1;
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (animState)
                {
                    nextInQueue.Clear();
                    nextInQueue.Add(SAnimationList[animphase]);
                }
                else
                {
                    anim.Play(SAnimationList[0]);
                    animphase = 1;
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (animState)
                {
                    nextInQueue.Clear();
                    nextInQueue.Add(TAnimationList[animphase]);
                }
                else
                {
                    anim.Play(TAnimationList[0]);
                    animphase = 1;
                }
            }

            if (animphase >= FAnimationList.Count) { animphase = 0; } //Making sure that animphase doesn't exceed our animations numbers
        }
    }
}
