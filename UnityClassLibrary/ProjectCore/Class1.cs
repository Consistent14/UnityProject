using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectCore
{
    namespace Assets
    {

        public class StuepView
        {
            public InputField nameInputField;
            public Text nameMessageText;
        }
        public class BindableProperty<T>
        {
            public delegate void ValueChangedHandler(T oldValue, T newValue);

            public ValueChangedHandler OnValueChanged;

            private T _value;
            public T Value
            {
                get
                {
                    return _value;
                }
                set
                {
                    if (!object.Equals(_value, value))
                    {
                        T old = _value;
                        _value = value;
                        ValueChanged(old, _value);
                    }
                }
            }

            private void ValueChanged(T oldValue, T newValue)
            {
                if (OnValueChanged != null)
                {
                    OnValueChanged(oldValue, newValue);
                }
            }

            public override string ToString()
            {
                return (Value != null ? Value.ToString() : "null");
            }
        }

        public class SetupViewModel : ViewModelBase
        {
            public BindableProperty<string> Name = new BindableProperty<string>();
            public BindableProperty<string> Job = new BindableProperty<string>();
            public BindableProperty<int> ATK = new BindableProperty<int>();
            public BindableProperty<float> SuccessRate = new BindableProperty<float>();
            public BindableProperty<State> State = new BindableProperty<State>();
        }

        public interface IView
        {
            ViewModelBase BindingContext { get; set; }
        }

        public class UnityGuiView : MonoBehaviour, IView
        {
            public readonly BindableProperty<ViewModelBase> ViewModelProperty = new BindableProperty<ViewModelBase>();
            public ViewModelBase BindingContext
            {
                get { return ViewModelProperty.Value; }
                set { ViewModelProperty.Value = value; }
            }

            protected virtual void OnBindingContextChanged(ViewModelBase oldViewModel, ViewModelBase newViewModel)
            {
            }

            public UnityGuiView()
            {
                this.ViewModelProperty.OnValueChanged += OnBindingContextChanged;
            }

        }
        [AttributeUsage(AttributeTargets.Property)]
        public class RepositoryKey : Attribute
        {

        }
        public class Combatant
        {
            [RepositoryKey]
            public int Id { get; set; }
            public string Name { get; set; }
            public string Job { get; set; }
            public float SuccessRate { get; set; }
            public State State { get; set; }
        }
        public enum State
        {
            JoinIn,
            Wait
        }
        public class ViewModelBase
        {
            private bool _isInitialized;
            public ViewModelBase ParentViewModel { get; set; }
            public bool IsRevealed { get; private set; }
            public bool IsRevealInProgress { get; private set; }
            public bool IsHideInProgress { get; private set; }

            protected virtual void OnInitialize()
            {

            }

            public virtual void OnStartReveal()
            {
                IsRevealInProgress = true;
                //在开始显示的时候进行初始化操作
                if (!_isInitialized)
                {
                    OnInitialize();
                    _isInitialized = true;
                }
            }

            public virtual void OnFinishReveal()
            {
                IsRevealInProgress = false;
                IsRevealed = true;
            }

            public virtual void OnStartHide()
            {
                IsHideInProgress = true;

            }

            public virtual void OnFinishHide()
            {
                IsHideInProgress = false;
                IsRevealed = false;
            }

            public virtual void OnDestory()
            {

            }

        }
    }
}
