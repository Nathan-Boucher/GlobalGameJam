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
    scared
}
public class Cat : MonoBehaviour
{
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
    void Update()
    {
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
        direction = dir;
        state = StateCat.walk;
        ActualizeAnimator();
    }

    public void Idle()
    {
        state = StateCat.idle;
        ActualizeAnimator();
    }

    public void Scared()
    {
        state = StateCat.scared;
        transform.position = ActualPlace.nextPosition;
        direction = transform.position;
        ActualizeAnimator();
    }
    public void Jump(Vector3 value)
    {
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
    void Grinch()
    {
        if (!grinchstatut)
        {
            StartCoroutine(GrinchTime());
        }
    }
    IEnumerator GrinchTime()
    {
        grinchstatut = true;
        yield return new WaitForSeconds(0.5f);
        state = StateCat.grinch;
        ActualizeAnimator();
        grinchstatut = false;
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
        sleepstatut = true;
        yield return new WaitForSeconds(0.5f);
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
    void NewMovement()
    {
        if (ActualPlace.nextMove == "Jump")
        {
            Jump(ActualPlace.nextPosition);
        }

        if (ActualPlace.nextMove == "Grinch")
        {
            Grinch();
        }
        if (ActualPlace.nextMove == "Sleep")
        {
            enableHit = true;
            state = StateCat.sleep;
            Sleep();
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
                break;
            case StateCat.jump :
                GetComponent<SpriteRenderer>().flipX = true;
                GetComponent<SpriteRenderer>().sortingOrder = 20;
                _animator.SetBool("jump" , true);
                _animator.SetBool("walk" , false);
                break;
            case StateCat.grinch :
                _animator.SetBool("grinch" , true);
                _animator.SetBool("idle" , false);
                break;
            case StateCat.sleep :
                _animator.SetBool("sleep" , true);
                _animator.SetBool("idle" , false);
                _animator.SetBool("jump",false);
                _animator.SetBool("grinch",false);
                break;
            case StateCat.push :
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
            
        }
    }
}
