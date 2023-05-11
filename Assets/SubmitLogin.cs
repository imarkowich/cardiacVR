using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using VRUiKits.Utils;
using System.Collections;

public class SubmitLogin : MonoBehaviour
{
    public UIKitInputField Username;
    public UIKitInputField Password;
    public TMP_Text Error;
    public TMP_Text NoInternetError;

    [Header("Components")]
    [SerializeField] private GameObject keyboard;
    [SerializeField] private GameObject submitButton;
    [SerializeField] private GameObject guestButton;
    [SerializeField] private GameObject loggedInView;
    [SerializeField] private GameObject guestLoggedInView;
    [SerializeField] private GameObject noInternetView;

    public void Submit()
    {
        if (Username.text == "" || Password.text == "")
        {
            Error.text = "Please enter a username and password.";
        }
        else
        {
            StartCoroutine(DoLogin());
        }
    }

    IEnumerator DoLogin()
    {
        var loginRequest = GetComponent<LoginControl>();
        loginRequest.InitLoginRequest(Username.text, Password.text);
        yield return loginRequest.GetLogin();

        Error.text = loginRequest.error != "" ? loginRequest.error : "";

        if (Error.text == "")
        {
            LoginInfo.login = loginRequest.login;

            Username.text = Password.text = "";

            DisableLoginScreen();
            loggedInView.SetActive(true);
        }
        else
        {
            LoginInfo.login = null;
        }
    }

    public void SignOut()
    {
        Username.text = Password.text = "";
        LoginInfo.login = null;
    }

    public void GuestLogin()
    {
        StartCoroutine(DoGuestLogin());
    }

    IEnumerator DoGuestLogin()
    {
        var loginRequest = GetComponent<LoginControl>();
        loginRequest.InitLoginRequest(LoginInfo.GuestUsername, LoginInfo.GuestPassword);
        yield return loginRequest.GetLogin();

        if (!loginRequest.isThereInternet || loginRequest.error != "")
        {
            DisableLoginScreen();
            NoInternetError.text = "Error message: " + loginRequest.error;
            noInternetView.SetActive(true);

            LoginInfo.login = null;
            yield break;
        }

        LoginInfo.login = loginRequest.login;
        Debug.Log(LoginInfo.login);

        DisableLoginScreen();
        guestLoggedInView.SetActive(true);
    }

    void DisableLoginScreen()
    {
        Error.text = "";
        keyboard.SetActive(false);
        submitButton.SetActive(false);
        guestButton.SetActive(false);
    }
}
