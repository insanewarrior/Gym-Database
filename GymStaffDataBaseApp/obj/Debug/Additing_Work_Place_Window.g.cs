﻿#pragma checksum "..\..\Additing_Work_Place_Window.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3970B37712BCBE2C5F73CDC22A78035D"
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
    /// Additing_Work_Place_Window
    /// </summary>
    public partial class Additing_Work_Place_Window : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\Additing_Work_Place_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Work_Place_Grid;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\Additing_Work_Place_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Description_Label;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\Additing_Work_Place_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Location_Label;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\Additing_Work_Place_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Description_TextBox;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\Additing_Work_Place_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Location_TextBox;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Additing_Work_Place_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add_Button;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Additing_Work_Place_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Cancel_Button;
        
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
            System.Uri resourceLocater = new System.Uri("/GymStaffDataBaseApp;component/additing_work_place_window.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Additing_Work_Place_Window.xaml"
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
            
            #line 4 "..\..\Additing_Work_Place_Window.xaml"
            ((GymStaffDataBaseApp.Additing_Work_Place_Window)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Additing_Work_Place_Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Work_Place_Grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.Description_Label = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.Location_Label = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.Description_TextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Location_TextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Add_Button = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\Additing_Work_Place_Window.xaml"
            this.Add_Button.Click += new System.Windows.RoutedEventHandler(this.Add_Button_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Cancel_Button = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\Additing_Work_Place_Window.xaml"
            this.Cancel_Button.Click += new System.Windows.RoutedEventHandler(this.Cancel_Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
