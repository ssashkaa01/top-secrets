﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPF_TopSecrets.ServiceTopSecrets {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SecretData", Namespace="http://schemas.datacontract.org/2004/07/WCF_TopSecrets")]
    [System.SerializableAttribute()]
    public partial class SecretData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LoginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UrlField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Login {
            get {
                return this.LoginField;
            }
            set {
                if ((object.ReferenceEquals(this.LoginField, value) != true)) {
                    this.LoginField = value;
                    this.RaisePropertyChanged("Login");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Url {
            get {
                return this.UrlField;
            }
            set {
                if ((object.ReferenceEquals(this.UrlField, value) != true)) {
                    this.UrlField = value;
                    this.RaisePropertyChanged("Url");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceTopSecrets.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Login", ReplyAction="http://tempuri.org/IService/LoginResponse")]
        string Login([System.ServiceModel.MessageParameterAttribute(Name="login")] string login1, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Login", ReplyAction="http://tempuri.org/IService/LoginResponse")]
        System.Threading.Tasks.Task<string> LoginAsync(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Register", ReplyAction="http://tempuri.org/IService/RegisterResponse")]
        bool Register(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Register", ReplyAction="http://tempuri.org/IService/RegisterResponse")]
        System.Threading.Tasks.Task<bool> RegisterAsync(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Logout", ReplyAction="http://tempuri.org/IService/LogoutResponse")]
        bool Logout(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Logout", ReplyAction="http://tempuri.org/IService/LogoutResponse")]
        System.Threading.Tasks.Task<bool> LogoutAsync(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddSecretData", ReplyAction="http://tempuri.org/IService/AddSecretDataResponse")]
        bool AddSecretData(string token, WPF_TopSecrets.ServiceTopSecrets.SecretData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddSecretData", ReplyAction="http://tempuri.org/IService/AddSecretDataResponse")]
        System.Threading.Tasks.Task<bool> AddSecretDataAsync(string token, WPF_TopSecrets.ServiceTopSecrets.SecretData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeleteSecretData", ReplyAction="http://tempuri.org/IService/DeleteSecretDataResponse")]
        bool DeleteSecretData(string token, int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeleteSecretData", ReplyAction="http://tempuri.org/IService/DeleteSecretDataResponse")]
        System.Threading.Tasks.Task<bool> DeleteSecretDataAsync(string token, int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAllSecretData", ReplyAction="http://tempuri.org/IService/GetAllSecretDataResponse")]
        WPF_TopSecrets.ServiceTopSecrets.SecretData[] GetAllSecretData(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAllSecretData", ReplyAction="http://tempuri.org/IService/GetAllSecretDataResponse")]
        System.Threading.Tasks.Task<WPF_TopSecrets.ServiceTopSecrets.SecretData[]> GetAllSecretDataAsync(string token);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : WPF_TopSecrets.ServiceTopSecrets.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<WPF_TopSecrets.ServiceTopSecrets.IService>, WPF_TopSecrets.ServiceTopSecrets.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Login(string login1, string password) {
            return base.Channel.Login(login1, password);
        }
        
        public System.Threading.Tasks.Task<string> LoginAsync(string login, string password) {
            return base.Channel.LoginAsync(login, password);
        }
        
        public bool Register(string login, string password) {
            return base.Channel.Register(login, password);
        }
        
        public System.Threading.Tasks.Task<bool> RegisterAsync(string login, string password) {
            return base.Channel.RegisterAsync(login, password);
        }
        
        public bool Logout(string token) {
            return base.Channel.Logout(token);
        }
        
        public System.Threading.Tasks.Task<bool> LogoutAsync(string token) {
            return base.Channel.LogoutAsync(token);
        }
        
        public bool AddSecretData(string token, WPF_TopSecrets.ServiceTopSecrets.SecretData data) {
            return base.Channel.AddSecretData(token, data);
        }
        
        public System.Threading.Tasks.Task<bool> AddSecretDataAsync(string token, WPF_TopSecrets.ServiceTopSecrets.SecretData data) {
            return base.Channel.AddSecretDataAsync(token, data);
        }
        
        public bool DeleteSecretData(string token, int id) {
            return base.Channel.DeleteSecretData(token, id);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteSecretDataAsync(string token, int id) {
            return base.Channel.DeleteSecretDataAsync(token, id);
        }
        
        public WPF_TopSecrets.ServiceTopSecrets.SecretData[] GetAllSecretData(string token) {
            return base.Channel.GetAllSecretData(token);
        }
        
        public System.Threading.Tasks.Task<WPF_TopSecrets.ServiceTopSecrets.SecretData[]> GetAllSecretDataAsync(string token) {
            return base.Channel.GetAllSecretDataAsync(token);
        }
    }
}
