﻿#pragma checksum "C:\Users\Bilel\Documents\Visual Studio 2015\Projects\BallDrive\BallDrive\NewGamePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E958EEE397B67A29F0C296C240FF57BD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BallDrive
{
    partial class NewGamePage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.GameSettingsPanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 2:
                {
                    this.SmackWanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 3:
                {
                    this.notification = (global::Windows.UI.Xaml.Controls.Primitives.Popup)(target);
                }
                break;
            case 4:
                {
                    this.popupgrid = (global::Windows.UI.Xaml.Controls.RelativePanel)(target);
                }
                break;
            case 5:
                {
                    this.notificationTextBlockTitle = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6:
                {
                    this.notificationTextBlockMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7:
                {
                    this.notificationReadButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 31 "..\..\..\NewGamePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.notificationReadButton).Click += this.notificationReadButton_Click;
                    #line default
                }
                break;
            case 8:
                {
                    this.diffSelection = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                }
                break;
            case 9:
                {
                    this.StartGameButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 23 "..\..\..\NewGamePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.StartGameButton).Click += this.StartGameButton_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

