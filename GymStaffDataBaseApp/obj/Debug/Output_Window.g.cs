﻿#pragma checksum "..\..\Output_Window.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "076B37D6300466E852658CBAAA5269DA"
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
    /// Output_Window
    /// </summary>
    public partial class Output_Window : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\Output_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Output_Grid;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\Output_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Filter_ComboBox;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Output_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Data_Grid;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Output_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Filter_Label;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Output_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Second_Name_Filter_TextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/GymStaffDataBaseApp;component/output_window.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Output_Window.xaml"
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
            
            #line 4 "..\..\Output_Window.xaml"
            ((GymStaffDataBaseApp.Output_Window)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Output_Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Output_Grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.Filter_ComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.Data_Grid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 11 "..\..\Output_Window.xaml"
            this.Data_Grid.Loaded += new System.Windows.RoutedEventHandler(this.Grid_Loaded);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Filter_Label = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.Second_Name_Filter_TextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\Output_Window.xaml"
            this.Second_Name_Filter_TextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Text_Changed);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
