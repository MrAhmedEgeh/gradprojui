using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using EasyUI.Toast;


using System.IO;

using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Specialized;
using System.Text;
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
               // StartCoroutine(reseter(email.text));
                reseter(email.text);
            }
        });
    }
   /* IEnumerator reseter(string emails)
    {
        WWWForm form = new WWWForm();
        form.AddField("email", emails);


        using (UnityWebRequest www = UnityWebRequest.Post("https://gradproject.site/cgi-bin/ResetPass.php", form))
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
    }*/

    void reseter(string emails)
    {
        ServicePointManager.ServerCertificateValidationCallback = TrustCertificate;

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://gradproject.site/cgi-bin/ResetPass.php");
        request.ContentType = "application/x-www-form-urlencoded";
        request.Method = "POST";
        Stream dataStream = request.GetRequestStream();
        NameValueCollection nvc = new NameValueCollection();
        nvc.Add("email", emails);

        System.Text.StringBuilder postVars = new StringBuilder();
        foreach (string key in nvc)
            postVars.AppendFormat("{0}={1}&", key, nvc[key]);
        postVars.Length -= 1; // clip off the remaining &

        //This

        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            streamWriter.Write(postVars.ToString());
        Debug.Log(postVars.ToString());

        WebResponse response = request.GetResponse();
        dataStream = response.GetResponseStream();
        // Open the stream using a StreamReader for easy access.
        StreamReader reader = new StreamReader(dataStream);
        // Read the content.
        string responseFromServer = reader.ReadToEnd();
        if (responseFromServer.Equals("Email was not found"))
        {
            Toast.Show(responseFromServer, 2f, ToastColor.Red);
        }
        else
        {
            Toast.Show("Check your email", 2f, ToastColor.Red);
            SceneManager.LoadScene("LoginScene");
        }

    }

    private static bool TrustCertificate(object sender, X509Certificate x509Certificate, X509Chain x509Chain, SslPolicyErrors sslPolicyErrors)
    {
        // all Certificates are accepted
        return true;
    }

}
