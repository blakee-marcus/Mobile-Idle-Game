using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
  public float currentMoney;
  public float ticketPrice;
  public float foodPrice;
  public float ticketStandTimeToServe;
  public float foodStandTimeToServe;
  public float movieTheaterTimeToServe;
  public float timeBetweenCustomerSpawn;

  public void Start()
  {
    currentMoney = 0;
    ticketPrice = 6;
    ticketStandTimeToServe = 6;
    foodPrice = 5;
    foodStandTimeToServe = 10;
    movieTheaterTimeToServe = 10;
    timeBetweenCustomerSpawn = 10;
  }

  public void AddMoney(float amount)
  {
    currentMoney += amount;
    GameAssets.i.currentCashText.text = currentMoney.ToString("F2");
  }
}
