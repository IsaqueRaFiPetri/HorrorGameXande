using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public enum MonsterAI
{
    Break, Patrolling, Chasing
}
[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public UnityEvent OnPatrolling, OnChasing, OnBreak;
    public Transform vision, playerPos;
    RaycastHit hit;
    public Transform[] patrolPoints; //array - não muda dentro do jogo
    NavMeshAgent agent;
    MonsterAI monsterAI;
    public bool canPatrol;

    int lastPoint; //Patrulha aleatória, impede repetir o ponto
    int patrolPoint; //Ponte de patrulha atual, para o de sequencia

    void Start()
    {
        /*OnBreak.AddListener(delegate
        {
            (StartCoroutine(GiveaBreak()));
        }); //coroutine para esperar*/

        agent = GetComponent<NavMeshAgent>();
        //SetDestiny();
        //SetRandomFixedPointDestiny();
        NextPointFixerdPatrol();
    }
    void Update()
    {
        //agent.SetDestination(PlayerInteraction.instance.transform.position);
        switch (monsterAI)
        {
            case MonsterAI.Break: //modod de aguardo
                break;
            case MonsterAI.Patrolling:
                if (agent.stoppingDistance >= agent.remainingDistance)
                { //se estiver chegando ao destino, espere
                    SetMonsterAI(MonsterAI.Break);
                }
                break;
            case MonsterAI.Chasing:
                break;
        }
        //Linha de colisão para verificar se ta vendo o player
        if (Physics.Linecast(vision.position, playerPos.position, out hit))
        {
            if (hit.distance >= 10) //se o player estiver longe, nem executa
                return;
            //print(hit.distance, ToString(playerPos"N0"));
            if (hit.collider.CompareTag("Player")) //caso veja o player
            {
                if (monsterAI.Equals(MonsterAI.Chasing)) //se bão for o modo CHASING
                {
                    SetMonsterAI(MonsterAI.Chasing); //Mude para Chasing
                    StopAllCoroutines(); //Para a Coroutine do modo de espera
                }
                agent.SetDestination(playerPos.position);
                //Fica atualizañdo o destino dele para a posição do player
            }
            else
            { //se perder o player de vista
                if (monsterAI.Equals(MonsterAI.Chasing))
                    SetMonsterAI(MonsterAI.Break); //caso ainda esteja caçando , cancela
            }

            print(hit.collider.name);
        }
    }
    IEnumerator GiveaBreak()
    {
        yield return new WaitForSeconds(2); //tempo de espera
        if (canPatrol)
        {
            NextPointFixerdPatrol();
        }
        else
        {
            NextPointFixerdPatrol(); //setar um novo destino e começar a patrulha
        }
    }

    void SetDestiny() //anda para um ponto aleatório
    {
        agent.SetDestination(SetRandomNavTarget());
        SetMonsterAI(MonsterAI.Patrolling);
    }
    void SetRandomFixedPointDestiny() //aleatopriza um dos pontos de patrulha
    {
        int random = Random.Range(0, patrolPoints.Length);
        while (random == lastPoint)
        {
            random = Random.Range(0, patrolPoints.Length);
        }
        lastPoint = random;
        print(random);
        agent.SetDestination(patrolPoints[Random.Range(0, patrolPoints.Length)].position);
        SetMonsterAI(MonsterAI.Patrolling);
    }
    void NextPointFixerdPatrol()
    {
        agent.SetDestination(patrolPoints[patrolPoint].position);
        SetMonsterAI(MonsterAI.Patrolling);
        patrolPoint++;
        if (patrolPoint >= patrolPoints.Length)
        {
            patrolPoint = 0;
        }
    }

    Vector3 SetRandomNavTarget()
    {
        Vector3 randomPosition = Random.insideUnitSphere * 30;
        randomPosition.y = 0;
        randomPosition += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomPosition, out hit, 5, 1);
        Vector3 finalPosition = hit.position;
        return finalPosition;
    }
    public void SetMonsterAI(MonsterAI state)
    {
        monsterAI = state;
        switch (monsterAI)
        {
            case MonsterAI.Break:
                StartCoroutine(GiveaBreak()); //coroutine para esperar
                OnBreak.Invoke();
                break;
            case MonsterAI.Patrolling:
                OnPatrolling.Invoke();
                break;
            case MonsterAI.Chasing:
                OnChasing.Invoke();
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        agent.SetDestination(other.transform.position);
        SetMonsterAI(MonsterAI.Patrolling);
    }
}