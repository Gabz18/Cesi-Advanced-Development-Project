﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientNoSecure.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="STG", Namespace="http://schemas.datacontract.org/2004/07/WCF_Contract")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(object[]))]
    public partial class STG : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AppVersionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object[] DataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string InfoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OperationNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OperationVersionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool StatutOPField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TokenAppField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TokenUserField;
        
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
        public string AppVersion {
            get {
                return this.AppVersionField;
            }
            set {
                if ((object.ReferenceEquals(this.AppVersionField, value) != true)) {
                    this.AppVersionField = value;
                    this.RaisePropertyChanged("AppVersion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object[] Data {
            get {
                return this.DataField;
            }
            set {
                if ((object.ReferenceEquals(this.DataField, value) != true)) {
                    this.DataField = value;
                    this.RaisePropertyChanged("Data");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Info {
            get {
                return this.InfoField;
            }
            set {
                if ((object.ReferenceEquals(this.InfoField, value) != true)) {
                    this.InfoField = value;
                    this.RaisePropertyChanged("Info");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OperationName {
            get {
                return this.OperationNameField;
            }
            set {
                if ((object.ReferenceEquals(this.OperationNameField, value) != true)) {
                    this.OperationNameField = value;
                    this.RaisePropertyChanged("OperationName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OperationVersion {
            get {
                return this.OperationVersionField;
            }
            set {
                if ((object.ReferenceEquals(this.OperationVersionField, value) != true)) {
                    this.OperationVersionField = value;
                    this.RaisePropertyChanged("OperationVersion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool StatutOP {
            get {
                return this.StatutOPField;
            }
            set {
                if ((this.StatutOPField.Equals(value) != true)) {
                    this.StatutOPField = value;
                    this.RaisePropertyChanged("StatutOP");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TokenApp {
            get {
                return this.TokenAppField;
            }
            set {
                if ((object.ReferenceEquals(this.TokenAppField, value) != true)) {
                    this.TokenAppField = value;
                    this.RaisePropertyChanged("TokenApp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TokenUser {
            get {
                return this.TokenUserField;
            }
            set {
                if ((object.ReferenceEquals(this.TokenUserField, value) != true)) {
                    this.TokenUserField = value;
                    this.RaisePropertyChanged("TokenUser");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/m_service", ReplyAction="http://tempuri.org/IService1/m_serviceResponse")]
        ClientNoSecure.ServiceReference1.STG m_service(ClientNoSecure.ServiceReference1.STG msg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/m_service", ReplyAction="http://tempuri.org/IService1/m_serviceResponse")]
        System.Threading.Tasks.Task<ClientNoSecure.ServiceReference1.STG> m_serviceAsync(ClientNoSecure.ServiceReference1.STG msg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/testConcurrencyWithTPL", ReplyAction="http://tempuri.org/IService1/testConcurrencyWithTPLResponse")]
        void testConcurrencyWithTPL();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/testConcurrencyWithTPL", ReplyAction="http://tempuri.org/IService1/testConcurrencyWithTPLResponse")]
        System.Threading.Tasks.Task testConcurrencyWithTPLAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : ClientNoSecure.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<ClientNoSecure.ServiceReference1.IService1>, ClientNoSecure.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ClientNoSecure.ServiceReference1.STG m_service(ClientNoSecure.ServiceReference1.STG msg) {
            return base.Channel.m_service(msg);
        }
        
        public System.Threading.Tasks.Task<ClientNoSecure.ServiceReference1.STG> m_serviceAsync(ClientNoSecure.ServiceReference1.STG msg) {
            return base.Channel.m_serviceAsync(msg);
        }
        
        public void testConcurrencyWithTPL() {
            base.Channel.testConcurrencyWithTPL();
        }
        
        public System.Threading.Tasks.Task testConcurrencyWithTPLAsync() {
            return base.Channel.testConcurrencyWithTPLAsync();
        }
    }
}
