using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.UI;
using Unity.VisualScripting;
using TMPro;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity = 1f;
    [SerializeField] private float aimSensitivity = 1f;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private GameObject Crosshair;
    [SerializeField] private GameObject SyringeGun;
    [SerializeField] private GameObject InventoryUI;
    [SerializeField] private GameObject ShopUI;
    [SerializeField] private GameObject MinimapUI;
    [SerializeField] private Transform pfBulletProjectile;
    [SerializeField] private Transform spawnBulletPosition;
    Vector3 mouseWorldPosition = Vector3.zero;

    public InventoryObject inventory;
    public HealthBarUI healthBarUI;
    public GameObject instruction;

    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;

    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
    }

    void Update()
    {
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2);

        //shoot a ray to the center of the screen to get mouse position
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            //get mouse position from raycast
            //debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }

        if (starterAssetsInputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            Crosshair.gameObject.SetActive(true);
            SyringeGun.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);

            //store aim direction from the player
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            Crosshair.gameObject.SetActive(false);
            SyringeGun.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);
        }

        if (starterAssetsInputs.shoot)
        {
            Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
            // rotation = pfBulletProjectile.transform.eulerAngles.normalized;

            Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
            starterAssetsInputs.shoot = false;
        }

        if (starterAssetsInputs.bInventory)
        {
            InventoryUI.SetActive(true);
            ShopUI.SetActive(true);
        }
        else
        {
            InventoryUI.SetActive(false);
            ShopUI.SetActive(false);
        }

        if (inventory.itemMapCheck())
        {
            MinimapUI.SetActive(true);
        }
        else
        {
            MinimapUI.SetActive(false); 
        }

        if (inventory.itemVaccine())
        {
            healthBarUI.addHealth(2 * Time.deltaTime);
        }

        if (inventory.itemVRGoggleCheck())
        {
            instruction.SetActive(true);
            instruction.GetComponentInChildren<TMP_Text>().SetText("Congratulations. You have completed the game!");
        }
    }

    private void OnApplicationQuit()
    {
        inventory.InventoryList.Clear();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("ToxicAir") && !inventory.itemMaskCheck())
        {
            healthBarUI.minusHealth(1 * Time.deltaTime);
        }
    }
}
