using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using System;
using TMPro;

public class clock : MonoBehaviour {
  private TextMeshPro textClock;

  void Start (){
    GetComponent<TMPro.TextMeshProUGUI>().text ="00:00";
  }

  void Update (){
    DateTime time = DateTime.Now;
    string hour = LeadingZero( time.Hour );
    string minute = LeadingZero( time.Minute );

    GetComponent<TMPro.TextMeshProUGUI>().text =hour + ":" + minute;
  }

  string LeadingZero (int n){
    return n.ToString().PadLeft(2, '0');
  }
}
