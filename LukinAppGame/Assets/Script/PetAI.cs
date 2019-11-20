using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PetAI : MonoBehaviour
{
    [SerializeField]
    private GameObject _pet = null;
    private Animator _petAni = null;
    private NavMeshAgent _petNav = null;
    [SerializeField]
    private enum _petState { idle, walk, eatting, touch, excited };
    private _petState nowPetState = _petState.idle;
    private bool _petIsWalk = false;
    // Start is called before the first frame update
    void Start()
    {
        nowPetState = _petState.idle;
        if (_pet == null)
            _pet = gameObject.transform.GetChild(0).gameObject;
        if (_petAni == null)
            _petAni = _pet.GetComponent<Animator>();
        if (_petNav == null)
            _petNav = _pet.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        AI();
    }
    public void AI()
    {

        //idle  發呆
        if (nowPetState == _petState.idle)
        {
            Vector3 randomPos = Random.insideUnitSphere * 5f;
            NavMeshHit navhit;
            NavMesh.SamplePosition(transform.position + randomPos, out navhit, 5f, NavMesh.AllAreas);

            _petNav.SetDestination(navhit.position);
            // _petNav.destination = navhit.position;
            _petIsWalk = true;
            nowPetState = _petState.walk;
        }
        //walk  走路
        if (nowPetState == _petState.walk)
        {
            if (_petNav.remainingDistance <= _petNav.stoppingDistance && !_petNav.pathPending && _petIsWalk)
            {
                StartCoroutine(ChangeToWalk(Random.Range(2.0f, 5.0f)));
            }
        }
        //eatting   餵食
        if (nowPetState == _petState.eatting)
        {

        }
        //touch     玩家點擊
        if (nowPetState == _petState.touch)
        {

        }
        //excited   躁動
        if (nowPetState == _petState.excited)
        {

        }
    }
    private IEnumerator ChangeToWalk(float num)
    {
        _petIsWalk = false;
        yield return new WaitForSeconds(num);
        nowPetState = _petState.idle;
    }
}
