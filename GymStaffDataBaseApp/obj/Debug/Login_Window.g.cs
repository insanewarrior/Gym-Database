﻿#pragma checksum "..\..\Login_Window.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "051C6B6C4B7B4804FB66BC752DD895E4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.34209
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace GymStaffDataBaseApp {
    
    
    /// <summary>
    /// LoginWindow
    /// </summary>
    public partial class LoginWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\Login_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Login_Label;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Login_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Password_Label;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Login_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Login_TextBox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Login_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox Password_TextBox;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Login_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Login_Button;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Login_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Exit_Button;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GymStaffDataBaseApp;component/login_window.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Login_Window.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 5 "..\..\Login_Window.xaml"
            ((GymStaffDataBaseApp.LoginWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Login_Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Login_Label = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.Password_Label = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.Login_TextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Password_TextBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 6:
            this.Login_Button = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\Login_Window.xaml"
            this.Login_Button.Click += new System.Windows.RoutedEventHandler(this.Login_Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Exit_Button = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\Login_Window.xaml"
            this.Exit_Button.Click += new System.Windows.RoutedEventHandler(this.Exit_Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

