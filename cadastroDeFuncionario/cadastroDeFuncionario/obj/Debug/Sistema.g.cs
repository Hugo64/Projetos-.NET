﻿#pragma checksum "..\..\Sistema.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9A89537B85871C4D2FD6741EC8E828E7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
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


namespace cadastroDeFuncionario {
    
    
    /// <summary>
    /// Sistema
    /// </summary>
    public partial class Sistema : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\Sistema.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelExibirNome;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Sistema.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem OpcaoCadastrar;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Sistema.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuCadastrarFuncionario;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Sistema.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuPesquisarFuncionario;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Sistema.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem OpcaoAdministrador;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Sistema.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuNovoAdministrador;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Sistema.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuBuscarAdministrador;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Sistema.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuDadosDoServidor;
        
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
            System.Uri resourceLocater = new System.Uri("/cadastroDeFuncionario;component/sistema.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Sistema.xaml"
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
            this.LabelExibirNome = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.OpcaoCadastrar = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 3:
            this.menuCadastrarFuncionario = ((System.Windows.Controls.MenuItem)(target));
            
            #line 15 "..\..\Sistema.xaml"
            this.menuCadastrarFuncionario.Click += new System.Windows.RoutedEventHandler(this.menuCadastrarFuncionario_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.menuPesquisarFuncionario = ((System.Windows.Controls.MenuItem)(target));
            
            #line 16 "..\..\Sistema.xaml"
            this.menuPesquisarFuncionario.Click += new System.Windows.RoutedEventHandler(this.menuPesquisarFuncionario_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.OpcaoAdministrador = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 6:
            this.menuNovoAdministrador = ((System.Windows.Controls.MenuItem)(target));
            
            #line 19 "..\..\Sistema.xaml"
            this.menuNovoAdministrador.Click += new System.Windows.RoutedEventHandler(this.menuNovoAdministrador_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.menuBuscarAdministrador = ((System.Windows.Controls.MenuItem)(target));
            
            #line 20 "..\..\Sistema.xaml"
            this.menuBuscarAdministrador.Click += new System.Windows.RoutedEventHandler(this.menuBuscarAdministrador_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.menuDadosDoServidor = ((System.Windows.Controls.MenuItem)(target));
            
            #line 21 "..\..\Sistema.xaml"
            this.menuDadosDoServidor.Click += new System.Windows.RoutedEventHandler(this.menuDadosDoServidor_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

