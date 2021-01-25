using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TextureURL : MonoBehaviour
{
  public string url;
  public GameObject toEditate;
  public InputField inputTextURL;
  private string InitURL = "https://raw.githubusercontent.com/alexorozco2410/PruebaImagenes/master/";
//  public GameObject inrr;
    //public GameObject circulo;
  Renderer m_ObjectRenderer;
    // Start is called before the first frame update
    void Start()
    {
        m_ObjectRenderer = toEditate.GetComponent<Renderer>();
    }

    public void IniciarBusqueda(){
      url = inputTextURL.text;
      if (url == "") {
        Debug.Log("¡Error!\nIngresa la dirección URL");
      }else{
      //  Debug.Log(url);
        StartCoroutine(AplicarTextura());
      }
    }

    public IEnumerator AplicarTextura(){
      UnityWebRequest getImage = UnityWebRequestTexture.GetTexture(InitURL+url);
      yield return getImage.SendWebRequest();
      if (getImage.isNetworkError || getImage.isHttpError) {
        Debug.Log("Dirección Invalida");
      }else{
          m_ObjectRenderer.material.mainTexture = DownloadHandlerTexture.GetContent(getImage);
      }
    }

    public void RemoveTexture(){
      m_ObjectRenderer.material.mainTexture = null;
    }
}
