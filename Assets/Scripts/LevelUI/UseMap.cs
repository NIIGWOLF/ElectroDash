using UnityEngine;
using UnityEngine.UI;

public class UseMap : MonoBehaviour
{
    bool isUsedMap = false;
    //public GameObject mapHint;
    public void useMap()
    {
        if (HintData.Instance.hint.mapHint > 0 && !isUsedMap)
        {
            ScriptManager.objectManager.moveSizeCamera.zoomOut();

            HintData.Instance.hint.mapHint--;
            HintData.Instance.SaveData();
            StaticManager.levelManager.countMapHint.GetComponent<Text>().text = HintData.Instance.hint.simpleHint.ToString();
            isUsedMap = true;
        }

    }
}
