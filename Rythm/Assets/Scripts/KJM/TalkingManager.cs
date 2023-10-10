using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingManager : MonoBehaviour
{
    Dictionary<int, string[]> talkingData;
    void Awake()
    {
        talkingData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()     //����Ʈ ����
    {
        talkingData.Add(1000, new string[] { " �ȳ�?", "�������̴�?" });
        talkingData.Add(2000, new string[] { " �����̴�." });
        talkingData.Add(3000, new string[] { "�ٿ��䳪����." });
        talkingData.Add(4000, new string[] { "�������ڴ�." });


        talkingData.Add(10 + 1000, new string[] { " ���� �ʹ� ������..",
                                        "~~�༺�� ������ ������߰ھ�!",
                                         "~~�༺���� �������ؼ��� �������ʿ��� ���¸� Ȯ���ϰ� ����"});
        talkingData.Add(11 + 2000, new string[] { " ������ �ؾߵɰ� ����."
                                    , "��̿��� ���ư�����." });

        talkingData.Add(20 + 1000, new string[] {"����! ������ ���ٰ�?",
                                        "..........",
                                        "��ĥ������ �غô�?",
                                        "���Ͽ����ִ� �������ڸ� �̿��غ�."});
        talkingData.Add(21 + 4000, new string[] {"�������ڴ�.",
                                        "������ ��ĥ �� ������ ����.",
                                        "�ѹ��� ��������  (��� Key : Space)"});

        talkingData.Add(30 + 1000, new string[] {"������ �����ߴٰ�!! ���߾�!",
                                        "...................",
                                        "��? �ٷ� ����Ѵٰ�??",
                                        "�������ƿ����� �𸣴µ� �ٿ��䳪���� �� ���༺�� �Ѹ��� ���� �ھƹ����� ��Ϸ���!!",
                                        "�Ͽ���... ������ ª�ٴѱ�..",
                                        "������� �ٿ��䳪�� �Ѹ����� �����ϰ�"});
        talkingData.Add(31 + 3000, new string[] {"�ٿ��䳪����...",
                                         "�Ѹ��� ���� �����ִ�.",
                                        "������ �ʿ��ҰͰ���.",
                                        "�ѹ��� �������� (��� Key : A/D)"});

        talkingData.Add(40 + 1000, new string[] { ".........",
                                        "�����غ� ���Ʊ���.",
                                        "���� ���ƿ;���..",
                                        "(�������� ������.)"});
        talkingData.Add(41 + 2000, new string[] { "�����̴�.",
                                        "~~�༺���� ������ ������ ���Ͽ��� �ȳ��ϴ� ���� ���󰡴°� ������",
                                        "�ѹ��� �������� (��� Key : Mouse)"});

        talkingData.Add(50 + 1000, new string[] { "�ߴٳ��.." });

    }

    public string GetTalking(int id, int talkingIndex)
    {
        if (!talkingData.ContainsKey(id))
        {       //����Ʈ ���� ���� ��簡 ������� ����Ʈ�� �� ó�� ��縦 ������ �´�.
            if (!talkingData.ContainsKey(id - id % 10))
                return GetTalking(id - id % 100, talkingIndex);
            else
                return GetTalking(id - id % 10, talkingIndex);
        }

        if (talkingIndex == talkingData[id].Length)
        {
            return null;
        }
        else
            return talkingData[id][talkingIndex];
    }
}
