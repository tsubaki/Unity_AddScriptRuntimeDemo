using UnityEngine;
using System.Collections;
using System.Reflection;


public class LoadClock : MonoBehaviour {
	
	string state = string.Empty;
	
	void OnGUI()
	{
		GUILayout.Label(state);
		if( GUI.Button(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 40, 600, 80), "load clock") ){
			StartCoroutine(Load());
		}
	}
	
	IEnumerator Load()
	{
#if UNITY_EDITOR
		WWW www = new WWW("file://" + Application.streamingAssetsPath + "/Clock.unity3d");
#elif UNITY_WEBPLAYER
		WWW www = new WWW( "https://dl.dropboxusercontent.com/u/56297224/temp/Bundle/Clock.unity3d");
#endif
		yield return www;
		
		state = www.error;
		
		GameObject obj = GameObject.Instantiate( www.assetBundle.Load("ClockPrefab") ) as GameObject;
		
		TextAsset dll = www.assetBundle.Load("Clock", typeof(TextAsset)) as TextAsset;
		Assembly assembly = Assembly.Load (dll.bytes);
		System.Type type = assembly.GetType ("Clock");
		
		obj.AddComponent(type);
		
		enabled = false;
	}
}