using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class hsbReader : MonoBehaviour
{
    public GameObject LeftNote; // 생성할 프리팹
    public GameObject RightNote;

    public float offsetX = 3.5f; // X 축 위치 오프셋
    public float offsetY = 3.5f; // Y 축 위치 오프셋
    public string filePath = "Assets/Sheet/RealSheets.txt"; // 텍스트 파일의 경로

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
            string[] data = lines[i].Split('|'); // '|'를 기준으로 데이터 분리

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
            int time = timeArray[i];

            double elapsedTime = AudioSettings.dspTime - startTime; // 경과 시간 계산

            while (elapsedTime < time / 1000.0)
            {
                elapsedTime = AudioSettings.dspTime - startTime; // 경과 시간 업데이트
                yield return null;
            }

            float xPos = GetXPosition(column);
            float yPos = GetYPosition(column);

            if(xPos == -3.5f)
            {
                Instantiate(LeftNote, new Vector3(xPos, yPos, 30), Quaternion.identity);
            }

            else
            {
                Instantiate(RightNote, new Vector3(xPos, yPos, 30), Quaternion.identity);
            }
            
        }
    }

    float GetXPosition(int col)
    {
        if (col == 0)
            return -3.5f;
        else if (col == 1)
            return 0f;
        else
            return 1.5f;
    }

    float GetYPosition(int col)
    {
        if (col == 0)
            return -3.5f;
        else if (col == 1)
            return 0f;
        else
            return 0.2f;
    }
}

