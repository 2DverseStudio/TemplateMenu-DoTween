using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
/*using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.GameCenter;*/
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class Singleton: MonoBehaviour {

	#region Singleton
	private static Singleton _instance = null;
	public saveManager savePlayer;
	public static Singleton Instance {
		get {
			return _instance;
		}
	}

	void Awake() {
		if (_instance == null) {
			_instance = this;
			DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
			DontDestroyOnLoad(gameObject);
			if (savePlayer==null){
			savePlayer = gameObject.AddComponent<saveManager>();
			savePlayer._restaurar=true;
			savePlayer.iniciaRestore();
			}
		} else {

			DestroyImmediate(gameObject);
		}
	}

	private void OnDestroy() {
		if (_instance == this) {
			_instance = null;
			
		}
	}
	#endregion

	

	private AsyncOperation async = null;
	public GameObject loadPrefab;
	public String SceneDestName = "gamePlay";
	
	

	void Start() {
		
	}
	
	void Update() {
	
	}

	public void loadScene(string scenename){
		SceneDestName=scenename;
		sceneAsync();
	}

	public void sceneAsync() {
		async = SceneManager.LoadSceneAsync(SceneDestName);
		async.allowSceneActivation = false;
		StartCoroutine(LoadSceneCoroutine());
	}

	void OnApplicationQuit() {
		if (_instance == this) {
		
		}
	}


	void OnApplicationPause(bool pauseStatus) {
		if (_instance == this) {
			
		}
	}


	IEnumerator LoadSceneCoroutine() {
		while (!async.isDone) {
			if (async.progress < 0.90f) {
				
			} else {
				
				if (!async.allowSceneActivation) {
				
				}
				async.allowSceneActivation = true;
			}

			yield
			return null;
		}
		yield
		break;

	}

	public IEnumerator Flash(float countFloat) {
		while (countFloat > 0f) {
			countFloat -= Time.deltaTime;
			//Debug.Log(" count: " + countF);
			yield
			return new WaitForEndOfFrame();

		}
		yield
		break;
	}

	public string converteK(int Value) {
		if (Value >= 1000000000) {
			return (Value / 1000000000D).ToString("0.##B");
		}

		if (Value >= 100000000) {
			return (Value / 1000000D).ToString("0.#M");
		}
		if (Value >= 1000000) {
			return (Value / 1000000D).ToString("0.##M");
		}
		if (Value >= 100000) {
			return (Value / 1000D).ToString("0.#K");
		}
		if (Value >= 1000) {
			return (Value / 1000D).ToString("0.##K");
		}

		return Value.ToString("#,0");
	}

    }



