using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_test : MonoBehaviour {
    public GameObject[] Ring;
    public Animator[] RingAnim;

    bool StartGame = false;
    public Animator animator;

    // Use this for initialization
    void Start () {
        animator.SetBool("Idling", true);
    }
	
	// Update is called once per frame
	void Update () {

        if(StartGame == false)
        {
            int Rand = Random.Range(0, 4);

            switch (Rand)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    StartCoroutine(OnRingObj(Rand));
                    break;
                default:
                    break;
            }

        }

    }

    IEnumerator OnRingObj(int index)
    {
        StartGame = true;
        float AnimSpeedRand = Random.Range(1.0f, 2.0f);
        int RingNumber1 = Random.Range(0, 4);
        int RingNumber2 = Random.Range(0, 4);

        List<int> RingNumberList = new List<int>();

       

        if (index <= 1)
        {
            RingNumberList.Add(RingNumber1);
        }
        else
        {
            RingNumberList.Add(RingNumber1);
            RingNumberList.Add(RingNumber2);
        }

        for(int i = 0; i < RingNumberList.Count; i++)
        {
            int RingIndex =  RingNumberList[i];

            Ring[RingIndex].SetActive(true);
            RingAnim[RingIndex].speed = AnimSpeedRand;
            RingAnim[RingIndex].Play("RingAnim");
        }

        for (int i = 0; i < Ring.Length; i++)
        {
            if(RingNumberList.FindIndex(item => item == i) == -1)
            {
                Ring[i].SetActive(false);
            }
           
        }

        yield return new WaitForSeconds(1 / AnimSpeedRand);

        for (int i = 0; i < Ring.Length; i++)
        {
            Ring[i].SetActive(false);
            RingAnim[i].speed = 1;
            RingAnim[i].Play("Idle");
        }
        StartGame = false;
    }


    public void ClickEventCheck(GameObject obj)
    {
        if(obj.activeSelf && obj.transform.localScale.x < 0.7f && obj.transform.localScale.x > 0.4f)
        {
            animator.SetTrigger("Pain");
            Debug.Log("Click!");
        }
           

    }

}
