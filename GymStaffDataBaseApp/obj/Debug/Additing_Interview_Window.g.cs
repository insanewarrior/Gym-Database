﻿#pragma checksum "..\..\Additing_Interview_Window.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AF71524C87FB695824B302E9C42ABE6F"
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
    /// Additing_Interview_Window
    /// </summary>
    public partial class Additing_Interview_Window : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\Additing_Interview_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Interview_Grid;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Additing_Interview_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Candidate_ComboBox;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Additing_Interview_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Post_ComboBox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Additing_Interview_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Result_ComboBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Additing_Interview_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Document_ComboBox;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Additing_Interview_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Date_DatePicker;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Additing_Interview_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add_Button;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Additing_Interview_Window.xaml"
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
            System.Uri resourceLocater = new System.Uri("/GymStaffDataBaseApp;component/additing_interview_window.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Additing_Interview_Window.xaml"
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
            
            #line 4 "..\..\Additing_Interview_Window.xaml"
            ((GymStaffDataBaseApp.Additing_Interview_Window)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Additing_Interview_Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Interview_Grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.Candidate_ComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 12 "..\..\Additing_Interview_Window.xaml"
            this.Candidate_ComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Candidate_TextBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Post_ComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.Result_ComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.Document_ComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.Date_DatePicker = ((System.Windows.Controls.DatePicker)(target));
            
            #line 21 "..\..\Additing_Interview_Window.xaml"
            this.Date_DatePicker.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.Date_DatePicker_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Add_Button = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\Additing_Interview_Window.xaml"
            this.Add_Button.Click += new System.Windows.RoutedEventHandler(this.Add_Button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Cancel_Button = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\Additing_Interview_Window.xaml"
            this.Cancel_Button.Click += new System.Windows.RoutedEventHandler(this.Cancel_Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
