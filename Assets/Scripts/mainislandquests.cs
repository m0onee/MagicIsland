using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainislandquests : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool Questended = false;
    public bool Questcomplated = false;
    public bool Questcomplatedbanershow = false;
    public GameObject questqomplatedpanel;
    public GameObject bridge;
    

    public void ChekQuestProcessing(float woodcounter, float stonecounter)//
    {     

        if (woodcounter == 3 && stonecounter == 3 && !Questended) 
        {
            Questcomplated = true;
            QBanerSHow();
            Invoke("QBanerHide", 3);
            Debug.Log("aa");
        }

        ChekQuestStatus();
    }

    public bool ChekQuestStatus()
    {
        if (Questended)
        {
            return true;
        }
        return false;
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
    private void buildbridge(GameObject bridge)
    {
        if (Questcomplated == true)
        {
            bridge.SetActive(true);
        }
    }
}
