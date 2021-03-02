using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : BasePoint
{
    public override Vector3Int InComming(Vector3Int backPos, bool activPoint)
    {
        foreach (GameObject ch in ScriptManager.objectManager.AllCharacter)
        {
            if (ch.GetComponent<Player>())
                if (ch.transform.position == pos)
                {
                    StaticManager.levelManager.soundsManager.FinishSound.Play();
                    ScriptManager.objectManager.timer.activ=false;

                    StaticManager.levelManager.levelCompleteCanvas.GetComponent<PanelAnimation>().GoToTarget();
                    
                    StaticManager.levelManager.coinManager.ActivUI();
                    StaticManager.levelManager.coinManager.SaveActivStars();

                    for (int i = ScriptManager.objectManager.AllCharacter.Count - 1; i >= 0; i--)
                    {
                        if (!ScriptManager.objectManager.AllCharacter[i].GetComponent<Player>())
                        {
                            GameObject go = ScriptManager.objectManager.AllCharacter[i];
                            ScriptManager.objectManager.AllCharacter.Remove(go);
                            Destroy(go);
                        }
                    }
                    break;
                }

        }
        return NextPos(backPos);
    }
}
