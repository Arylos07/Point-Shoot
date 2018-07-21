//Author: Michael Cox 2016
//------------------------------
using UnityEngine;
using System.Collections;
//------------------------------
public class ScoreOnDestroy : MonoBehaviour
{
	//------------------------------
	public int ScoreValue = 50;
    public int KillValue = 1;

	//------------------------------
	void OnDestroy()
	{
		GameController.Energy += ScoreValue;
        GameController.KillCount += KillValue;
	}
	//------------------------------
}
//------------------------------