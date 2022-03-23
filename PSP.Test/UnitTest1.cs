using NUnit.Framework;
using PSP.Core;
using PSP.Service;

namespace PSP.Test
{
    public class Tests
    {

        public ProviderFactory ProviderFactory { get; set; }
        public string providerName = "ingenico";
        public string configuration = "{\"ConfigDataX\": \"Configuration 1\",\"ConfigDataY\":\"Configuration 2\"}";

        [SetUp]
        public void Setup()
        {
            ProviderFactory = new ProviderFactory();
        }

        [Test]
        public void LoadIngenico()
        {
            var provider = ProviderFactory.Get(providerName);
            Assert.IsTrue(provider.ProviderName.ToLowerInvariant().Contains(providerName));
        }


        [Test]
        public void ExecuteCommandRegister()
        {

            var command = PSPCommand.Register;
            var provider = ProviderFactory.Get(providerName);
                provider.Load(configuration);

            var operation = provider.LoadOperation(command);

            var result = operation.Execute(new ProviderRequest());
            Assert.IsTrue(result.Response.Data.Contains("Registered"));
            Assert.IsTrue(result.Response.Data.Contains("Configuration 1"));
        }
        [Test]
        public void ExecuteCommandMakePayment()
        {
            var command = PSPCommand.MakePayment;
            var provider = ProviderFactory.Get(providerName);
            provider.Load(configuration);

            var operation = provider.LoadOperation(command);

            var result = operation.Execute(new ProviderRequest());
            Assert.IsTrue(result.Response.Data.Contains("Payment"));
            Assert.IsTrue(result.Response.Data.Contains("Configuration 2"));
        }

        [Test]
        public void HandleTransactionStateComplete()
        {

            var command = PSPStateCommand.Complete;
            var provider = ProviderFactory.Get(providerName);
            provider.Load(configuration);

            var operation = provider.LoadTransactionStateHandler(command);

            var result = operation.Execute(new ProviderTransactionStateRequest());
            Assert.IsTrue(result.Response.Data.Contains("Ingenico Transaction Completed"));
            Assert.IsTrue(result.Response.Data.Contains("Configuration 2"));
        }
        [Test]
        public void HandleTransactionStateErrored()
        {
            var command = PSPStateCommand.Errored;
            var provider = ProviderFactory.Get(providerName);
            provider.Load(configuration);

            var operation = provider.LoadTransactionStateHandler(command);

            var result = operation.Execute(new ProviderTransactionStateRequest());
            Assert.IsTrue(result.Response.Data.Contains("Ingenico Transaction Errored"));
            Assert.IsTrue(result.Response.Data.Contains("Configuration 1"));
        }

        internal class ProviderRequest : IProviderRequest
        {
            public PSPStateCommand Command { get; set; }
            public PSPRequest Request { get; set; }
            public PSPResponse Response { get; set; }
            public PSPErrorContext ErrorContext { get; set; }
        }

        internal class ProviderTransactionStateRequest : IProviderTransactionState
        {
            public PSPStateCommand Command { get; set; }
            public PSPTransactionStateRequest Request { get; set; }
            public PSPTransactionStateResponse Response { get; set; }
            public PSPErrorContext ErrorContext { get; set; }
        }
    }
}