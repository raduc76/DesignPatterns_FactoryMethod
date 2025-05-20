using FactoryMethod.Core.Factories;
using FactoryMethod.Core.Models;
using FactoryMethod.Helpers;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddMessageProcessorFactory();
var serviceProvider = services.BuildServiceProvider();

var messageProcessorFactory = serviceProvider.GetRequiredService<IMessageProcessorFactory>();
var messageProcessor = messageProcessorFactory.CreateMessageProcessor(Constants.V1_MESSAGE_TYPE);
var message = MessageBuilder.BuildV1Message();
messageProcessor.Process(message);