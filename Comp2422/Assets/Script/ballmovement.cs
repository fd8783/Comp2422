using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballmovement : MonoBehaviour {

    public Vector3 mouselastpos, mousecurpos, changepos;
    public Button resetbutton;
    public Text modetext;
    public GameObject[] powerlight = new GameObject[5];
    public GameObject[] vibrationlight = new GameObject[3];
    public float zooming;
    public GameObject statelabel;
    public Sprite whitebut, greenbut;

    private Button onbut, offbut, vibratebut, vibonebut, vibtwobut, vibthreebut;
    private Vector3 startpos, startsca, curpos, cursca;
    private Quaternion startrot;
    private Animator anim;
    private AudioSource[] vibsound;
    private AudioSource vibonesound;
    private AudioSource vibtwosound;
    private AudioSource vibthreesound;

    private float zoommax = 2.5f, zoommin = 0.5f;
    public bool started = true;
    public int vibratelevel = 0;
    private bool reseting = false;
    private int countreset = 0;

    private vibrationbutdes vibrationbutscript;
    private powerlightdes powerlightscript;

    // Use this for initialization
    void Awake () {
        startpos = transform.position;
        startrot = transform.rotation;
        startsca = transform.localScale;
        //zoommax = startsca * 3f;
        //zoommin = startsca * 0.5f;
        Debug.Log(startsca);
        resetbutton.onClick.AddListener(Resetpos);
        reseting = true;
        anim = GetComponent<Animator>();
        vibsound = GetComponents<AudioSource>();
        vibonesound = vibsound[0];
        vibtwosound = vibsound[1];
        vibthreesound = vibsound[2];
        modetext.text = "Off";
        onbut = statelabel.transform.Find("ON").GetComponent<Button>();
        onbut.onClick.AddListener(OnClick);
        offbut = statelabel.transform.Find("OFF").GetComponent<Button>();
        offbut.onClick.AddListener(OffClick);
        vibratebut = statelabel.transform.Find("Vibration").GetComponent<Button>();
        vibratebut.onClick.AddListener(VibrateClick);
        vibonebut = statelabel.transform.Find("one").GetComponent<Button>();
        vibonebut.onClick.AddListener(ViboneClick);
        vibtwobut = statelabel.transform.Find("two").GetComponent<Button>();
        vibtwobut.onClick.AddListener(VibtwoClick);
        vibthreebut = statelabel.transform.Find("three").GetComponent<Button>();
        vibthreebut.onClick.AddListener(VibthreeClick);
    }
	
    void Start()
    {
        Statelabelcheck();
    }

	// Update is called once per frame
	void Update () {
        if (!reseting)
        {
            MouseCheck();
        }
        Reset();
        
	}

    void MouseCheck()
    {
        if (Input.GetMouseButtonDown(1))
        {
            mouselastpos = Input.mousePosition;
        }
        if (Input.GetMouseButton(1))
        {
            mousecurpos = Input.mousePosition;
            changepos = mousecurpos - mouselastpos;
            mouselastpos = mousecurpos;

            if (changepos.x != 0)
            {
                transform.Rotate(Vector3.up, -(changepos.x / 3), Space.World);
            }

            if (changepos.y != 0)
            {
                transform.Rotate(Vector3.right, (changepos.y / 3), Space.World);
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            zooming = Input.GetAxis("Mouse ScrollWheel")+1;
            Vector3 tempsca = transform.localScale;
            if (zooming > 1)
            {
                if (tempsca.x * zooming < zoommax)
                {
                    transform.localScale = transform.localScale * zooming;
                }
            }
            else
            {
                if (tempsca.x * zooming > zoommin)
                {
                    transform.localScale = transform.localScale * zooming;
                }
            }
        }
    }

    void Resetpos()
    {
        reseting = true;
        cursca = transform.localScale;
        OnClick();
        if (vibratelevel > 0)
        {
            VibrateClick();
        }
    }

    void Reset()
    {
        if (reseting)
        {
            if (countreset <= 30)
            {
                //transform.position = startpos;  seem useless now, don't change pos of ball
                transform.rotation = Quaternion.Lerp(transform.rotation, startrot, 0.2f);
                cursca.x = Mathf.Lerp(cursca.x, startsca.x, 0.15f);
                cursca.y = Mathf.Lerp(cursca.y, startsca.y, 0.15f);
                cursca.z = Mathf.Lerp(cursca.z, startsca.z, 0.15f);
                transform.localScale = cursca;
                countreset++;
            }
            else
            {
                reseting = false;
                countreset = 0;
            }

        }
    }

    void OnMouseOver()
    {
        Debug.Log("body");
    }

    public void levelchange()
    {
        if(vibratelevel == 3)
        {
            vibratelevel = 0;
        }
        else
        {
            vibratelevel += 1;
        }
        sendlevelchangemessage();
        anim.SetInteger("level", vibratelevel);
        modetext.text = ""+vibratelevel;
        Statelabelcheck();
    }

    public void turnonoff()
    {
        started = !started;
        vibratelevel = 0;
        sendlevelchangemessage();
        anim.SetInteger("level", vibratelevel);
        if (started)
        {
            modetext.text = "On";
        }
        else
        {
            modetext.text = "Off";
        }
        Statelabelcheck();
    }

    void sendlevelchangemessage()
    {
        for (int i = 0; i < 3; i++)
        {
            vibrationbutscript = vibrationlight[i].GetComponent(typeof(vibrationbutdes)) as vibrationbutdes;
            vibrationbutscript.levelupdate(vibratelevel);
        }
    }

    void Statelabelcheck()
    {
        if (started)
        {
            onbut.GetComponent<Image>().color = Color.green;
            offbut.GetComponent<Image>().color = Color.white;
            if(vibratelevel > 0)
            {
                vibratebut.GetComponent<Image>().color = Color.green;
                vibonebut.image.sprite = greenbut;
                if (vibratelevel > 1)
                {
                    vibtwobut.image.sprite = greenbut;
                    if (vibratelevel > 2)
                    {
                        vibthreebut.image.sprite = greenbut;
                    }
                    else
                    {
                        vibthreebut.image.sprite = whitebut;
                    }
                }
                else
                {
                    vibtwobut.image.sprite = whitebut;
                    vibthreebut.image.sprite = whitebut;
                }
            }
            else
            {
                vibratebut.GetComponent<Image>().color = Color.white;
                vibonebut.image.sprite = whitebut;
                vibtwobut.image.sprite = whitebut;
                vibthreebut.image.sprite = whitebut;
            }
        }
        else
        {
            offbut.GetComponent<Image>().color = Color.green;
            onbut.GetComponent<Image>().color = Color.white;
            vibratebut.GetComponent<Image>().color = Color.white;
            vibonebut.image.sprite = whitebut;
            vibtwobut.image.sprite = whitebut;
            vibthreebut.image.sprite = whitebut;
        }
        Vibsoundplay(vibratelevel);
        for (int i = 0; i < 5; i++)
        {
            powerlightscript = powerlight[i].GetComponent(typeof(powerlightdes)) as powerlightdes;
            powerlightscript.checkonoff(started);
        }
    }

    void OnClick()
    {
        started = true;
        Statelabelcheck();
    }

    void OffClick()
    {
        started = false;
        vibratelevel = 0;
        sendlevelchangemessage();
        anim.SetInteger("level", vibratelevel);
        Statelabelcheck();
    }

    void VibrateClick()
    {
        started = true;
        if (vibratelevel > 0)
        {
            vibratelevel = 0;
        }
        else
        {
            vibratelevel = 1;
        }
        sendlevelchangemessage();
        anim.SetInteger("level", vibratelevel);
        Statelabelcheck();
    }

    void ViboneClick()
    {
        started = true;
        vibratelevel = 1;
        sendlevelchangemessage();
        anim.SetInteger("level", vibratelevel);
        Statelabelcheck();
    }

    void VibtwoClick()
    {
        started = true;
        vibratelevel = 2;
        sendlevelchangemessage();
        anim.SetInteger("level", vibratelevel);
        Statelabelcheck();
    }

    void VibthreeClick()
    {
        started = true;
        vibratelevel = 3;
        sendlevelchangemessage();
        anim.SetInteger("level", vibratelevel);
        Statelabelcheck();
    }

    void Vibsoundplay(int num)
    {
        if (num > 0)
        {
            if (num == 1)
            {
                vibonesound.Play();
                vibtwosound.Stop();
                vibthreesound.Stop();
            }
            else
            {
                if (num == 2)
                {
                    vibonesound.Stop();
                    vibtwosound.Play();
                    vibthreesound.Stop();
                }
                else
                {
                    vibonesound.Stop();
                    vibtwosound.Stop();
                    vibthreesound.Play();
                }
            }
        }
        else
        {
            vibonesound.Stop();
            vibtwosound.Stop();
            vibthreesound.Stop();
        }
    }

}
