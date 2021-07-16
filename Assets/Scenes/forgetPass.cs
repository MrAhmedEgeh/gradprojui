using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class forgetPass : MonoBehaviour
{
    // Start is called before the first frame update
    public Button goBackToLogin;
    public Button submit;
    public InputField email;
    public Text notifications;
    void Start()
    {
        goBackToLogin.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("LoginScene");
        });
        submit.onClick.AddListener(() =>
        {
            if (string.IsNullOrEmpty(email.text))
            {
                notifications.text = "Please enter all fields";
            }
            else
            {
                StartCoroutine(reseter(email.text));
            }
        });
    }
    IEnumerator reseter(string emails)
    {
        WWWForm form = new WWWForm();
        form.AddField("email", emails);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/gradProjectBackend/Login/ResetPass.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {

                if (www.downloadHandler.text.Equals("Email was not found"))
                {
                    notifications.text = www.downloadHandler.text;
                    Debug.Log(notifications.text);
                }
                else
                {
                    notifications.text = "Check your email";
                    SceneManager.LoadScene("LoginScene");
                }

            }
        }
    }

}
