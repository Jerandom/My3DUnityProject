using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Instruction : MonoBehaviour
{
    public GameObject instructionPanel;
    public InventoryObject inventory;
    public Button continuebtn;

    // Start is called before the first frame update
    void Start()
    {
        instructionPanel.SetActive(true);

        continuebtn.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        instructionPanel.SetActive(false);
    }
}
