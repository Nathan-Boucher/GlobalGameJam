using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StateCat
{
    idle,
    walk,
    jump,
    grinch,
    sleep,
    idleGrinch,
    push,
    scared,
    breakdance,
    sulk,
    krokmou,
    fallmug
}
public class Cat : MonoBehaviour
{
    public static event Action teleEnd;
    public static event Action catsleep;

    [SerializeField] private AudioCat _audioCat;
    [SerializeField] private AudioSource _audioSource,_audioSource2;
    
    [SerializeField] private float speed;
    [SerializeField] private Animator _animator;
    [SerializeField] private Vector3 direction,startPosition;
    [SerializeField] private StateCat state;
    [SerializeField] private List<OnePlace> allPlaces;
    [SerializeField] private OnePlace ActualPlace;
    [SerializeField] private bool enableHit;
    

    void Start()
    {
        transform.position = startPosition;
        direction = transform.position;
    } 
    private bool check;
    [SerializeField] private float valueGrinchSong;
    [SerializeField] private int jumpfauteuil;
    void Update()
    {
        valueGrinchSong += Time.deltaTime;
        if (state == StateCat.grinch && valueGrinchSong > 3)
        {
            _audioCat.PlayAudio(_audioSource);
            valueGrinchSong = 0;
        }

        if (state == StateCat.jump && ActualPlace.name == "JumpOnFauteuil" && jumpfauteuil == 0)
        {
            _audioSource.clip = _audioCat.JumpOnArmChair;
            _audioCat.PlayAudio(_audioSource);
            jumpfauteuil = 1;
        }
        
        if (direction != transform.position && state != StateCat.jump && state != StateCat.idle && state != StateCat.idleGrinch)
        {
            transform.position = Vector3.MoveTowards(transform.position, direction, speed * Time.deltaTime);
        }
        else
        {
            CheckPosition();
        }
    }

    [SerializeField] private int hitValue;
    private void OnMouseDown()
    {
        if (enableHit)
        {
            hitValue++;
            if (hitValue == 10)
            {
                transform.position = ActualPlace.nextPosition;
                enableHit = false;
                Push();
            }
        }
    }

    public void Push()
    {
        state = StateCat.push;
        direction = transform.position;
        ActualizeAnimator();
        StartCoroutine(PushTIme());
    }

    IEnumerator PushTIme()
    {
        yield return new WaitForSeconds(0.5f);
        IdleGrinch();
    }
    
    public void IdleGrinch()
    {
        state = StateCat.idleGrinch;
        transform.position = ActualPlace.nextPosition;
        direction = transform.position;
        ActualizeAnimator();
    }
    public void Walk(Vector3 dir)
    {
        _audioSource.clip = _audioCat.walk;
        StartCoroutine(timesong(0.5f));
        direction = dir;
        state = StateCat.walk;
        ActualizeAnimator();
    }

    IEnumerator timesong(float time)
    {
        yield return new WaitForSeconds(time);
        _audioCat.PlayAudio(_audioSource);
    }

    public void Idle()
    {
        state = StateCat.idle;
        ActualizeAnimator();
    }
    private bool scaredstatut;
    public void Scared()
    {
        state = StateCat.scared;
        //transform.position = ActualPlace.nextPosition;
        direction = transform.position;
        ActualizeAnimator();
        if (!scaredstatut)
        {
            StartCoroutine(ScaredTime());
        }
    }

    IEnumerator ScaredTime()
    {
        yield return new WaitForSeconds(3f);
        state = StateCat.grinch;
        transform.position = ActualPlace.nextPosition;
        scaredstatut = false;
        Grinch();
        ActualizeAnimator();
    }

    public void BreakDance()
    {
        state = StateCat.breakdance;
        ActualizeAnimator();
        StartCoroutine(timeBreakdance());
    }

    public static event Action sulktime;
    IEnumerator timeBreakdance()
    {
        yield return new WaitForSeconds(4f);
        state = StateCat.sulk;
        sulktime.Invoke();
        ActualizeAnimator();
    }

    public void Krokmou()
    {
        state = StateCat.krokmou;
        ActualizeAnimator();
        transform.position = new Vector3(1, -2.5f, 0);
        direction = transform.position;
    }
    public void Jump(Vector3 value)
    {
        _audioSource.clip = _audioCat.jump;
        StartCoroutine(timesong(0));
        state = StateCat.jump;
        transform.position = value;
        ActualizeAnimator();
        StartCoroutine(jumpTime());
    }

    IEnumerator jumpTime()
    {
        yield return new WaitForSeconds(0.3f);
        transform.position = ActualPlace.nextPosition;
        direction = transform.position;
        Idle();

    }

    private bool grinchstatut;
    [SerializeField] private int a;
    void Grinch()
    {
        _audioSource.clip = _audioCat.grinch;
        a++;
        if (a == 2)
        {
            StartCoroutine(timeChaussonsStart());
        }
        if (!grinchstatut)
        {
            StartCoroutine(GrinchTime());
        }
    }

