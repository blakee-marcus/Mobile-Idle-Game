using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICustomerStateManager : MonoBehaviour
{
  private NavMeshAgent navMeshAgent;

  public enum CustomerState
  {
    purchaseTicket,
    purchaseFood,
    watchMovie,
    leaveTheater,
    waitInQueue
  };

  private CustomerState currentCustomerState;
  public CustomerState CurrentCustomerState
  {
    get { return currentCustomerState; }
    set { SetCustomerState(value); }
  }

  private void Awake()
  {
    navMeshAgent = GetComponent<NavMeshAgent>();
  }

  void Start()
  {
    currentCustomerState = CustomerState.purchaseTicket;
  }

  void Update()
  {
    switch (currentCustomerState)
    {
      case CustomerState.purchaseTicket:
        navMeshAgent.SetDestination(GameAssets.i.ticketStand.transform.position);
        break;
      case CustomerState.purchaseFood:
        navMeshAgent.SetDestination(GameAssets.i.foodStand.transform.position);
        break;
      case CustomerState.watchMovie:
        navMeshAgent.SetDestination(GameAssets.i.movieTheater.transform.position);
        break;
      case CustomerState.leaveTheater:
        navMeshAgent.SetDestination(GameAssets.i.exit.transform.position);
        break;
    }
  }

  public void SetCustomerState(CustomerState newState)
  {
    Debug.Log("Customer state changed to: " + newState);
    currentCustomerState = newState;
  }
}
