using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

public class SheetReader : MonoBehaviour
{
    public GameObject[] prefab; // ������ ������
    public float offsetX = 3.5f; // X �� ��ġ ������
    public float offsetY = 3.5f; // Y �� ��ġ ������
    public string filePath = "Assets/Sheet/Shelter_Note.txt"; // �ؽ�Ʈ ������ ���
    
    private void Start()
    {
        // �ؽ�Ʈ ���Ͽ��� 2���� �迭�� �ð� ������ �б�
        int[,] array;
        int[] timeArray;
        ReadDataFromFile(filePath, out array, out timeArray);

        // �迭 �����Ϳ� �ð� ������ ������� ������ ����
        StartCoroutine(CreatePrefabsFromData(array, timeArray));
    }

    void ReadDataFromFile(string path, out int[,] array, out int[] timeArray)
    {
        // �ؽ�Ʈ ������ �о��
        string[] lines = File.ReadAllText(path).Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        array = new int[lines.Length, 2];
        timeArray = new int[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            string[] data = lines[i].Split('|'); // ','�� �������� ������ �и�

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
        double startTime = AudioSettings.dspTime; // ���� �ð� ���

        for (int i = 0; i < array.GetLength(0); i++)
        {
            int column = array[i, 0];
            int row = array[i, 1];
            int time = timeArray[i];

            double elapsedTime = AudioSettings.dspTime - startTime; // ��� �ð� ���

            while (elapsedTime < time / 1000.0)
            {
                elapsedTime = AudioSettings.dspTime - startTime; // ��� �ð� ������Ʈ
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
    /*public string filePath = "Assets/Sh/11.txt"; // �ؽ�Ʈ ������ ���


    void Start()
    {
        ReadTextFile(filePath);
    }

    void ReadTextFile(string path)
    {
        // �ؽ�Ʈ ������ �о��
        string[] lines = File.ReadAllLines(path);

        foreach (string line in lines)
        {
            string[] data = line.Split('|'); // '|'�� �������� ������ �и�

            if (data.Length >= 3)
            {
                int column = int.Parse(data[0]);
                int row = int.Parse(data[1]);
                float time = float.Parse(data[2]);

                // �����͸� Unity���� ����� �� �ִ� ������� ó��
                // ���⿡�� �ʿ��� ������ �ۼ��ϸ� �˴ϴ�
                // ����: �����͸� �迭�̳� ����Ʈ�� �����Ͽ� Ȱ��
                // ����: �����͸� GameObject�� �Ӽ����� ����
            }
        }
    }*/
}
