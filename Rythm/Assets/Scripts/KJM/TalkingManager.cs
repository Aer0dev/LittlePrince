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

    void GenerateData()     //퀘스트 내용
    {
        talkingData.Add(1000, new string[] { " 안녕?", "무슨일이니?" });
        talkingData.Add(2000, new string[] { " 로켓이다." });
        talkingData.Add(3000, new string[] { "바오밥나무다." });
        talkingData.Add(4000, new string[] { "공구상자다." });


        talkingData.Add(10 + 1000, new string[] { " 몸이 너무 안좋아..",
                                        "~~행성에 샘물을 구해줘야겠어!",
                                         "~~행성까지 가기위해서는 로켓이필요해 상태를 확인하고 와줘"});
        talkingData.Add(11 + 2000, new string[] { " 수리를 해야될것 같다."
                                    , "장미에게 돌아가보자." });

        talkingData.Add(20 + 1000, new string[] {"뭐야! 고장이 났다고?",
                                        "..........",
                                        "고칠생각은 해봤니?",
                                        "로켓옆에있는 공구상자를 이용해봐."});
        talkingData.Add(21 + 4000, new string[] {"공구상자다.",
                                        "로켓을 고칠 수 있을것 같다.",
                                        "한번더 눌러보자  (사용 Key : Space)"});

        talkingData.Add(30 + 1000, new string[] {"로켓을 수리했다고!! 잘했어!",
                                        "...................",
                                        "뭐? 바로 출발한다고??",
                                        "언제돌아올지도 모르는데 바오밥나무가 이 소행성에 뿌리를 깊이 박아버리면 어떡하려구!!",
                                        "하여간... 생각이 짧다닌까..",
                                        "출발전에 바오밥나무 뿌리들을 정리하고가"});
        talkingData.Add(31 + 3000, new string[] {"바오밥나무다...",
                                         "뿌리가 깊이 박혀있다.",
                                        "정리가 필요할것같다.",
                                        "한번더 눌러보자 (사용 Key : A/D)"});

        talkingData.Add(40 + 1000, new string[] { ".........",
                                        "떠날준비를 마쳤구나.",
                                        "빨리 돌아와야해..",
                                        "(로켓으로 가보자.)"});
        talkingData.Add(41 + 2000, new string[] { "로켓이다.",
                                        "~~행성까지 빠르게 가려면 로켓에서 안내하는 링을 따라가는게 빠르다",
                                        "한번더 눌러보자 (사용 Key : Mouse)"});

        talkingData.Add(50 + 1000, new string[] { "잘다녀와.." });

    }

    public string GetTalking(int id, int talkingIndex)
    {
        if (!talkingData.ContainsKey(id))
        {       //퀘스트 진행 순서 대사가 없을경우 퀘스트의 맨 처음 대사를 가지고 온다.
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
