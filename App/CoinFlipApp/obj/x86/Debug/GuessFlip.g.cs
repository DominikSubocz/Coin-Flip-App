﻿#pragma checksum "C:\Users\1742914\Downloads\Coin-Flip-App\App\CoinFlipApp\GuessFlip.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "45CCF2FBFFFBB5365F4D44A65D80BBF82BF1D582F20F7028109936E2AB41F040"
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
    partial class GuessFlip : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
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
            public static void Set_Windows_UI_Xaml_Documents_Run_Text(global::Windows.UI.Xaml.Documents.Run obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class GuessFlip_obj16_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IGuessFlip_Bindings
        {
            private global::CoinFlipApp.HistoryItem dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::System.WeakReference obj16;
            private global::Windows.UI.Xaml.Documents.Run obj17;
            private global::Windows.UI.Xaml.Documents.Run obj18;
            private global::Windows.UI.Xaml.Documents.Run obj19;
            private global::Windows.UI.Xaml.Documents.Run obj20;
            private global::Windows.UI.Xaml.Documents.Run obj21;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj17TextDisabled = false;
            private static bool isobj18TextDisabled = false;
            private static bool isobj19TextDisabled = false;
            private static bool isobj20TextDisabled = false;
            private static bool isobj21TextDisabled = false;

            public GuessFlip_obj16_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 70 && columnNumber == 42)
                {
                    isobj17TextDisabled = true;
                }
                else if (lineNumber == 66 && columnNumber == 42)
                {
                    isobj18TextDisabled = true;
                }
                else if (lineNumber == 62 && columnNumber == 42)
                {
                    isobj19TextDisabled = true;
                }
                else if (lineNumber == 58 && columnNumber == 42)
                {
                    isobj20TextDisabled = true;
                }
                else if (lineNumber == 54 && columnNumber == 42)
                {
                    isobj21TextDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 16: // GuessFlip.xaml line 50
                        this.obj16 = new global::System.WeakReference((global::Windows.UI.Xaml.Controls.StackPanel)target);
                        break;
                    case 17: // GuessFlip.xaml line 70
                        this.obj17 = (global::Windows.UI.Xaml.Documents.Run)target;
                        break;
                    case 18: // GuessFlip.xaml line 66
                        this.obj18 = (global::Windows.UI.Xaml.Documents.Run)target;
                        break;
                    case 19: // GuessFlip.xaml line 62
                        this.obj19 = (global::Windows.UI.Xaml.Documents.Run)target;
                        break;
                    case 20: // GuessFlip.xaml line 58
                        this.obj20 = (global::Windows.UI.Xaml.Documents.Run)target;
                        break;
                    case 21: // GuessFlip.xaml line 54
                        this.obj21 = (global::Windows.UI.Xaml.Documents.Run)target;
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
                            (this.obj16.Target as global::Windows.UI.Xaml.Controls.StackPanel).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_((global::CoinFlipApp.HistoryItem) item, 1 << phase);
            }

            public void Recycle()
            {
            }

            // IGuessFlip_Bindings

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
                        this.Update_Duration(obj.Duration, phase);
                        this.Update_Result(obj.Result, phase);
                        this.Update_Mode(obj.Mode, phase);
                        this.Update_Guessed(obj.Guessed, phase);
                        this.Update_CoinType(obj.CoinType, phase);
                    }
                }
            }
            private void Update_Duration(global::System.Int32 obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // GuessFlip.xaml line 70
                    if (!isobj17TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Documents_Run_Text(this.obj17, obj.ToString(), null);
                    }
                }
            }
            private void Update_Result(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // GuessFlip.xaml line 66
                    if (!isobj18TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Documents_Run_Text(this.obj18, obj, null);
                    }
                }
            }
            private void Update_Mode(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // GuessFlip.xaml line 62
                    if (!isobj19TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Documents_Run_Text(this.obj19, obj, null);
                    }
                }
            }
            private void Update_Guessed(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // GuessFlip.xaml line 58
                    if (!isobj20TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Documents_Run_Text(this.obj20, obj, null);
                    }
                }
            }
            private void Update_CoinType(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // GuessFlip.xaml line 54
                    if (!isobj21TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Documents_Run_Text(this.obj21, obj, null);
                    }
                }
            }
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class GuessFlip_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IGuessFlip_Bindings
        {
            private global::CoinFlipApp.GuessFlip dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.ListView obj9;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj9ItemsSourceDisabled = false;

            public GuessFlip_obj1_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 47 && columnNumber == 23)
                {
                    isobj9ItemsSourceDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 9: // GuessFlip.xaml line 47
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

            // IGuessFlip_Bindings

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
                    this.dataRoot = (global::CoinFlipApp.GuessFlip)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::CoinFlipApp.GuessFlip obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_coinFlipHistory(obj.coinFlipHistory, phase);
                    }
                }
            }
            private void Update_coinFlipHistory(global::System.Collections.ObjectModel.ObservableCollection<global::CoinFlipApp.HistoryItem> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // GuessFlip.xaml line 47
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
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // GuessFlip.xaml line 14
                {
                    this.MainContent = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // GuessFlip.xaml line 135
                {
                    this.MenuSplitView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 4: // GuessFlip.xaml line 140
                {
                    global::Windows.UI.Xaml.Controls.Button element4 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element4).Click += this.MenuClicked;
                }
                break;
            case 5: // GuessFlip.xaml line 206
                {
                    this.volumeSlider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                    ((global::Windows.UI.Xaml.Controls.Slider)this.volumeSlider).ValueChanged += this.VolumeChanged;
                }
                break;
            case 6: // GuessFlip.xaml line 188
                {
                    this.durationSlider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                }
                break;
            case 7: // GuessFlip.xaml line 169
                {
                    this.CoinComboBox = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.CoinComboBox).SelectionChanged += this.coinSelected;
                }
                break;
            case 8: // GuessFlip.xaml line 146
                {
                    global::Windows.UI.Xaml.Controls.Button element8 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element8).Click += this.CoinFlipClicked;
                }
                break;
            case 10: // GuessFlip.xaml line 81
                {
                    this.videoPlayer = (global::Windows.UI.Xaml.Controls.MediaElement)(target);
                }
                break;
            case 11: // GuessFlip.xaml line 84
                {
                    this.soundPlayer = (global::Windows.UI.Xaml.Controls.MediaElement)(target);
                }
                break;
            case 12: // GuessFlip.xaml line 102
                {
                    this.GuessHeadsBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.GuessHeadsBtn).Click += this.GuessHeadsClicked;
                }
                break;
            case 13: // GuessFlip.xaml line 113
                {
                    this.GuessTailsBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.GuessTailsBtn).Click += this.GuessTailsClicked;
                }
                break;
            case 14: // GuessFlip.xaml line 128
                {
                    global::Windows.UI.Xaml.Controls.Button element14 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element14).Click += this.MenuClicked;
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
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // GuessFlip.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    GuessFlip_obj1_Bindings bindings = new GuessFlip_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            case 16: // GuessFlip.xaml line 50
                {                    
                    global::Windows.UI.Xaml.Controls.StackPanel element16 = (global::Windows.UI.Xaml.Controls.StackPanel)target;
                    GuessFlip_obj16_Bindings bindings = new GuessFlip_obj16_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(element16.DataContext);
                    element16.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element16, bindings);
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element16, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

