using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class managerMenu : MonoBehaviour {
	
	public Singleton s;
	public CanvasGroup canvasMenu;
	public float tempoFadeMenu;
	public AudioSource soundFx;
	public AudioClip sfxClick;
	public Toggle toggleSFX;
	public Toggle toggleMusic;
	public CanvasGroup debug;
	// Use this for initialization
	void Awake () {
		canvasMenu.alpha=0;
	if (!Singleton.Instance) s=gameObject.AddComponent<Singleton>();
        else s = Singleton.Instance;
	}

	void Start()
	{
		enableMenu();
	}	

	public void setMusic(bool toggle){
		s.savePlayer.musicaToggle(toggle);
	}

	public void setSFX(bool toggle){
			soundFx.mute=!toggle;
//			if (toggle) clickSFX();
			s.savePlayer.player.muteSFX=!toggle;
	}

	public void clickSFX(){
		soundFx.clip = sfxClick;
		soundFx.Play();
		

	}

	public void enableMenu(){
		if (debug!=null) {
			debug.DOFade(0,tempoFadeMenu);
		}
		canvasMenu.DOFade(1,tempoFadeMenu).OnComplete(() => {
			canvasMenu.interactable=true;
			setSFX(!s.savePlayer.player.muteSFX);
			toggleSFX.isOn=!s.savePlayer.player.muteSFX;
			toggleMusic.isOn=!s.savePlayer.player.muteMusic;
		}	
		);
	}

	public void disableMenu(){

		if (debug!=null) {
			debug.DOFade(1,tempoFadeMenu);
		}

		canvasMenu.interactable=false;
		canvasMenu.DOFade(0,tempoFadeMenu).OnComplete(() => {
			canvasMenu.interactable=false;
		}	
		);
	}
	
	// Update is called once per frame
	void Update () {

		//debug para habiliar o menu
		if (Input.GetKey("m")) 
				enableMenu();
	}

	
	public void loadSceneIntro(){
		s.loadScene("introScene");
	}
	public void loadSceneGP(){
		s.loadScene("gpScene");
	}
}
        