    IEnumerator timeChaussonsStart()
    {
        yield return new WaitForSeconds(3f);
        teleEnd.Invoke();
    }
    IEnumerator GrinchTime()
    {
        grinchstatut = true;
        yield return new WaitForSeconds(0.5f);
        state = StateCat.grinch;
        ActualizeAnimator();
        //grinchstatut = false;
    }
    private bool sleepstatut;
    void Sleep()
    {
        if (!sleepstatut)
        {
            StartCoroutine(SleepTime());
        }
    }
    IEnumerator SleepTime()
    {
        catsleep.Invoke();
        sleepstatut = true;
        _audioSource.clip = _audioCat.presleep;
        StartCoroutine(timesong(0.5f));
        yield return new WaitForSeconds(2f);
        _audioSource.clip = _audioCat.sleep;
        _audioSource.loop = true;
        _audioSource.Play();
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.6f, transform.position.z);
        direction = transform.position;
        ActualizeAnimator();
        sleepstatut = false;
    }
    void CheckPosition()
    {
        for (int i = 0; i < allPlaces.Count; i++)
        {
            if (transform.position == allPlaces[i].positionPlace.position)
            {
                ActualPlace = allPlaces[i];
                NewMovement();
            }
        }
    }

    private bool z;
    void NewMovement()
    {
        if (ActualPlace.nextMove == "Jump")
        {
            Jump(ActualPlace.nextPosition);
        }

        if (ActualPlace.nextMove == "Grinch" && !grinchstatut) 
        {
            Grinch();
        }
        if (ActualPlace.nextMove == "Sleep")
        {
            enableHit = true;
            state = StateCat.sleep;
            Sleep();
        }

        if (!z)
        {
            if (ActualPlace.nextMove == "IdleGringe")
            {
                IdleGrinch();
                z = true;
            }
        }
        
    }
    private void ActualizeAnimator()
    {
        switch (state)
        {
            case StateCat.idle :
                GetComponent<SpriteRenderer>().flipX = false;
                _animator.SetBool("idle",true);
                _animator.SetBool("walk",false);
                break;
            case StateCat.walk :
                if (transform.position.x < direction.x)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                _animator.SetBool("walk",true);
                _animator.SetBool("idle",false);
                _animator.SetBool("grinch",false);
                _animator.SetBool("sleep",false);
                _animator.SetBool("jump",false);
                _animator.SetBool("fallmug" , false);
                break;
            case StateCat.jump :
                GetComponent<SpriteRenderer>().flipX = true;
                GetComponent<SpriteRenderer>().sortingOrder = 20;
                _animator.SetBool("jump" , true);
                _animator.SetBool("walk" , false);
                break;
            case StateCat.grinch :
                transform.rotation = Quaternion.Euler(0,0,0);
                _animator.SetBool("grinch" , true);
                _animator.SetBool("idle" , false);
                _animator.SetBool("scared" , false);
                break;
            case StateCat.sleep :
                _animator.SetBool("sleep" , true);
                _animator.SetBool("idle" , false);
                _animator.SetBool("jump",false);
                _animator.SetBool("grinch",false);
                break;
            case StateCat.push :
                _audioSource.clip = _audioCat.cassegueule;
                _audioSource.loop = false;
                _audioSource.Play();
                GetComponent<SpriteRenderer>().sortingOrder = 9;
                GetComponent<SpriteRenderer>().flipX = true;
                _animator.SetBool("push" , true);
                _animator.SetBool("idle" , false);
                _animator.SetBool("grinch",false);
                _animator.SetBool("jump" , false);
                _animator.SetBool("walk" , false);
                _animator.SetBool("sleep" , false);
                break;
            case StateCat.idleGrinch :
                _audioSource.clip = _audioCat.enervax;
                StartCoroutine(timesong(0.5f));
                GetComponent<SpriteRenderer>().sortingOrder = 7;
                GetComponent<SpriteRenderer>().flipX = false;
                _animator.SetBool("push" , false);
                _animator.SetBool("idle" , false);
                _animator.SetBool("grinch",false);
                _animator.SetBool("jump" , false);
                _animator.SetBool("walk" , false);
                _animator.SetBool("sleep" , false);
                _animator.SetBool("idleGrinch" , true);
                break;
            case StateCat.scared :
                GetComponent<SpriteRenderer>().sortingOrder = 7;
                GetComponent<SpriteRenderer>().flipX = true;
                transform.Rotate(0 , 0 , -9.7f , Space.Self);
                _animator.SetBool("idleGrinch" , false);
                _animator.SetBool("scared" , true);
                break;
            case StateCat.breakdance :
                GetComponent<SpriteRenderer>().sortingOrder = 7;
                GetComponent<SpriteRenderer>().flipX = false;
                _animator.SetBool("idleGrinch" , false);
                _animator.SetBool("breakdance" , true);
                break;
            case StateCat.sulk :
                _animator.SetBool("sulk" , true);
                _animator.SetBool("breakdance" , false);
                break;
            case StateCat.krokmou :
                _animator.SetBool("sulk" , false);
                _animator.SetBool("krokmou" , true);
                break;
            case StateCat.fallmug :
                _audioSource2.clip = _audioCat.fallmug;
                _audioSource.loop = false;
                _audioSource2.Play();
                _animator.SetBool("fallmug" , true);
                _animator.SetBool("grinch" , false);
                break;
        }
    }

    public void fallingMug()
    {
        state = StateCat.fallmug;
        ActualizeAnimator();
        StartCoroutine(timemug());
    }

    IEnumerator timemug()
    {
        yield return new WaitForSeconds(0.2f);
        GameObject.Find("MugObject(Clone)").transform.position = new Vector3(0.19f , -3.21f , 0);
        GameObject.Find("MugObject(Clone)").transform.rotation = Quaternion.Euler(0, 0, -81.25f);
        yield return new WaitForSeconds(2f);
        Destroy(GameObject.Find("MugObject(Clone)"));
    }
}
