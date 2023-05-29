using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

public class SheetReader : MonoBehaviour
{
    public GameObject[] prefab; // 생성할 프리팹
    public float offsetX = 3.5f; // X 축 위치 오프셋
    public float offsetY = 3.5f; // Y 축 위치 오프셋
    public string filePath = "Assets/Sheet/Shelter_Note.txt"; // 텍스트 파일의 경로
    
    private void Start()
    {
        // 텍스트 파일에서 2차원 배열과 시간 데이터 읽기
        int[,] array;
        int[] timeArray;
        ReadDataFromFile(filePath, out array, out timeArray);

        // 배열 데이터와 시간 데이터 기반으로 프리팹 생성
        StartCoroutine(CreatePrefabsFromData(array, timeArray));
    }

    void ReadDataFromFile(string path, out int[,] array, out int[] timeArray)
    {
        // 텍스트 파일을 읽어옴
        string[] lines = File.ReadAllText(path).Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        array = new int[lines.Length, 2];
        timeArray = new int[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            string[] data = lines[i].Split('|'); // ','를 기준으로 데이터 분리

            if (data.Length >= 3)
            {
                int column;
                int row;
                int time;

                if (int.TryParse(data[0], out column) && int.TryParse(data[1], out row) && int.TryParse(data[2], out time))
                {
                    array[i, 0] = column;
                    array[i, 1] = row;
                    timeArray[i] = time;
                }
                else
                {
                    Debug.LogError("Invalid data format in line " + (i + 1) + " of the text file.");
                }
            }
            else
            {
                Debug.LogError("Invalid data format in line " + (i + 1) + " of the text file.");
            }
        }
    }

    IEnumerator CreatePrefabsFromData(int[,] array, int[] timeArray)
    {
        double startTime = AudioSettings.dspTime; // 시작 시간 기록

        for (int i = 0; i < array.GetLength(0); i++)
        {
            int column = array[i, 0];
            int row = array[i, 1];
            int time = timeArray[i];

            double elapsedTime = AudioSettings.dspTime - startTime; // 경과 시간 계산

            while (elapsedTime < time / 1000.0)
            {
                elapsedTime = AudioSettings.dspTime - startTime; // 경과 시간 업데이트
                yield return null;
            }

            float xPos = GetXPosition(column);
            float yPos = GetYPosition(row);
            int index = Random.Range(0, prefab.Length);
            Instantiate(prefab[index], new Vector3(xPos, yPos, 30), Quaternion.identity);
        }
    }


    float GetXPosition(int col)
    {
        if (col == 0)
            return -3.5f;
        else if (col == 1)
            return 0f;
        else
            return 3.5f;
    }

    float GetYPosition(int row)
    {
        if (row == 0)
            return -3.5f;
        else if (row == 1)
            return 0f;
        else
            return 3.5f;
    }
    /*public string filePath = "Assets/Sh/11.txt"; // 텍스트 파일의 경로


    void Start()
    {
        ReadTextFile(filePath);
    }

    void ReadTextFile(string path)
    {
        // 텍스트 파일을 읽어옴
        string[] lines = File.ReadAllLines(path);

        foreach (string line in lines)
        {
            string[] data = line.Split('|'); // '|'를 기준으로 데이터 분리

            if (data.Length >= 3)
            {
                int column = int.Parse(data[0]);
                int row = int.Parse(data[1]);
                float time = float.Parse(data[2]);

                // 데이터를 Unity에서 사용할 수 있는 방식으로 처리
                // 여기에서 필요한 로직을 작성하면 됩니다
                // 예시: 데이터를 배열이나 리스트에 저장하여 활용
                // 예시: 데이터를 GameObject의 속성으로 설정
            }
        }
    }*/
}
