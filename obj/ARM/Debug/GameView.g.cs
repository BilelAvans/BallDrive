﻿#pragma checksum "C:\Users\Bilel\Source\Repos\BallDrive\GameView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5B7D7D7C34D7C9197EC7E08D9047D44C"
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
    partial class GameView : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        internal class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_FrameworkElement_DataContext(global::Windows.UI.Xaml.FrameworkElement obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.DataContext = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Windows.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
        };

        private class GameView_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IGameView_Bindings
        {
            private global::BallDrive.GameView dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.Grid obj5;
            private global::Windows.UI.Xaml.Controls.ItemsControl obj11;

            public GameView_obj1_Bindings()
            {
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 5:
                        this.obj5 = (global::Windows.UI.Xaml.Controls.Grid)target;
                        break;
                    case 11:
                        this.obj11 = (global::Windows.UI.Xaml.Controls.ItemsControl)target;
                        break;
                    default:
                        break;
                }
            }

            // IGameView_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            // GameView_obj1_Bindings

            public void SetDataRoot(global::BallDrive.GameView newDataRoot)
            {
                this.dataRoot = newDataRoot;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::BallDrive.GameView obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_CurrentGame(obj.CurrentGame, phase);
                    }
                }
            }
            private void Update_CurrentGame(global::BallDrive.Data.Games.Game obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_CurrentGame_CMan(obj.CMan, phase);
                    }
                }
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_FrameworkElement_DataContext(this.obj5, obj, null);
                }
            }
            private void Update_CurrentGame_CMan(global::BallDrive.Data.Characters.CharacterManager obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_CurrentGame_CMan_Characters(obj.Characters, phase);
                    }
                }
            }
            private void Update_CurrentGame_CMan_Characters(global::System.Collections.ObjectModel.ObservableCollection<global::BallDrive.Data.Characters.Character> obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj11, obj, null);
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2:
                {
                    this.gridje = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3:
                {
                    this.enemyDiedAnimation = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 4:
                {
                    global::Windows.UI.Xaml.Media.Animation.DoubleAnimation element4 = (global::Windows.UI.Xaml.Media.Animation.DoubleAnimation)(target);
                    #line 17 "..\..\..\GameView.xaml"
                    ((global::Windows.UI.Xaml.Media.Animation.DoubleAnimation)element4).Completed += this.enemyDiedAnimation_Completed;
                    #line default
                }
                break;
            case 6:
                {
                    this.GamePanel = (global::Windows.UI.Xaml.Controls.Canvas)(target);
                }
                break;
            case 7:
                {
                    this.CloseButton = (global::Windows.UI.Xaml.Controls.Image)(target);
                    #line 58 "..\..\..\GameView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Image)this.CloseButton).PointerPressed += this.CloseButton_Click;
                    #line default
                }
                break;
            case 8:
                {
                    this.resetButton = (global::Windows.UI.Xaml.Controls.Image)(target);
                    #line 59 "..\..\..\GameView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Image)this.resetButton).PointerPressed += this.resetButton_Click;
                    #line default
                }
                break;
            case 9:
                {
                    this.pauseStatusImage = (global::Windows.UI.Xaml.Controls.Image)(target);
                    #line 60 "..\..\..\GameView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Image)this.pauseStatusImage).PointerPressed += this.pauseButton_Click;
                    #line default
                }
                break;
            case 10:
                {
                    this.PlayerEllipse = (global::Windows.UI.Xaml.Shapes.Ellipse)(target);
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
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    GameView_obj1_Bindings bindings = new GameView_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            }
            return returnValue;
        }
    }
}

