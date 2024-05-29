using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICustomerStateManager : MonoBehaviour
{
  [SerializeField] private Transform ticketBoothPositionTransform;
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
                Debug.Log("Customer is purchasing food");
                break;
            case CustomerState.watchMovie:
                Debug.Log("Customer is watching a movie");
                break;
            case CustomerState.leaveTheater:
                Debug.Log("Customer is leaving the theater");
                break;
        }
    }

    public void SetCustomerState(CustomerState newState)
    {
        currentCustomerState = newState;
    }
}
