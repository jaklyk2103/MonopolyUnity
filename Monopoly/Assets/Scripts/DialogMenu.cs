using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogMenu : MonoBehaviour
{

    public GameObject dialogCanvasObject;
    private static DialogMenu dialogMenu;

    public Text oneHouseRent;
    public Text twoHouseRent;
    public Text threeHouseRent;
    public Text fourHouseRent;
    public Text housePrice;
    public Text hotelPrice;

    public static DialogMenu Instance()
    {
        if (!dialogMenu)
        {
           dialogMenu = FindObjectOfType(typeof(DialogMenu)) as DialogMenu;
            if (!dialogMenu)
                Debug.LogError("There is no dialog menu object in scene!");
        }

        return dialogMenu;
    }

    public void Show(int basicRent, int rentPerHouse)
    {
        dialogCanvasObject.SetActive(true);
        oneHouseRent.text += (basicRent + rentPerHouse).ToString();
    }
}
