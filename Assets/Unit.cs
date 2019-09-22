using System;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    [Header("Unit Info")]
    public string unitName;
    public Texture unitSprite;

    [Header("Unit params")]
    public float MaxHealth = 100f;
    private float curHealth;
    public float MoveSpeed = 1f;

    public float carryGoldMax = 10f;
    public float carryWoodMax = 10f;

    [SerializeField]
    private float carryGold = 0f;
    [SerializeField]
    private float carryWood = 0f;


    [Space]
    [SerializeField]
    private GameObject focus;
    private NavMeshAgent navAgent;
    private UnitResourceIcon resIcon;

    private void Start()
    {
        SetComponentsOnStart();
        curHealth = MaxHealth;
    }

    private void SetComponentsOnStart()
    {
        navAgent = GetComponent<NavMeshAgent>();
        resIcon = GetComponentInChildren<UnitResourceIcon>();
        navAgent.speed = MoveSpeed;
    }

    private void Update()
    {
        MovementAndFocus();
        DisplayResources();
    }

    private void DisplayResources()
    {
        resIcon.DisplayAmount(carryGold, carryWood);
    }

    private void MovementAndFocus()
    {
        if (focus != null)
        {
            navAgent.SetDestination(focus.transform.position);

            if (focus.activeSelf)
            {
                if (Vector3.Distance(transform.position, focus.transform.position) <= focus.GetComponent<Interactable>().radius)
                {
                    focus.GetComponent<Interactable>().Activate(this);
                    focus = null;
                }
            }
            else { navAgent.SetDestination(transform.position); focus = null; }
        }
    }

    public void MoveTo(Vector3 destination)
    {
        navAgent.SetDestination(destination);
    }

    public void SetFocus(GameObject target)
    {
        focus = target;
    }

    public float GetCurrentHealth()
    {
        return curHealth;
    }

}








/*private bool checkIfArrived()
{
    bool isArrived = false;
    float dis = navAgent.remainingDistance;

    Debug.Log(navAgent.pathStatus + "||" + navAgent.remainingDistance);

    /*
    if (dis != Mathf.Infinity && navAgent.pathStatus == NavMeshPathStatus.PathComplete && navAgent.remainingDistance == 0)
        isArrived = true;

    if (!navAgent.pathPending)
    {
        if (navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            if (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0f)
            {
                isArrived = true;
            }
        }
    }

    return isArrived;
}
*/

/*public void Interact(Vector3 destination, Interactable interactable)
{
    if (Vector3.Distance(transform.position, destination) > 2f)
    {           
        navAgent.SetDestination(destination);

        if (checkIfArrived()) interactable.Activate();
            else checkIfArrived();
    }
    else interactable.Activate();
}*/
