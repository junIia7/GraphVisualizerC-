﻿#pragma checksum "..\..\Graph.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E0A0A329CC334F3F1B88483197CF4F81CF8F7218AB259B1AB2EF4E8D063599F7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
using WpfApp1;


namespace WpfApp1 {
    
    
    /// <summary>
    /// Graph
    /// </summary>
    public partial class Graph : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\Graph.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas BossCanvas;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Graph.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas mainCanvas;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/graph.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Graph.xaml"
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
            this.BossCanvas = ((System.Windows.Controls.Canvas)(target));
            return;
            case 2:
            this.mainCanvas = ((System.Windows.Controls.Canvas)(target));
            
            #line 29 "..\..\Graph.xaml"
            this.mainCanvas.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 29 "..\..\Graph.xaml"
            this.mainCanvas.MouseMove += new System.Windows.Input.MouseEventHandler(this.OnMouseMove);
            
            #line default
            #line hidden
            
            #line 29 "..\..\Graph.xaml"
            this.mainCanvas.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.OnMouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 31 "..\..\Graph.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BackToInp);
            
            #line default
            #line hidden
            
            #line 31 "..\..\Graph.xaml"
            ((System.Windows.Controls.Button)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouse);
            
            #line default
            #line hidden
            
            #line 31 "..\..\Graph.xaml"
            ((System.Windows.Controls.Button)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OffMouse);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
