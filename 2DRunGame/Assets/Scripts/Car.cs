using UnityEngine;

public class Car : MonoBehaviour
{
    //資料
    //品牌.CC數.重量.顏色.速度.是否有天窗
    //欄位 field:儲存資料
    //欄位語法
    //int.float.string.bool
    [Header("品牌"),Tooltip("汽車牌子")]
    public string brand="賓士";
    [Tooltip("汽車CC數")]
    public int cc=1500;
    [Header("重量"),Range(0,100)]
    public float weight=20.5f;
    [Header("是否有天窗"),Tooltip("打勾代表有")]
    public bool window=true;
    [Header("速度"),Range(0,100)]
    public float speed = 60.5f;

    public Color32 Coa = new Color32(32, 52, 152, 48);

    public GameObject cam;
    public Transform traCam;
    public Camera cam1;
}
