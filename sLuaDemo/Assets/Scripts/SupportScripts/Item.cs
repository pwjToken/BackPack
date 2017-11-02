using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Item : MonoBehaviour {


    //public int[][2] =new int[][2]([[1,97868],[1,69995],[1,28525],[1,72341],[1,86916],[1,5966],[2,58473],[2,93399],[1,84955],[1,16420],[1,96091],[1,45179],[1,59472],[1,49594],[1,67060],[1,25466],[1,50357],[1,83509],[1,39489],[2,51884],[1,34140],[1,8981],[1,50722],[1,65104],[1,61130],[1,92187],[2,2191],[1,2908],[1,63673],[2,92805],[1,29442]])
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponentInChildren<Text>().color = Color.white;
	}
}
