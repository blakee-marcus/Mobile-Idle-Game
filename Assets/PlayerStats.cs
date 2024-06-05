using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
  public float currentMoney;
  public float ticketPrice;
  public float ticketStandTimeToServe;
  public float baseFoodPrice;
  public float foodStandTimeToServe;

  public void Start()
  {
    currentMoney = 0;
    ticketPrice = 6;
    ticketStandTimeToServe = 6;
    baseFoodPrice = 5;
    foodStandTimeToServe = 10;
  }

}
