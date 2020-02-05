// using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PetAI : MonoBehaviour
{
    public GameObject _pet = null;
    public Animator _petAni = null;
    public NavMeshAgent _petNav = null;
    public float _petAniSpeed = 1f;
    public float _petMoveSpeed = 3f;

    public enum _petState { idle, walk, run, eatting, touch, excited };
    public _petState nowPetState = _petState.idle;
    public _petState nextPetState = _petState.idle;
    public bool _petIsWalk = false;
    public float minTimer = 3.0f;
    public float maxTimer = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        nowPetState = _petState.idle;
        if (_pet == null)
            _pet = this.gameObject;
        if (_petAni == null)
            _petAni = _pet.GetComponent<Animator>();
        if (_petNav == null)
            _petNav = _pet.GetComponent<NavMeshAgent>();
        AI();
    }

    public RaycastHit hit;
    // Update is called once per frame
    void Update()
    {
        // 點擊
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == _pet.name)
                {
                    touchPet();
                }
                else if (hit.transform.name == "Plane")
                {
                    touchPlane();
                }
            }
        }
        if (nowPetState != nextPetState)
        {
            nowPetState = nextPetState;
            AI();
        }

        if (_petNav.remainingDistance <= _petNav.stoppingDistance && !_petNav.pathPending && nowPetState != _petState.touch)
            nextPetState = _petState.idle;
    }

    private Coroutine nowIEnumerator = null;
    public void AI()
    {
        if (nowIEnumerator != null)
        {
            _petAni.SetBool("touch", false);
            StopCoroutine(nowIEnumerator);
        }
        // idle  發呆
        if (nowPetState == _petState.idle)
        {
            // Debug.Log("=========== IDLE =========");
            nowIEnumerator = StartCoroutine(IdleTime(Random.Range(minTimer, maxTimer)));
        }
        //walk  走路
        if (nowPetState == _petState.walk)
        {
            // Debug.Log("=========== WALK =========");
            nowIEnumerator = StartCoroutine(WalkTime());
        }
        //run   跑步
        if (nowPetState == _petState.run)
        {
            // Debug.Log("=========== RUN =========");
            nowIEnumerator = StartCoroutine(RunTime());
        }
        //touch     玩家點擊
        if (nowPetState == _petState.touch)
        {
            // Debug.Log("=========== TOUCH =========");
            nowIEnumerator = StartCoroutine(TouchTime(2f));
        }
        //eatting   餵食
        if (nowPetState == _petState.eatting)
        {

        }
        //excited   躁動
        if (nowPetState == _petState.excited)
        {

        }
    }

    // 移動動畫控制
    private void setAnimatorSpeed(string name, float speed)
    {
        if (name == "speed")
        {
            if (speed != 0)
                _petAni.speed = speed;
            else
                _petAni.speed = 1;
        }
        _petAni.SetFloat(name, speed);
    }


    // 玩家點擊寵物用
    public void touchPet()
    {
        nextPetState = _petState.touch;
    }
    // 玩家點擊地面用
    public void touchPlane()
    {
        nextPetState = _petState.run;
    }
    //==============================================
    //================= 寵物行為 =====================
    //==============================================
    private IEnumerator IdleTime(float time)
    {
        setAnimatorSpeed("speed", 0f);
        yield return new WaitForSeconds(time);
        nextPetState = _petState.walk;
    }
    private IEnumerator WalkTime()
    {
        setAnimatorSpeed("speed", _petAniSpeed / 2);
        _petNav.speed = _petMoveSpeed / 2;
        Vector3 randomPos = Random.insideUnitSphere * 5f;
        NavMeshHit navhit;
        NavMesh.SamplePosition(transform.position + randomPos, out navhit, 5f, NavMesh.AllAreas);
        // 設定位置移動
        _petNav.SetDestination(navhit.position);

        yield return new WaitForSeconds(minTimer);
        // nextPetState = _petState.idle;
    }
    private IEnumerator RunTime()
    {
        setAnimatorSpeed("speed", _petAniSpeed);
        _petNav.speed = _petMoveSpeed;
        // 設定位置移動
        _petNav.SetDestination(hit.point);

        yield return new WaitForSeconds(1f);
        // nextPetState = _petState.idle;
    }
    private IEnumerator TouchTime(float time)
    {
        // 停止移動
        setAnimatorSpeed("speed", 0f);
        _petAni.SetBool("touch", true);

        yield return new WaitForSeconds(time);
        _petAni.SetBool("touch", false);
        nextPetState = _petState.idle;
    }



}
