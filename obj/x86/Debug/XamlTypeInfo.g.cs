﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



namespace BallDrive
{
    public partial class App : global::Windows.UI.Xaml.Markup.IXamlMetadataProvider
    {
    private global::BallDrive.BallDrive_XamlTypeInfo.XamlTypeInfoProvider _provider;

        /// <summary>
        /// GetXamlType(Type)
        /// </summary>
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(global::System.Type type)
        {
            if(_provider == null)
            {
                _provider = new global::BallDrive.BallDrive_XamlTypeInfo.XamlTypeInfoProvider();
            }
            return _provider.GetXamlTypeByType(type);
        }

        /// <summary>
        /// GetXamlType(String)
        /// </summary>
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(string fullName)
        {
            if(_provider == null)
            {
                _provider = new global::BallDrive.BallDrive_XamlTypeInfo.XamlTypeInfoProvider();
            }
            return _provider.GetXamlTypeByName(fullName);
        }

        /// <summary>
        /// GetXmlnsDefinitions()
        /// </summary>
        public global::Windows.UI.Xaml.Markup.XmlnsDefinition[] GetXmlnsDefinitions()
        {
            return new global::Windows.UI.Xaml.Markup.XmlnsDefinition[0];
        }
    }
}

namespace BallDrive.BallDrive_XamlTypeInfo
{
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal partial class XamlTypeInfoProvider
    {
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByType(global::System.Type type)
        {
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            if (_xamlTypeCacheByType.TryGetValue(type, out xamlType))
            {
                return xamlType;
            }
            int typeIndex = LookupTypeIndexByType(type);
            if(typeIndex != -1)
            {
                xamlType = CreateXamlType(typeIndex);
            }
            if (xamlType != null)
            {
                _xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
                _xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByName(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            if (_xamlTypeCacheByName.TryGetValue(typeName, out xamlType))
            {
                return xamlType;
            }
            int typeIndex = LookupTypeIndexByName(typeName);
            if(typeIndex != -1)
            {
                xamlType = CreateXamlType(typeIndex);
            }
            if (xamlType != null)
            {
                _xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
                _xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlMember GetMemberByLongName(string longMemberName)
        {
            if (string.IsNullOrEmpty(longMemberName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlMember xamlMember;
            if (_xamlMembers.TryGetValue(longMemberName, out xamlMember))
            {
                return xamlMember;
            }
            xamlMember = CreateXamlMember(longMemberName);
            if (xamlMember != null)
            {
                _xamlMembers.Add(longMemberName, xamlMember);
            }
            return xamlMember;
        }

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>
                _xamlTypeCacheByName = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>();

        global::System.Collections.Generic.Dictionary<global::System.Type, global::Windows.UI.Xaml.Markup.IXamlType>
                _xamlTypeCacheByType = new global::System.Collections.Generic.Dictionary<global::System.Type, global::Windows.UI.Xaml.Markup.IXamlType>();

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>
                _xamlMembers = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>();

        string[] _typeNameTable = null;
        global::System.Type[] _typeTable = null;

        private void InitTypeTables()
        {
            _typeNameTable = new string[13];
            _typeNameTable[0] = "BallDrive.Data.Characters.PositionToMarginConverter";
            _typeNameTable[1] = "Object";
            _typeNameTable[2] = "BallDrive.GameView";
            _typeNameTable[3] = "Windows.UI.Xaml.Controls.Page";
            _typeNameTable[4] = "Windows.UI.Xaml.Controls.UserControl";
            _typeNameTable[5] = "BallDrive.Data.Games.Game";
            _typeNameTable[6] = "BallDrive.HighScoreView";
            _typeNameTable[7] = "BallDrive.Data.PopupQueue";
            _typeNameTable[8] = "System.Collections.Generic.Queue`1<String>";
            _typeNameTable[9] = "Boolean";
            _typeNameTable[10] = "Int32";
            _typeNameTable[11] = "BallDrive.MainPage";
            _typeNameTable[12] = "String";

            _typeTable = new global::System.Type[13];
            _typeTable[0] = typeof(global::BallDrive.Data.Characters.PositionToMarginConverter);
            _typeTable[1] = typeof(global::System.Object);
            _typeTable[2] = typeof(global::BallDrive.GameView);
            _typeTable[3] = typeof(global::Windows.UI.Xaml.Controls.Page);
            _typeTable[4] = typeof(global::Windows.UI.Xaml.Controls.UserControl);
            _typeTable[5] = typeof(global::BallDrive.Data.Games.Game);
            _typeTable[6] = typeof(global::BallDrive.HighScoreView);
            _typeTable[7] = typeof(global::BallDrive.Data.PopupQueue);
            _typeTable[8] = typeof(global::System.Collections.Generic.Queue<global::System.String>);
            _typeTable[9] = typeof(global::System.Boolean);
            _typeTable[10] = typeof(global::System.Int32);
            _typeTable[11] = typeof(global::BallDrive.MainPage);
            _typeTable[12] = typeof(global::System.String);
        }

        private int LookupTypeIndexByName(string typeName)
        {
            if (_typeNameTable == null)
            {
                InitTypeTables();
            }
            for (int i=0; i<_typeNameTable.Length; i++)
            {
                if(0 == string.CompareOrdinal(_typeNameTable[i], typeName))
                {
                    return i;
                }
            }
            return -1;
        }

        private int LookupTypeIndexByType(global::System.Type type)
        {
            if (_typeTable == null)
            {
                InitTypeTables();
            }
            for(int i=0; i<_typeTable.Length; i++)
            {
                if(type == _typeTable[i])
                {
                    return i;
                }
            }
            return -1;
        }

        private object Activate_0_PositionToMarginConverter() { return new global::BallDrive.Data.Characters.PositionToMarginConverter(); }
        private object Activate_2_GameView() { return new global::BallDrive.GameView(); }
        private object Activate_6_HighScoreView() { return new global::BallDrive.HighScoreView(); }
        private object Activate_7_PopupQueue() { return new global::BallDrive.Data.PopupQueue(); }
        private object Activate_8_Queue() { return new global::System.Collections.Generic.Queue<global::System.String>(); }
        private object Activate_11_MainPage() { return new global::BallDrive.MainPage(); }

        private global::Windows.UI.Xaml.Markup.IXamlType CreateXamlType(int typeIndex)
        {
            global::BallDrive.BallDrive_XamlTypeInfo.XamlSystemBaseType xamlType = null;
            global::BallDrive.BallDrive_XamlTypeInfo.XamlUserType userType;
            string typeName = _typeNameTable[typeIndex];
            global::System.Type type = _typeTable[typeIndex];

            switch (typeIndex)
            {

            case 0:   //  BallDrive.Data.Characters.PositionToMarginConverter
                userType = new global::BallDrive.BallDrive_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.Activator = Activate_0_PositionToMarginConverter;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 1:   //  Object
                xamlType = new global::BallDrive.BallDrive_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 2:   //  BallDrive.GameView
                userType = new global::BallDrive.BallDrive_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_2_GameView;
                userType.AddMemberName("CurrentGame");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 3:   //  Windows.UI.Xaml.Controls.Page
                xamlType = new global::BallDrive.BallDrive_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 4:   //  Windows.UI.Xaml.Controls.UserControl
                xamlType = new global::BallDrive.BallDrive_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 5:   //  BallDrive.Data.Games.Game
                userType = new global::BallDrive.BallDrive_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.SetIsReturnTypeStub();
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 6:   //  BallDrive.HighScoreView
                userType = new global::BallDrive.BallDrive_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_6_HighScoreView;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 7:   //  BallDrive.Data.PopupQueue
                userType = new global::BallDrive.BallDrive_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("System.Collections.Generic.Queue`1<String>"));
                userType.Activator = Activate_7_PopupQueue;
                userType.AddMemberName("MessageAvailable");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 8:   //  System.Collections.Generic.Queue`1<String>
                userType = new global::BallDrive.BallDrive_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.Activator = Activate_8_Queue;
                userType.AddMemberName("Count");
                xamlType = userType;
                break;

            case 9:   //  Boolean
                xamlType = new global::BallDrive.BallDrive_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 10:   //  Int32
                xamlType = new global::BallDrive.BallDrive_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 11:   //  BallDrive.MainPage
                userType = new global::BallDrive.BallDrive_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_11_MainPage;
                userType.AddMemberName("deviceType");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 12:   //  String
                xamlType = new global::BallDrive.BallDrive_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;
            }
            return xamlType;
        }


        private object get_0_GameView_CurrentGame(object instance)
        {
            var that = (global::BallDrive.GameView)instance;
            return that.CurrentGame;
        }
        private void set_0_GameView_CurrentGame(object instance, object Value)
        {
            var that = (global::BallDrive.GameView)instance;
            that.CurrentGame = (global::BallDrive.Data.Games.Game)Value;
        }
        private object get_1_PopupQueue_MessageAvailable(object instance)
        {
            var that = (global::BallDrive.Data.PopupQueue)instance;
            return that.MessageAvailable;
        }
        private void set_1_PopupQueue_MessageAvailable(object instance, object Value)
        {
            var that = (global::BallDrive.Data.PopupQueue)instance;
            that.MessageAvailable = (global::System.Boolean)Value;
        }
        private object get_2_Queue_Count(object instance)
        {
            var that = (global::System.Collections.Generic.Queue<global::System.String>)instance;
            return that.Count;
        }
        private object get_3_MainPage_deviceType(object instance)
        {
            var that = (global::BallDrive.MainPage)instance;
            return that.deviceType;
        }
        private void set_3_MainPage_deviceType(object instance, object Value)
        {
            var that = (global::BallDrive.MainPage)instance;
            that.deviceType = (global::System.String)Value;
        }

        private global::Windows.UI.Xaml.Markup.IXamlMember CreateXamlMember(string longMemberName)
        {
            global::BallDrive.BallDrive_XamlTypeInfo.XamlMember xamlMember = null;
            global::BallDrive.BallDrive_XamlTypeInfo.XamlUserType userType;

            switch (longMemberName)
            {
            case "BallDrive.GameView.CurrentGame":
                userType = (global::BallDrive.BallDrive_XamlTypeInfo.XamlUserType)GetXamlTypeByName("BallDrive.GameView");
                xamlMember = new global::BallDrive.BallDrive_XamlTypeInfo.XamlMember(this, "CurrentGame", "BallDrive.Data.Games.Game");
                xamlMember.Getter = get_0_GameView_CurrentGame;
                xamlMember.Setter = set_0_GameView_CurrentGame;
                break;
            case "BallDrive.Data.PopupQueue.MessageAvailable":
                userType = (global::BallDrive.BallDrive_XamlTypeInfo.XamlUserType)GetXamlTypeByName("BallDrive.Data.PopupQueue");
                xamlMember = new global::BallDrive.BallDrive_XamlTypeInfo.XamlMember(this, "MessageAvailable", "Boolean");
                xamlMember.Getter = get_1_PopupQueue_MessageAvailable;
                xamlMember.Setter = set_1_PopupQueue_MessageAvailable;
                break;
            case "System.Collections.Generic.Queue`1<String>.Count":
                userType = (global::BallDrive.BallDrive_XamlTypeInfo.XamlUserType)GetXamlTypeByName("System.Collections.Generic.Queue`1<String>");
                xamlMember = new global::BallDrive.BallDrive_XamlTypeInfo.XamlMember(this, "Count", "Int32");
                xamlMember.Getter = get_2_Queue_Count;
                xamlMember.SetIsReadOnly();
                break;
            case "BallDrive.MainPage.deviceType":
                userType = (global::BallDrive.BallDrive_XamlTypeInfo.XamlUserType)GetXamlTypeByName("BallDrive.MainPage");
                xamlMember = new global::BallDrive.BallDrive_XamlTypeInfo.XamlMember(this, "deviceType", "String");
                xamlMember.Getter = get_3_MainPage_deviceType;
                xamlMember.Setter = set_3_MainPage_deviceType;
                break;
            }
            return xamlMember;
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlSystemBaseType : global::Windows.UI.Xaml.Markup.IXamlType
    {
        string _fullName;
        global::System.Type _underlyingType;

        public XamlSystemBaseType(string fullName, global::System.Type underlyingType)
        {
            _fullName = fullName;
            _underlyingType = underlyingType;
        }

        public string FullName { get { return _fullName; } }

        public global::System.Type UnderlyingType
        {
            get
            {
                return _underlyingType;
            }
        }

        virtual public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name) { throw new global::System.NotImplementedException(); }
        virtual public bool IsArray { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsCollection { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsConstructible { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsDictionary { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsMarkupExtension { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsBindable { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsReturnTypeStub { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsLocalType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType ItemType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType KeyType { get { throw new global::System.NotImplementedException(); } }
        virtual public object ActivateInstance() { throw new global::System.NotImplementedException(); }
        virtual public void AddToMap(object instance, object key, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void AddToVector(object instance, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void RunInitializer()   { throw new global::System.NotImplementedException(); }
        virtual public object CreateFromString(string input)   { throw new global::System.NotImplementedException(); }
    }
    
    internal delegate object Activator();
    internal delegate void AddToCollection(object instance, object item);
    internal delegate void AddToDictionary(object instance, object key, object item);

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlUserType : global::BallDrive.BallDrive_XamlTypeInfo.XamlSystemBaseType
    {
        global::BallDrive.BallDrive_XamlTypeInfo.XamlTypeInfoProvider _provider;
        global::Windows.UI.Xaml.Markup.IXamlType _baseType;
        bool _isArray;
        bool _isMarkupExtension;
        bool _isBindable;
        bool _isReturnTypeStub;
        bool _isLocalType;

        string _contentPropertyName;
        string _itemTypeName;
        string _keyTypeName;
        global::System.Collections.Generic.Dictionary<string, string> _memberNames;
        global::System.Collections.Generic.Dictionary<string, object> _enumValues;

        public XamlUserType(global::BallDrive.BallDrive_XamlTypeInfo.XamlTypeInfoProvider provider, string fullName, global::System.Type fullType, global::Windows.UI.Xaml.Markup.IXamlType baseType)
            :base(fullName, fullType)
        {
            _provider = provider;
            _baseType = baseType;
        }

        // --- Interface methods ----

        override public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { return _baseType; } }
        override public bool IsArray { get { return _isArray; } }
        override public bool IsCollection { get { return (CollectionAdd != null); } }
        override public bool IsConstructible { get { return (Activator != null); } }
        override public bool IsDictionary { get { return (DictionaryAdd != null); } }
        override public bool IsMarkupExtension { get { return _isMarkupExtension; } }
        override public bool IsBindable { get { return _isBindable; } }
        override public bool IsReturnTypeStub { get { return _isReturnTypeStub; } }
        override public bool IsLocalType { get { return _isLocalType; } }

        override public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty
        {
            get { return _provider.GetMemberByLongName(_contentPropertyName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType ItemType
        {
            get { return _provider.GetXamlTypeByName(_itemTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType KeyType
        {
            get { return _provider.GetXamlTypeByName(_keyTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name)
        {
            if (_memberNames == null)
            {
                return null;
            }
            string longName;
            if (_memberNames.TryGetValue(name, out longName))
            {
                return _provider.GetMemberByLongName(longName);
            }
            return null;
        }

        override public object ActivateInstance()
        {
            return Activator(); 
        }

        override public void AddToMap(object instance, object key, object item) 
        {
            DictionaryAdd(instance, key, item);
        }

        override public void AddToVector(object instance, object item)
        {
            CollectionAdd(instance, item);
        }

        override public void RunInitializer() 
        {
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(UnderlyingType.TypeHandle);
        }

        override public object CreateFromString(string input)
        {
            if (_enumValues != null)
            {
                int value = 0;

                string[] valueParts = input.Split(',');

                foreach (string valuePart in valueParts) 
                {
                    object partValue;
                    int enumFieldValue = 0;
                    try
                    {
                        if (_enumValues.TryGetValue(valuePart.Trim(), out partValue))
                        {
                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                        }
                        else
                        {
                            try
                            {
                                enumFieldValue = global::System.Convert.ToInt32(valuePart.Trim());
                            }
                            catch( global::System.FormatException )
                            {
                                foreach( string key in _enumValues.Keys )
                                {
                                    if( string.Compare(valuePart.Trim(), key, global::System.StringComparison.OrdinalIgnoreCase) == 0 )
                                    {
                                        if( _enumValues.TryGetValue(key.Trim(), out partValue) )
                                        {
                                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        value |= enumFieldValue; 
                    }
                    catch( global::System.FormatException )
                    {
                        throw new global::System.ArgumentException(input, FullName);
                    }
                }

                return value; 
            }
            throw new global::System.ArgumentException(input, FullName);
        }

        // --- End of Interface methods

        public Activator Activator { get; set; }
        public AddToCollection CollectionAdd { get; set; }
        public AddToDictionary DictionaryAdd { get; set; }

        public void SetContentPropertyName(string contentPropertyName)
        {
            _contentPropertyName = contentPropertyName;
        }

        public void SetIsArray()
        {
            _isArray = true; 
        }

        public void SetIsMarkupExtension()
        {
            _isMarkupExtension = true;
        }

        public void SetIsBindable()
        {
            _isBindable = true;
        }

        public void SetIsReturnTypeStub()
        {
            _isReturnTypeStub = true;
        }

        public void SetIsLocalType()
        {
            _isLocalType = true;
        }

        public void SetItemTypeName(string itemTypeName)
        {
            _itemTypeName = itemTypeName;
        }

        public void SetKeyTypeName(string keyTypeName)
        {
            _keyTypeName = keyTypeName;
        }

        public void AddMemberName(string shortName)
        {
            if(_memberNames == null)
            {
                _memberNames =  new global::System.Collections.Generic.Dictionary<string,string>();
            }
            _memberNames.Add(shortName, FullName + "." + shortName);
        }

        public void AddEnumValue(string name, object value)
        {
            if (_enumValues == null)
            {
                _enumValues = new global::System.Collections.Generic.Dictionary<string, object>();
            }
            _enumValues.Add(name, value);
        }
    }

    internal delegate object Getter(object instance);
    internal delegate void Setter(object instance, object value);

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlMember : global::Windows.UI.Xaml.Markup.IXamlMember
    {
        global::BallDrive.BallDrive_XamlTypeInfo.XamlTypeInfoProvider _provider;
        string _name;
        bool _isAttachable;
        bool _isDependencyProperty;
        bool _isReadOnly;

        string _typeName;
        string _targetTypeName;

        public XamlMember(global::BallDrive.BallDrive_XamlTypeInfo.XamlTypeInfoProvider provider, string name, string typeName)
        {
            _name = name;
            _typeName = typeName;
            _provider = provider;
        }

        public string Name { get { return _name; } }

        public global::Windows.UI.Xaml.Markup.IXamlType Type
        {
            get { return _provider.GetXamlTypeByName(_typeName); }
        }

        public void SetTargetTypeName(string targetTypeName)
        {
            _targetTypeName = targetTypeName;
        }
        public global::Windows.UI.Xaml.Markup.IXamlType TargetType
        {
            get { return _provider.GetXamlTypeByName(_targetTypeName); }
        }

        public void SetIsAttachable() { _isAttachable = true; }
        public bool IsAttachable { get { return _isAttachable; } }

        public void SetIsDependencyProperty() { _isDependencyProperty = true; }
        public bool IsDependencyProperty { get { return _isDependencyProperty; } }

        public void SetIsReadOnly() { _isReadOnly = true; }
        public bool IsReadOnly { get { return _isReadOnly; } }

        public Getter Getter { get; set; }
        public object GetValue(object instance)
        {
            if (Getter != null)
                return Getter(instance);
            else
                throw new global::System.InvalidOperationException("GetValue");
        }

        public Setter Setter { get; set; }
        public void SetValue(object instance, object value)
        {
            if (Setter != null)
                Setter(instance, value);
            else
                throw new global::System.InvalidOperationException("SetValue");
        }
    }
}

