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

    void GenerateData() //����Ʈ ���� ����
    {
        questList.Add(10, new QuestData(("��� ù ��ȭ"), new int[] { 1000, 2000 }));
        questList.Add(20, new QuestData(("������ ������"), new int[] { 1000, 4000 }));
        questList.Add(30, new QuestData(("�༺����"), new int[] { 1000, 3000 }));
        questList.Add(40, new QuestData(("���"), new int[] { 1000, 2000 }));
        questList.Add(50, new QuestData(("����?"), new int[] { 0}));
    }

    public int GetQuestTalkingIndex(int id)     //����Ʈ ���� index ����
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)        //����Ʈ ����
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


    void NextQuest()    //���� ����Ʈ �Ѿ��
    {
        questId += 10;
        questActionIndex = 0;
        GlobalVariables.Instance.testVariable = questId;
    }



    //���� �̵� ���� Ŭ�� ��ư
    public void ClickFix()
    {
        Debug.Log("�� �̵�");
        SceneManager.LoadScene("KmjGameScene");
    }

    public void ClickClear()
    {
        Debug.Log("�ٿ��䳪��");
        SceneManager.LoadScene("Stage02_Planet");
    }

    public void ClickLaunch()
    {
        Debug.Log("����"); 
        SceneManager.LoadScene("SpaceScene_sh");

    }
}
