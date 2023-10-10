using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();
    public GameObject effectPrefab;
    public ParticleSystem effect;
    public ParticleSystem badeffect;

    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null;
    Vector2[] timingBoxs = null;
    AudioSource myAudio;

    void Start()
    {
        myAudio = GetComponent<AudioSource>();

        timingBoxs = new Vector2[timingRect.Length];

        for(int i=0;i<timingRect.Length;i++)
        {
            timingBoxs[i].Set(Center.localPosition.x - timingRect[i].rect.width / 2, Center.localPosition.x + timingRect[i].rect.width / 2);
        }
    }

    private void Update()
    {
       // effect.Play();
    }

    public void CheckTiming()
    {
        for(int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosX = boxNoteList[i].transform.localPosition.x;

            for(int x=0;x<timingBoxs.Length;x++)
            {
                if (timingBoxs[x].x <= t_notePosX && t_notePosX <= timingBoxs[x].y)
                {
                    //boxNoteList[i].GetComponent<Note>().HideNote();
                    switch (x)
                    {
                        case 0:
                            effect.Play();
                            myAudio.Play();
                            boxNoteList[i].GetComponent<Note>().anim.SetTrigger("NailGood");
                            break;
                        case 1:
                            badeffect.Play();
                            myAudio.Play();
                            GameManager.instance.hp -= 1;
                            boxNoteList[i].GetComponent<Note>().anim.SetTrigger("NailBad");
                            break;
                    }
                    boxNoteList[i].GetComponent<Note>().isHit = true;
                    boxNoteList.RemoveAt(i);
                    return;
                }
            }
        }
    }
}
