﻿#pragma checksum "F:\Coin-Flip-App\App\CoinFlipApp\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FBEAE5192226B956BD9B4AE7A7782F0801C2AF992588C7909AB1ACD3A6ECCCA3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoinFlipApp
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Windows.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class MainPage_obj17_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IMainPage_Bindings
        {
            private global::CoinFlipApp.HistoryItem dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::System.WeakReference obj17;
            private global::Windows.UI.Xaml.Controls.TextBlock obj18;
            private global::Windows.UI.Xaml.Controls.TextBlock obj19;
            private global::Windows.UI.Xaml.Controls.TextBlock obj20;
            private global::Windows.UI.Xaml.Controls.TextBlock obj21;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj18TextDisabled = false;
            private static bool isobj19TextDisabled = false;
            private static bool isobj20TextDisabled = false;
            private static bool isobj21TextDisabled = false;

            public MainPage_obj17_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 48 && columnNumber == 40)
                {
                    isobj18TextDisabled = true;
                }
                else if (lineNumber == 49 && columnNumber == 40)
                {
                    isobj19TextDisabled = true;
                }
                else if (lineNumber == 50 && columnNumber == 40)
                {
                    isobj20TextDisabled = true;
                }
                else if (lineNumber == 51 && columnNumber == 40)
                {
                    isobj21TextDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 17: // MainPage.xaml line 47
                        this.obj17 = new global::System.WeakReference((global::Windows.UI.Xaml.Controls.StackPanel)target);
                        break;
                    case 18: // MainPage.xaml line 48
                        this.obj18 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 19: // MainPage.xaml line 49
                        this.obj19 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 20: // MainPage.xaml line 50
                        this.obj20 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 21: // MainPage.xaml line 51
                        this.obj21 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 if (this.SetDataRoot(args.NewValue))
                 {
                    this.Update();
                 }
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                ProcessBindings(args.Item, args.ItemIndex, (int)args.Phase, out nextPhase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                Recycle();
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
                switch(phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(item);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            (this.obj17.Target as global::Windows.UI.Xaml.Controls.StackPanel).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_((global::CoinFlipApp.HistoryItem) item, 1 << phase);
            }

            public void Recycle()
            {
            }

            // IMainPage_Bindings

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

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::CoinFlipApp.HistoryItem)newDataRoot;
                    return true;
                }
                return false;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::CoinFlipApp.HistoryItem obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_CoinType(obj.CoinType, phase);
                        this.Update_Mode(obj.Mode, phase);
                        this.Update_Result(obj.Result, phase);
                        this.Update_Duration(obj.Duration, phase);
                    }
                }
            }
            private void Update_CoinType(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 48
                    if (!isobj18TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj18, obj, null);
                    }
                }
            }
            private void Update_Mode(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 49
                    if (!isobj19TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj19, obj, null);
                    }
                }
            }
            private void Update_Result(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 50
                    if (!isobj20TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj20, obj, null);
                    }
                }
            }
            private void Update_Duration(global::System.Int32 obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 51
                    if (!isobj21TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj21, obj.ToString(), null);
                    }
                }
            }
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class MainPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IMainPage_Bindings
        {
            private global::CoinFlipApp.MainPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.ListView obj9;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj9ItemsSourceDisabled = false;

            public MainPage_obj1_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 44 && columnNumber == 23)
                {
                    isobj9ItemsSourceDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 9: // MainPage.xaml line 44
                        this.obj9 = (global::Windows.UI.Xaml.Controls.ListView)target;
                        break;
                    default:
                        break;
                }
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // IMainPage_Bindings

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

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::CoinFlipApp.MainPage)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::CoinFlipApp.MainPage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_coinFlipHistory(obj.coinFlipHistory, phase);
                    }
                }
            }
            private void Update_coinFlipHistory(global::System.Collections.Generic.List<global::CoinFlipApp.HistoryItem> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 44
                    if (!isobj9ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj9, obj, null);
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 13
                {
                    this.MainContent = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // MainPage.xaml line 98
                {
                    this.MenuSplitView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 4: // MainPage.xaml line 102
                {
                    global::Windows.UI.Xaml.Controls.Button element4 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element4).Click += this.MenuClicked;
                }
                break;
            case 5: // MainPage.xaml line 154
                {
                    this.volumeSlider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                    ((global::Windows.UI.Xaml.Controls.Slider)this.volumeSlider).ValueChanged += this.VolumeChanged;
                }
                break;
            case 6: // MainPage.xaml line 139
                {
                    this.durationSlider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                }
                break;
            case 7: // MainPage.xaml line 124
                {
                    this.CoinComboBox = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 8: // MainPage.xaml line 108
                {
                    global::Windows.UI.Xaml.Controls.Button element8 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element8).Click += this.GuessClicked;
                }
                break;
            case 10: // MainPage.xaml line 57
                {
                    this.videoPlayer = (global::Windows.UI.Xaml.Controls.MediaElement)(target);
                }
                break;
            case 11: // MainPage.xaml line 61
                {
                    this.soundPlayer = (global::Windows.UI.Xaml.Controls.MediaElement)(target);
                }
                break;
            case 12: // MainPage.xaml line 66
                {
                    this.HeadsScoreTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13: // MainPage.xaml line 67
                {
                    this.TailsScoreTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 14: // MainPage.xaml line 80
                {
                    this.FlipBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.FlipBtn).Click += this.FlipCoin;
                }
                break;
            case 15: // MainPage.xaml line 94
                {
                    global::Windows.UI.Xaml.Controls.Button element15 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element15).Click += this.MenuClicked;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // MainPage.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    MainPage_obj1_Bindings bindings = new MainPage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            case 17: // MainPage.xaml line 47
                {                    
                    global::Windows.UI.Xaml.Controls.StackPanel element17 = (global::Windows.UI.Xaml.Controls.StackPanel)target;
                    MainPage_obj17_Bindings bindings = new MainPage_obj17_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(element17.DataContext);
                    element17.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element17, bindings);
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element17, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

