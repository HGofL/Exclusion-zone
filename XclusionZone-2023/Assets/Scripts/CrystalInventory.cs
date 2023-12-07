using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrystalInventory : MonoBehaviour
{
    private int Crystal = 0;

    public TextMeshProUGUI crystalText;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Crystal")
        {
            Crystal++;
            crystalText.text = "Crystals: " + Crystal.ToString();
            Debug.Log(Crystal);
            Destroy(other.gameObject);
        }
    }
}
