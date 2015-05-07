﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.ShapeServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Shape", Namespace="http://schemas.datacontract.org/2004/07/Server.WebHost.Model")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Client.ShapeServiceReference.Circle))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Client.ShapeServiceReference.Square))]
    public partial class Shape : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Circle", Namespace="http://schemas.datacontract.org/2004/07/Server.WebHost.Model")]
    [System.SerializableAttribute()]
    public partial class Circle : Client.ShapeServiceReference.Shape {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Square", Namespace="http://schemas.datacontract.org/2004/07/Server.WebHost.Model")]
    [System.SerializableAttribute()]
    public partial class Square : Client.ShapeServiceReference.Shape {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ShapeServiceReference.IShapeService")]
    public interface IShapeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShapeService/CreateShape", ReplyAction="http://tempuri.org/IShapeService/CreateShapeResponse")]
        Client.ShapeServiceReference.Shape CreateShape(int type);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShapeService/CreateShape", ReplyAction="http://tempuri.org/IShapeService/CreateShapeResponse")]
        System.Threading.Tasks.Task<Client.ShapeServiceReference.Shape> CreateShapeAsync(int type);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IShapeServiceChannel : global::Client.ShapeServiceReference.IShapeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ShapeServiceClient : System.ServiceModel.ClientBase<global::Client.ShapeServiceReference.IShapeService>, global::Client.ShapeServiceReference.IShapeService {
        
        public ShapeServiceClient() {
        }
        
        public ShapeServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ShapeServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ShapeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ShapeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Client.ShapeServiceReference.Shape CreateShape(int type) {
            return base.Channel.CreateShape(type);
        }
        
        public System.Threading.Tasks.Task<Client.ShapeServiceReference.Shape> CreateShapeAsync(int type) {
            return base.Channel.CreateShapeAsync(type);
        }
    }
}
