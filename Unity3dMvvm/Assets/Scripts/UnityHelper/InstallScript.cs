using Assets.Scripts.View;
using Assets.Scripts.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.UnityHelper
{
    public class InstallScript : MonoBehaviour
    {
        public LoginView _loginView;

        // Use this for initialization
        void Start()
        {
            AppDomain.CurrentDomain.ResourceResolve += OnAssemblyResolve;

            _loginView.BindingContext = new LoginViewModel();
        }

        // Update is called once per frame
        void Update()
        {
            //Verfiy();
        }
        
        static string RealDwgPath = @"D:\Program Files\Unity2018\Unity\Editor\Data\MonoBleedingEdge\lib\mono\4.7.1-api\System.Data.dll";

        private static Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
        {
            var file = string.Empty;

            try
            {
                var assemblyName = new AssemblyName(args.Name);

                file = Path.Combine(RealDwgPath, string.Format("{0}.dll", assemblyName.Name));

                if (File.Exists(file))
                {
                    return Assembly.LoadFile(file);
                }

            }
            catch (System.Exception ex)
            {

            }

            return args.RequestingAssembly;
        }
    }
}
