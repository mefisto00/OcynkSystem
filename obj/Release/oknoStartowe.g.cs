﻿#pragma checksum "..\..\oknoStartowe.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "81E3BB2AC367BDF9BBA10556A2DD2D5A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Ocynkownia0811;
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


namespace Ocynkownia0811 {
    
    
    /// <summary>
    /// oknoStartowe
    /// </summary>
    public partial class oknoStartowe : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\oknoStartowe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button uruchomBramaBTN;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\oknoStartowe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button uruchomRozdzielniaBTN;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\oknoStartowe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button uruchomPlanowanieBTN;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\oknoStartowe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button uruchomFormowanieBTN;
        
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
            System.Uri resourceLocater = new System.Uri("/Ocynkownia0811;component/oknostartowe.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\oknoStartowe.xaml"
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
            this.uruchomBramaBTN = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\oknoStartowe.xaml"
            this.uruchomBramaBTN.Click += new System.Windows.RoutedEventHandler(this.UruchomBramaBTN_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.uruchomRozdzielniaBTN = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\oknoStartowe.xaml"
            this.uruchomRozdzielniaBTN.Click += new System.Windows.RoutedEventHandler(this.UruchomRozdzielniaBTN_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.uruchomPlanowanieBTN = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\oknoStartowe.xaml"
            this.uruchomPlanowanieBTN.Click += new System.Windows.RoutedEventHandler(this.UruchomPlanowanieBTN_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.uruchomFormowanieBTN = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\oknoStartowe.xaml"
            this.uruchomFormowanieBTN.Click += new System.Windows.RoutedEventHandler(this.UruchomFormowanieBTN_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

