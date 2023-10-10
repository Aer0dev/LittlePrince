using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    public QuestManager questManager;
    public TalkingManager talkingManager;
    public int talkingIndex;
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction = false;


    public GameObject toolBox;
    public GameObject clear;
    public GameObject rocket;
    bool ToolBox=false;
    bool Clear = false;
    bool Rocket=false;

    void Update()
    {
        GetButton(toolBox, 30, ToolBox);

        GetButton(clear, 40, Clear);
        GetButton(rocket, 50, Rocket);

    }
    //ob 라는 Object의 퀘스트 가 id에 도착시 bool 값인 onoff로 변경
    public void GetButton(GameObject ob,int id,bool OnOff)
    {
        if (scanObject != null)
            if (scanObject.name == ob.name && isAction == true && questManager.questId >= id && OnOff== false)
            {
                ob.SetActive(true);
                OnOff = true;
            }
            else if (isAction == false)
                OnOff = false;
    }


    void Start()
    {
        Debug.Log(questManager.CheckQuest());    
    }


    public void Action(GameObject scanObj)
    {

        scanObject = scanObj;
        ObjectData objData = scanObj.GetComponent<ObjectData>();
        Talking(objData.id, objData.isNpc);

        talkPanel.SetActive(isAction);

    }

    void Talking(int id, bool isNpc)
    {
        int questTalkingIndex=questManager.GetQuestTalkingIndex(id);
        string talkingData = talkingManager.GetTalking(id+ questTalkingIndex, talkingIndex);


        //End Talk
        if (talkingData == null)
        {
            toolBox.SetActive(false);
            clear.SetActive(false);
            rocket.SetActive(false);

            isAction = false;
            talkingIndex = 0;
           Debug.Log( id+"    "+questManager.CheckQuest(id));
            return;
        }
           //Continue Talk
        if (isNpc)
        {
            talkText.text = talkingData;
        }
        else
        {
            talkText.text = talkingData;

        }
        isAction = true;
        talkingIndex++;
    }
}
