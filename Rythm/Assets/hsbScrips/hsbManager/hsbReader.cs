using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class hsbReader : MonoBehaviour
{
    public GameObject LeftNote; // ������ ������
    public GameObject RightNote;

    public float offsetX = 3.5f; // X �� ��ġ ������
    public float offsetY = 3.5f; // Y �� ��ġ ������
    public string filePath = "Assets/Sheet/RealSheets.txt"; // �ؽ�Ʈ ������ ���

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
            string[] data = lines[i].Split('|'); // '|'�� �������� ������ �и�

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

    // �����͵��� ������ �����ϴ� �Լ�
    IEnumerator CreatePrefabsFromData(int[,] array, int[] timeArray)
    {
        double startTime = AudioSettings.dspTime; // ���� �ð� ���

        for (int i = 0; i < array.GetLength(0); i++)
        {
            int column = array[i, 0];
            int time = timeArray[i];

            double elapsedTime = AudioSettings.dspTime - startTime; // ��� �ð� ���

            while (elapsedTime < time / 1000.0)
            {
                elapsedTime = AudioSettings.dspTime - startTime; // ��� �ð� ������Ʈ
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

    // x ��ǥ �� ��ȯ
    float GetXPosition(int col)
    {
        if (col == 0) // �����̸� -3.5 ��ȯ
            return -3.5f;
        else if (col == 1)
            return 0f;
        else // �����̸� 1.5 ��ȯ
            return 1.5f;
    }

    // y ��ǥ �� ��ȯ
    float GetYPosition(int col)
    {
        if (col == 0) // �����̸� 
            return -3.6f;
        else if (col == 1)
            return 0f;
        else // �����̸�
            return 0.3f;
    }
}

