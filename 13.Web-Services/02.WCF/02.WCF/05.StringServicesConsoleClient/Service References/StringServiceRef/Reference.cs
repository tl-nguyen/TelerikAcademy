﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _05.StringServicesConsoleClient.StringServiceRef {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="StringServiceRef.IStringServices")]
    public interface IStringServices {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStringServices/OccurencesCount", ReplyAction="http://tempuri.org/IStringServices/OccurencesCountResponse")]
        int OccurencesCount(string first, string second);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStringServices/OccurencesCount", ReplyAction="http://tempuri.org/IStringServices/OccurencesCountResponse")]
        System.Threading.Tasks.Task<int> OccurencesCountAsync(string first, string second);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStringServicesChannel : _05.StringServicesConsoleClient.StringServiceRef.IStringServices, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StringServicesClient : System.ServiceModel.ClientBase<_05.StringServicesConsoleClient.StringServiceRef.IStringServices>, _05.StringServicesConsoleClient.StringServiceRef.IStringServices {
        
        public StringServicesClient() {
        }
        
        public StringServicesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public StringServicesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StringServicesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StringServicesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int OccurencesCount(string first, string second) {
            return base.Channel.OccurencesCount(first, second);
        }
        
        public System.Threading.Tasks.Task<int> OccurencesCountAsync(string first, string second) {
            return base.Channel.OccurencesCountAsync(first, second);
        }
    }
}
