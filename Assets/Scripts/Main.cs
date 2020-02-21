using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Main : MonoBehaviour {

	public GameObject cerca;
	public GameObject arbusto;
	public GameObject canos;
	public GameObject nuvem;
	public GameObject pedra;
	public GameObject player;

	public Text txtPontos;

	public GameObject particulas;

	public Button btnSair;

	bool comecou;
	bool acabou;

	int pontos;

	void Start(){
		txtPontos.text = "Toque para iniciar";

		btnSair.onClick.AddListener (sair);
	}

	void Update () {
		if (!acabou) {
			if(Input.anyKeyDown){
				if (!comecou) {
					comecou = true;
					InvokeRepeating("CriaCerca", 1, 0.4F);
					InvokeRepeating("CriaObjeto", 1, 0.77F);
					player.GetComponent<Rigidbody> ().useGravity = true;
					player.GetComponent<Rigidbody> ().isKinematic = false;
					txtPontos.text = "Pontos: " + pontos;
				}
				voaPlayer ();
			}
			player.transform.rotation = Quaternion.Euler (player.GetComponent<Rigidbody> ().velocity.y * -3, 0, 0);
		}
	}
	void CriaCerca () {
		Instantiate (cerca);
	}

	void CriaObjeto()
	{
		if (!acabou) { 

			var sorteiaObjeto = Random.Range (1, 5); 

			float posicaoZRandom = Random.Range (-3.5f, 2.0f);
			float posicaoYRandom = Random.Range (4f, 7f); 
			float rotacaoYRandom = Random.Range (-0.0f, 360.0f); 

			GameObject novoObjeto = new GameObject ();

			switch (sorteiaObjeto) { 
			case 1:
				novoObjeto = (GameObject)Instantiate (pedra);
				posicaoYRandom = 0; 
				break;

			case 2:
				novoObjeto = (GameObject)Instantiate (arbusto);
				posicaoYRandom = 0; 
				break;

			case 3:
				novoObjeto = (GameObject)Instantiate (nuvem);  
				break;
			case 4:
				CriaCanos ();  
				break;
			default:
				break;
			}

			novoObjeto.transform.position = new Vector3 (novoObjeto.transform.position.x, novoObjeto.transform.position.y + posicaoYRandom, novoObjeto.transform.position.z + posicaoZRandom);
			novoObjeto.transform.rotation = Quaternion.Euler (novoObjeto.transform.rotation.x, rotacaoYRandom, novoObjeto.transform.rotation.z);
			//novoObjeto.transform.rotation = Quaternion.Euler (0, 0, 0);
		}
	}

	void CriaCanos()
	{
		if(!acabou){
			GameObject novoObjeto = (GameObject) Instantiate(canos);
			float posicaoYRandom = Random.Range(1.8f,4.0f);
			novoObjeto.transform.position = new Vector3(novoObjeto.transform.position.x,posicaoYRandom,novoObjeto.transform.position.z);
		}
	}

	void voaPlayer(){
		GameObject novaParticula = Instantiate (particulas);
		novaParticula.transform.position = player.transform.position;
		player.SendMessage ("SomVoa");
		player.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		player.GetComponent<Rigidbody> ().velocity = new Vector3 (0.0f, 5.0f, 0.0f);
	}

	void GameOver(){
		if (!acabou) {
			acabou = true;
			player.GetComponent<AudioSource> ().SendMessage ("SomBate");
			player.GetComponent<Rigidbody> ().useGravity = false;
			player.GetComponent<Rigidbody> ().velocity = new Vector3 (0.0f, 0.0f, -10.0f);
			Invoke ("RecarregaCena", 1.0f);
		}
	}

	void RecarregaCena(){
		Application.LoadLevel ("Game");
	}

	void maisPontos(){
		pontos++;
		txtPontos.text = "Pontos: " + pontos;
	}

	void sair(){
		Application.Quit ();
	}
}
