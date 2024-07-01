using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements.Experimental;

public class ZombieAIUnityNavi : MonoBehaviour
{
    NavMeshAgent na;
    public Transform target;

    // �Ÿ� �Ӱ谪�� 10f�� �ش�
    public float distanceThreshold = 10f;

    public enum AIState { idle,chashing,attack };

    public AIState aiState = AIState.idle;

    public Animator animator;
    // �Ÿ� �Ӱ谪�� 1.5f�� �ش�
    public float attackThreshold = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
      na = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        na.SetDestination(target.position);
        StartCoroutine(think());
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    IEnumerator think()
    {
        while(true)
        {
            switch (aiState)
            {
                // �⺻ ����
                case AIState.idle:
                    float dist = Vector3.Distance(target.position, transform.position);
                    if(dist < distanceThreshold)
                    {
                        aiState = AIState.chashing;
                        animator.SetBool("Chasing", true);
                    }
                    na.SetDestination(transform.position);
                    break;
                // ���� ����
                case AIState.chashing:
                    dist = Vector3.Distance(target.position, transform.position);
                    if(dist > distanceThreshold)
                    {
                        aiState = AIState.idle;
                        animator.SetBool("Chasing", false);
                    }
                    if(dist< distanceThreshold)
                    {
                        // ���ݻ��¿� ����
                        aiState = AIState.attack;
                        animator.SetBool("Attacking", true);
                    }
                    na.SetDestination(target.position);
                    break;
                // ���� ����
                case AIState.attack:
                    Debug.Log("����!");
                    na.SetDestination(transform.position);
                    dist = Vector3.Distance(target.position, transform.position);
                    if( dist > attackThreshold)
                    {
                        aiState = AIState.chashing;
                        animator.SetBool("Attacking", false);
                    }
                    break;
                default:
                    break;


            }
         yield return new WaitForSeconds(0.5f); 
        }
    }
}
