using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class queststart : MonoBehaviour
{
    public GameObject Questpanel;
    private bool QuestStarted = false;
    public GameObject Questpanel2;
    public GameObject wood1;
    public GameObject wood2;
    public GameObject wood3;
    public GameObject resourcepanel;
    public GameObject qva1;
    public GameObject qva2;
    public GameObject qva3;
    private mainislandquests quest;
    private bool Questended = false;
    public bool Questcomplated = false;
    public bool Questcomplatedbanershow = false;
    public GameObject questqomplatedpanel;
    public GameObject bridge;

    private void Start()
    {
        quest = FindObjectOfType<mainislandquests>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (QuestStarted == false)
            {
                Questpanel.SetActive(true);
                wood1.SetActive(true);
                wood2.SetActive(true);
                wood3.SetActive(true);
                QuestStarted = true;
                resourcepanel.SetActive(true);
                qva1.SetActive(true);
                qva2.SetActive(true);
                qva3.SetActive(true);
            }
            else
            {
                Debug.Log(quest.ChekQuestStatus());
                if (quest.ChekQuestStatus())
                {
                    QBanerSHow();
                    Invoke("QBanerHide", 3);            
                }
                else
                {
                    Questpanel2.SetActive(true);
                }

            }
        }
    }

    private void buildbridge(GameObject bridge)
    {
        if (Questcomplated == true)
        {
            bridge.SetActive(true);
        }
    }

    private void QBanerSHow()
    {
        if (!Questcomplatedbanershow)
        {
            questqomplatedpanel.SetActive(true);
            Questcomplatedbanershow = true;
        }
    }

    private void QBanerHide()
    {
        if (Questcomplatedbanershow)
        {
            questqomplatedpanel.SetActive(false);

            buildbridge(bridge);
            Questended = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (QuestStarted == true)
            {
                Questpanel.SetActive(false);
            }
            Questpanel2.SetActive(false);
        }
    }
}
