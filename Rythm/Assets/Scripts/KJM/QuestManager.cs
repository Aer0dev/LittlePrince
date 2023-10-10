using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;

    Dictionary<int, QuestData> questList;


    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
        if (GlobalVariables.Instance.testVariable!= 0)
            questId = GlobalVariables.Instance.testVariable;
    }

    void GenerateData() //퀘스트 정보 생성
    {
        questList.Add(10, new QuestData(("장미 첫 대화"), new int[] { 1000, 2000 }));
        questList.Add(20, new QuestData(("수리와 공구통"), new int[] { 1000, 4000 }));
        questList.Add(30, new QuestData(("행성정리"), new int[] { 1000, 3000 }));
        questList.Add(40, new QuestData(("출발"), new int[] { 1000, 2000 }));
        questList.Add(50, new QuestData(("도착?"), new int[] { 0}));
    }

    public int GetQuestTalkingIndex(int id)     //퀘스트 정보 index 관리
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)        //퀘스트 관리
    {
        if (id == questList[questId].npcId[questActionIndex])
            questActionIndex++;

        if (questActionIndex == questList[questId].npcId.Length)
            NextQuest();

        return questList[questId].questName;
    }

    public string CheckQuest()
    {
        return questList[questId].questName;
    }


    void NextQuest()    //다음 퀘스트 넘어가기
    {
        questId += 10;
        questActionIndex = 0;
        GlobalVariables.Instance.testVariable = questId;
    }



    //게임 이동 가능 클릭 버튼
    public void ClickFix()
    {
        Debug.Log("씬 이동");
        SceneManager.LoadScene("KmjGameScene");
    }

    public void ClickClear()
    {
        Debug.Log("바오밥나무");
        SceneManager.LoadScene("Stage02_Planet");
    }

    public void ClickLaunch()
    {
        Debug.Log("로켓"); 
        SceneManager.LoadScene("SpaceScene_sh");

    }
}
