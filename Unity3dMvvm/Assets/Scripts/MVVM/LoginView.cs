using System.Collections;
using System.Collections.Generic;
using uMVVM.Sources.Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MVVM
{
    public class LoginView : UnityGuiView<LoginViewModel>
    {
        public InputField AccountInput;

        public InputField PasswordInput;

        public Text AccountText;

        public Text PasswordText;

        public Image HintPanel;

        public Text HintText;

        public Button LoginBtn;

        public Button RegisterBtn;

    }
}