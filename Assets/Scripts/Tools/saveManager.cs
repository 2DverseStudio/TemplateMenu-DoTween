using UnityEngine;
using System.Collections.Generic;
using System;
public class saveManager : MonoBehaviour {

public float versao;
public bool _restaurar;
public bool salvarTemp;
public playerData player;
public bool muteAudio;
public AudioSource musica;
/// <summary>
/// Awake is called when the script instance is being loaded.
/// </summary>
void Awake()
{
    
    iniciaRestore();
    
}
public void musicaToggle(bool toogle){
        muteAudio=!toogle;
        player.muteMusic=!toogle;
    if (!muteAudio && musica !=null) musica.Play();
    else if (musica!=null) musica.Stop();
}

public void iniciaRestore(){
if(_restaurar){
        float tver = PlayerPrefs.GetFloat("versao",0);
        if (tver>versao) {
            Debug.Log("versao do save mais nova q o apk");
        }
        if (versao>tver) {
            Debug.Log("atualizacao d save");
        }
        if (versao==tver){
            Debug.Log("mesma versao save");
        }
  
        int t = PlayerPrefs.GetInt("mute_audio",0);
        muteAudio=false;
        if (t>0)        muteAudio = true;

        musicaToggle(!muteAudio);
    
        string data=PlayerPrefs.GetString("player_data","");
        if (data=="") {
            player = new playerData();
            
        }
        else {
            player=playerData.restauraDados(data);
            //ver null
            /*if (player.todosAchievments==null) player.todosAchievments = achievs.inicia();
            else {
                if (player.todosAchievments.Count<17) Debug.Log("falta achiev");
            }*/
            //Debug.Log(player.todosAchievments.Count);

        }
    
    }else {
		player = new playerData();
        
	}
}

/// <summary>
/// Callback sent to all game objects when the player pauses.
/// </summary>
/// <param name="pauseStatus">The pause state of the application.</param>
void OnApplicationPause(bool pauseStatus)
{
        gravaLocal();
}

/// <summary>
/// Callback sent to all game objects before the application is quit.
/// </summary>
void OnApplicationQuit()
{
    gravaLocal();
}

public void gravaLocal(){
    //int t = PlayerPrefs.GetInt("mute_audio");
    float tver = PlayerPrefs.GetFloat("versao",0);
    
        Debug.Log("ver save: "+tver);
            if (tver<versao) {
                Debug.Log("atualiz ?");
            }
            
            PlayerPrefs.SetFloat("versao", versao);
            PlayerPrefs.SetInt("mute_audio", player.muteMusic ? 1 : 0);
            PlayerPrefs.SetString("player_data", player.salvaDados());
			PlayerPrefs.Save();
}

/// <summary>
/// Update is called every frame, if the MonoBehaviour is enabled.
/// </summary>
void Update()
{
	if (salvarTemp){
		salvarTemp=false;
        
		gravaLocal();
	}
}

static byte[] GetBytes(string str)
{
     byte[] bytes = new byte[str.Length * sizeof(char)];
     System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
     return bytes;
}

static string GetString(byte[] bytes)
{
     char[] chars = new char[bytes.Length / sizeof(char)];
     System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
     return new string(chars);
}



}