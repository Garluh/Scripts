using UnityEngine;
using System.Collections;

public class GameEntityLevelTest : MonoBehaviour {

    public GameEntity entity;
	
	// Update is called once per frame
	void Update () {

        entity.EntityLevel.ModifyExp(10);
	
	}
}
