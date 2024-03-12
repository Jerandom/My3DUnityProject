using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public int PlayerCoins;
    public TMP_Text ShopCoins;
    public InventoryObject inventory;
    public ItemObject[] shopItems;
    public GameObject[] shopPanels;
    public Button[] btnPurchase;

    private void Awake()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            shopPanels[i].SetActive(true);
        }

        ShowPlayerCoins(PlayerCoins);
        LoadPanels();
        checkPurchaseable();
    }

    private void Update()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            shopPanels[i].SetActive(true);
        }

        ShowPlayerCoins(PlayerCoins);
        LoadPanels();
        checkPurchaseable();
        //purchaseItem();
    }

    public void LoadPanels()
    {
        Image[] oldImage = new Image[shopItems.Length];
        Image[] newImage = new Image[shopItems.Length];

        //populate the shop panel with data from scriptable object
        for (int i = 0; i < shopItems.Length; i++)
        {
            shopPanels[i].gameObject.GetComponent<ShopTemplate>().titleText.text = shopItems[i].type.ToString();
            oldImage[i] = shopItems[i].prefab.GetComponent<Image>();
            newImage[i] = shopPanels[i].gameObject.GetComponent<ShopTemplate>().itemImage.GetComponent<Image>();
            newImage[i].overrideSprite = oldImage[i].sprite;
            shopPanels[i].gameObject.GetComponent<ShopTemplate>().descriptionText.text = shopItems[i].description;
            shopPanels[i].gameObject.GetComponent<ShopTemplate>().priceText.text = shopItems[i].price.ToString();
        }
    }

    public void checkPurchaseable()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            //player do not have enough money
            if(PlayerCoins < shopItems[i].price)
            {
                btnPurchase[i].interactable = false;
            }
            else
            {
                btnPurchase[i].interactable = true;
            }
        }
    }

    public void purchaseItem(int btnNum)
    {
        if (PlayerCoins >= shopItems[btnNum].price)
        {
            PlayerCoins = PlayerCoins - shopItems[btnNum].price;
            ShopCoins.text = "Coins: " + PlayerCoins.ToString();
            checkPurchaseable();

            inventory.AddItem(shopItems[btnNum],1);
        }
    }

    public void ShowPlayerCoins(int playerCoins)
    {

        playerCoins = PlayerCoins;
        ShopCoins.text = "Coins: " + playerCoins.ToString();

    }

    public void addPlayerCoins(int addCoins)
    {
        PlayerCoins += addCoins;
    }
}
