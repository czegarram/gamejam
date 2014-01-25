using UnityEngine;
using System.Collections;

public class NetworkController : MonoBehaviour {
	
	public string IP = "";
	public int port = 25001;
	
	// Use this for initialization
	void OnGUI(){
		if(Network.peerType == NetworkPeerType.Disconnected){
			GUI.Label(new Rect(100, 100, 200,25), "Ingresa IP del server");
			IP = GUI.TextField(new Rect(400, 100, 200, 25), IP);
			if(GUI.Button(new Rect(100, 150, 200,25), "Conectar a server")){
				Network.Connect(IP, port);
			}
			if(GUI.Button(new Rect(100, 200, 200,25), "Crear Server")){
				Network.InitializeServer(2,port);
			}
		}
		else{
			if(Network.peerType == NetworkPeerType.Client){
				GUI.Label(new Rect(100, 100, 200,25), "Conectado a server");
				Application.LoadLevel("level01");
				if(GUI.Button(new Rect(100, 200, 200,25), "Desconectar")){
					Network.Disconnect(250);
				}
			}
			else if(Network.peerType == NetworkPeerType.Server){
				GUI.Label(new Rect(100, 100, 400,25), "Tu IP es "+Network.player.ipAddress);
				GUI.Label(new Rect(100, 150, 200,25), "Conexiones: "+Network.connections.Length);
				if(GUI.Button(new Rect(100, 200, 200,25), "Desconectar")){
					Network.Disconnect(250);
				}
				if(Network.connections.Length > 0){
					Application.LoadLevel("level01");
				}
			}
		}
	}
}
