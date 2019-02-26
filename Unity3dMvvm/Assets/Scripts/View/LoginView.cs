using Assets.Scripts.ViewModel;
using System.Collections;
using System.Collections.Generic;
using uMVVM.Sources.Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.View
{
    /// <summary>
    /// 登陆界面
    /// </summary>
    public class LoginView : UnityGuiView<LoginViewModel>
    {
        public InputField AccountInput;

        public InputField PasswordInput;

        //public Text AccountText;

        //public Text PasswordText;

        //public Image HintPanel;

        //public Text HintText;

        public Button LoginBtn;

        public Button RegisterBtn;

        public LoginViewModel ViewModel { get { return BindingContext; } }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            Binder.Add<string>("AccountText", OnAccountInputValueChanged);

            Binder.Add<string>("PasswordText", OnPasswordInputValueChanged);

            //Binder.Add<string>(nameof(ViewModel.AccountText), OnAccountInputValueChanged);

            //Binder.Add<string>(nameof(ViewModel.PasswordText), OnAccountInputValueChanged);
        }

        public void AccountInput_ValueChanged()
        {
            ViewModel.AccountText.Value = AccountInput.text;
        }

        public void PasswordInput_ValueChanged()
        {
            ViewModel.PasswordText.Value = PasswordInput.text;
        }

        public void RegisterInvoke()
        {
            ViewModel.RegisterInvoke();
        }

        public void LoginInvoke()
        {
            ViewModel.LoginInvoke();
        }

        private void OnAccountInputValueChanged(string oldValue, string newValue)
        {
            AccountInput.text = newValue.ToString();
        }

        private void OnPasswordInputValueChanged(string oldValue, string newValue)
        {
            PasswordInput.text = newValue.ToString();
        }
    }
}