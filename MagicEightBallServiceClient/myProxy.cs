﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IEightBall")]
public interface IEightBall
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEightBall/ObtainAnswerToQuestion", ReplyAction="http://tempuri.org/IEightBall/ObtainAnswerToQuestionResponse")]
    string ObtainAnswerToQuestion(string question);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEightBall/ObtainAnswerToQuestion", ReplyAction="http://tempuri.org/IEightBall/ObtainAnswerToQuestionResponse")]
    System.Threading.Tasks.Task<string> ObtainAnswerToQuestionAsync(string question);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IEightBallChannel : IEightBall, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class EightBallClient : System.ServiceModel.ClientBase<IEightBall>, IEightBall
{
    
    public EightBallClient()
    {
    }
    
    public EightBallClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public EightBallClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public EightBallClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public EightBallClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public string ObtainAnswerToQuestion(string question)
    {
        return base.Channel.ObtainAnswerToQuestion(question);
    }
    
    public System.Threading.Tasks.Task<string> ObtainAnswerToQuestionAsync(string question)
    {
        return base.Channel.ObtainAnswerToQuestionAsync(question);
    }
}
