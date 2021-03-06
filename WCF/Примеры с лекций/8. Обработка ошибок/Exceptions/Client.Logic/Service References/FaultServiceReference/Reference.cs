﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.Logic.FaultServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GetDataFault", Namespace="http://schemas.datacontract.org/2004/07/Server.Logic")]
    [System.SerializableAttribute()]
    public partial class GetDataFault : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DataField;
        
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
        public string Data {
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
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FaultServiceReference.IFaultService")]
    public interface IFaultService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFaultService/GetData", ReplyAction="http://tempuri.org/IFaultService/GetDataResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Client.Logic.FaultServiceReference.GetDataFault), Action="http://tempuri.org/IFaultService/GetDataGetDataFaultFault", Name="GetDataFault", Namespace="http://schemas.datacontract.org/2004/07/Server.Logic")]
        string GetData();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFaultService/GetData", ReplyAction="http://tempuri.org/IFaultService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFaultServiceChannel : global::Client.Logic.FaultServiceReference.IFaultService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FaultServiceClient : System.ServiceModel.ClientBase<global::Client.Logic.FaultServiceReference.IFaultService>, global::Client.Logic.FaultServiceReference.IFaultService {
        
        public FaultServiceClient() {
        }
        
        public FaultServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FaultServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FaultServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FaultServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData() {
            return base.Channel.GetData();
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync() {
            return base.Channel.GetDataAsync();
        }
    }
}
