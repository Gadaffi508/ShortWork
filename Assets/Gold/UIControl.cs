using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI skorText;

    TriggerObject triggerObject;

    private void Start()
    {
        triggerObject = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<TriggerObject>();

        skorText.text = "0";
        triggerObject.OnGoldTrigger += (x,y,z) => SkorUpdate(y);
    }

    private void SkorUpdate(int skor)
    {
        skorText.text = skor.ToString();
    }

}
