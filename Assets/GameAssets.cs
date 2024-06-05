using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
  private static GameAssets _i;

  public static GameAssets i
  {
    get
    {
      if (_i == null) _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
      return _i;
    }
  }

  public Transform progressBarPopUp;
  public Transform ticketStand;
  public Transform foodStand;
  public PlayerStats playerStats;
  

  public void Awake()
  {
    _i = this;
  }
}
