﻿#pragma checksum "..\..\WindowMain.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "430490A9FA9C028466EC8E8CBFF5AA5C80A15992930F1C6190C48DC108943172"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ClientViews;
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


namespace ClientViews {
    
    
    /// <summary>
    /// WindowMain
    /// </summary>
    public partial class WindowMain : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\WindowMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b1;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\WindowMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b2;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\WindowMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b3;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\WindowMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b4;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\WindowMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b5;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\WindowMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame frame;
        
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
            System.Uri resourceLocater = new System.Uri("/ClientViews;component/windowmain.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WindowMain.xaml"
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
            this.b1 = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\WindowMain.xaml"
            this.b1.Click += new System.Windows.RoutedEventHandler(this.b1_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.b2 = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\WindowMain.xaml"
            this.b2.Click += new System.Windows.RoutedEventHandler(this.bGetAnimals_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.b3 = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\WindowMain.xaml"
            this.b3.Click += new System.Windows.RoutedEventHandler(this.b3_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.b4 = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\WindowMain.xaml"
            this.b4.Click += new System.Windows.RoutedEventHandler(this.b4_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.b5 = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\WindowMain.xaml"
            this.b5.Click += new System.Windows.RoutedEventHandler(this.b5_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.frame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
