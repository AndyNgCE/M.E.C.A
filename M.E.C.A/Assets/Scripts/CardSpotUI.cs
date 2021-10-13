using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpotUI : MonoBehaviour
{
    private CardSpot target;

    public GameObject ui;

    public void SetTarget(CardSpot _target)
    {
        target = _target;

        transform.position = target.GetUsePosition();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
}
