using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
[Serializable]
public class playerData{
public float tempoTotal,ultimoLogin;
public bool muteMusic,muteSFX;

public string salvaDados(){
		BinaryFormatter bf = new BinaryFormatter();
        MemoryStream str = new MemoryStream();
        bf.Serialize(str, this);
        string dadosT = Convert.ToBase64String(str.ToArray());	
		return dadosT;
}

public static playerData restauraDados(string S){	
	byte[] bytes = Convert.FromBase64String(S);
                MemoryStream str = new MemoryStream(bytes);
                BinaryFormatter bf = new BinaryFormatter();
                playerData dadosTemp = bf.Deserialize(str) as playerData;
                return dadosTemp;
}

public playerData(){
   
}



}
