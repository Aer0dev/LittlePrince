using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Accuracy_Check : MonoBehaviour
{
    public float total_note;
    public float missed_note;
    private float accuracy;
    public TMP_Text Accuracy_Text;

    private void Start()
    {
        Accuracy_Text.color = Color.white;
        total_note = 584;
        missed_note = 0;
    }

    private void Update()
    {
        accuracy = ((total_note - missed_note) / total_note)*100;
        Accuracy_Text.text = accuracy.ToString("F1") + "%";
    }

    public void IncreaseMissedNote()
    {
        StartCoroutine(ChangeTextColor());
        missed_note += 1;
    }

    IEnumerator ChangeTextColor()
    {
        Accuracy_Text.color = Color.red;     // �ؽ�Ʈ ������ ���������� ����

        yield return new WaitForSeconds(0.1f); // 0.5�� ���

        Accuracy_Text.color = Color.white; // �ؽ�Ʈ ������ ������� ����
    }
}
