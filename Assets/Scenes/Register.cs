using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using EasyUI.Toast;

using System.IO;

using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Specialized;
using System.Text;
public class Register : MonoBehaviour
{
    // Start is called before the first frame update
    public Button loginBtn;
    public Button registerBtn;
    public InputField username;
    public InputField email;
    public InputField pass1;
    public InputField pass2;
    public Text notifications;
    void Start()
    {
        loginBtn.onClick.AddListener(() =>
        {
            goToLogin();
        });
        registerBtn.onClick.AddListener(() =>
        {
            if(allFieldsNotEmpty(username.text, email.text, pass1.text, pass2.text))
            {
                if (varifyEmail(email.text))
                {
                    if(varifyPassword(pass1.text, pass2.text))
                    {
                        // StartCoroutine(RegisterUser(username.text, email.text, pass1.text));
                        RegisterUser2(username.text, email.text, pass1.text);
                    }
                    else
                    {
                        Toast.Show("Passwords must match and be 6 digits", 2f, ToastColor.Red);
                    }
                }
                else
                {
                    Toast.Show("Please enter a valid email", 2f, ToastColor.Red);
                }
            }
            else
            {
                Toast.Show("Please enter all fields", 2f, ToastColor.Red);
            }
        });
    }
    public bool allFieldsNotEmpty(string username, string email, string password1, string password2)
    {
        return string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password1) ||
            string.IsNullOrEmpty(password2) ?  false : true;
    }
    public bool varifyEmail(string email)
    {
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(email);
        return match.Success ? true : false;
    }

    public bool varifyPassword(string pass1, string pass2)
    {
        return pass1.Length >= 6 && pass2.Length >= 6 ? 
               pass1.Equals(pass2) ? true : false 
           : false;
    }
    public void goToLogin()
    {
        SceneManager.LoadScene("LoginScene");
    }

    IEnumerator RegisterUser(string username, string emails, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("emails", emails);
        form.AddField("password", password);

        using (UnityWebRequest www = UnityWebRequest.Post("https://gradproject.site/cgi-bin/Register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {

                if (www.downloadHandler.text.Equals("username or email exist"))
                {
                    Toast.Show(www.downloadHandler.text, 2f, ToastColor.Red);
                }
                else
                {
                    SceneManager.LoadScene("LoginScene");
                }

            }
        }
    }

    void RegisterUser2(string username, string emails, string password)
    {
        ServicePointManager.ServerCertificateValidationCallback = TrustCertificate;

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://gradproject.site/cgi-bin/Register.php");
        request.ContentType = "application/x-www-form-urlencoded";
        request.Method = "POST";
        Stream dataStream = request.GetRequestStream();
        NameValueCollection nvc = new NameValueCollection();
        nvc.Add("username", username);
        nvc.Add("emails", emails);
        nvc.Add("password", password);

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
        if (responseFromServer.Equals("username or email exist"))
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
