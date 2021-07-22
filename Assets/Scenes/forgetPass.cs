using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using EasyUI.Toast;
public class forgetPass : MonoBehaviour
{
    // Start is called before the first frame update
    public Button goBackToLogin;
    public Button submit;
    public InputField email;

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
                Toast.Show("Please enter all fields", 2f, ToastColor.Red);
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
                    Debug.Log(www.downloadHandler.text);
                    Toast.Show(www.downloadHandler.text, 2f, ToastColor.Red);
                }
                else
                {
                    Toast.Show("Check your email", 2f, ToastColor.Red);
                    SceneManager.LoadScene("LoginScene");
                }

            }
        }
    }

}
