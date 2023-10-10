using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager_KMJ : MonoBehaviour
{
    public int bpm = 0;
    public double makeWoodTime = 0d;
    public double currentTime = 0d;

    [SerializeField] Transform tfNoteAppear = null;
    [SerializeField] GameObject goNote = null;
    [SerializeField] Transform tfWoodAppear = null;
    [SerializeField] GameObject goWood = null;
    [SerializeField] Transform makeWoodAppear = null;
    [SerializeField] Transform makeNailAppear = null;

    TimingManager theTimingManager;

    private void Start()
    {
        theTimingManager = GetComponent<TimingManager>();
    }

    void Update()
    {
        //currentTime += Time.deltaTime;

        
        /*if(noteMaker(GameManager.instance.count))//currentTime>=60d/bpm)
        {
            //Debug.Log(GameManager.instance.count);
            GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity);
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
            currentTime -= 60d / bpm;
        }*/
    }

    private void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        if (noteMaker(GameManager.instance.count))//currentTime>=60d/bpm)
        {
            GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity);
            t_note.transform.SetParent(makeNailAppear);
            theTimingManager.boxNoteList.Add(t_note);
            //currentTime -= 60d / bpm;
        }

        if (currentTime > makeWoodTime||GameManager.instance.count==1)
        {
            GameObject t_wood = Instantiate(goWood, tfWoodAppear.position, Quaternion.identity);
            t_wood.transform.SetParent(makeWoodAppear);
            currentTime = 0d;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Note"))
        {
            theTimingManager.boxNoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            if (!collision.gameObject.GetComponent<Note>().isHit)
            {
                GameManager.instance.hp -= 1;
            }
        }
    }

    public bool noteMaker(int x)
    {
        bool isMake;
        x = x + 10;
        isMake = (x == 11)||(x==407)||(x==488)||(x==750)||(x==792)||
            (x==804)||(x==836)||(x==859)||(x==921)||(x==962)||
            (x==974)||(x==997)||(x==1018)||(x==1036)||(x==1090)||
            (x==1133)||(x==1145)||(x==1177)||(x==1200)||(x==1263)||
            (x==1306)||(x==1318)||(x==1340)||(x==1359)||(x==1378)||
            (x==1478)||(x==1519)||(x==1604)||(x==1650)||(x==1662)||
            (x==1685)||(x==1704)||(x==1721)||(x==1777)||(x==1822)||
            (x==1834)||(x==1864)||(x==1885)||(x==1950)||(x==1989)||
            (x==2002)||(x==2025)||(x==2044)||(x==2062)||(x==2185)||
            (x==2240)||(x==2358)||(x==2411)||(x==2521)||(x==2585)||
            (x==2762) || (x ==2804) || (x ==2865) || (x ==2885) || 
            (x ==2931) || (x ==2975) || (x ==3036) || (x ==3056) || 
            (x ==3101) || (x ==3145) || (x ==3207) || (x ==3226) || 
            (x ==3273) || (x ==3318) || (x ==3493) || (x ==3575) || 
            (x ==3661) || (x ==3742) || (x ==3829) || (x ==3917) ||
            (x ==4346)|| (x ==4390) || (x ==4401) ||
            (x ==4424) || (x ==4443) || (x ==4461) || (x ==4517) || 
            (x ==4561) || (x ==4572) || (x ==4604) || (x ==4625) || 
            (x ==4688) || (x ==4728) || (x ==4740) || (x ==4764) ||
            (x ==4780) || (x ==4802) || (x ==4996) || (x ==5033) ||
            (x ==5075) || (x ==5085) || (x ==5109) || (x ==5127) ||
            (x ==5143) || (x ==5202) || (x ==5244) || (x ==5255) || 
            (x ==5307) || (x ==5374) || (x ==5414) || (x ==5426) ||
            (x ==5449) || (x ==5468) || (x ==5486) || (x ==4907) || 
            (x ==4947) || (x ==4180) || (x ==4221) || (x ==4232) || 
            (x ==4265) || (x ==4288) || (x ==5289);
        return isMake;
    }
}
