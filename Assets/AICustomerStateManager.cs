using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICustomerStateManager : MonoBehaviour
{
  [SerializeField] private Transform ticketBoothPositionTransform;
  [SerializeField] private Transform foodStandPositionTransform;
  [SerializeField] private Transform movieTheaterPositionTransform;
  [SerializeField] private Transform exitPositionTransform;
  private NavMeshAgent navMeshAgent;
  public enum CustomerState {
    purchaseTicket,
    purchaseFood,
    watchMovie,
    leaveTheater
  };
    
  private CustomerState currentCustomerState;
  public CustomerState CurrentCustomerState 
  { get { return currentCustomerState; } 
    set { SetCustomerState(value);}
  }
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
    currentCustomerState = CustomerState.purchaseTicket;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentCustomerState)
        {
            case CustomerState.purchaseTicket:
                navMeshAgent.SetDestination(ticketBoothPositionTransform.transform.position);
                
                break;
            case CustomerState.purchaseFood:
                navMeshAgent.SetDestination(foodStandPositionTransform.transform.position);
                break;
            case CustomerState.watchMovie:
                navMeshAgent.SetDestination(movieTheaterPositionTransform.transform.position);
                break;
            case CustomerState.leaveTheater:
                navMeshAgent.SetDestination(exitPositionTransform.transform.position);
                break;
        }
    }

    public void SetCustomerState(CustomerState newState)
    {
        Debug.Log("Customer state changed from " + currentCustomerState + " to " + newState);
        currentCustomerState = newState;
    }
}
