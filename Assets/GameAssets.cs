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
  public Transform movieTheater;
  public Transform exit;
  public Transform customerSpawnPoint;
  public GameObject customerPrefab;
  public PlayerStats playerStats;
  public Canvas worldSpaceCanvas;
  public TMPro.TextMeshProUGUI currentCashText;


  public void Awake()
  {
    _i = this;
  }
}
