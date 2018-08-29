using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace SimpleEchoBot.Dialogs
{
    [Serializable]
    public class UserDataDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(HelloMessageReceivedAsync);
        }

        private async Task HelloMessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> messageAwaitable)
        {
            var message = await messageAwaitable;

            if (message.Text.ToLowerInvariant() == "hello")
            {
                await context.PostAsync($"Hi what's your name?");
                context.Wait(NameReceivedAsync);
            }
            else
            {
                await context.PostAsync("You must start with Hello");
                context.Wait(HelloMessageReceivedAsync);
            }
        }
        
        private async Task NameReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var name = (await argument).Text;

            await context.PostAsync($"Hi {name}");
            await context.PostAsync($"How old are you {name}?");

            context.Wait(AgeReceivedAsync);            
        }

        private async Task AgeReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var ageActivity = await result;
            int age = 0;
            if (int.TryParse(ageActivity.Text, out age))
            {
                await context.PostAsync($"You are {age} years old.");
                await context.PostAsync("Are you a .NET Developer?");

                context.Wait(IsDeveloperReceivedAsync);
            }
            else
            {
                await context.PostAsync($"You send wrong answer stupid: {ageActivity.Text}. What is your age?");
                context.Wait(AgeReceivedAsync);
            }
        }

        private async Task IsDeveloperReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var yesNoActivity = await result;
            var response = yesNoActivity.Text;

            if (response.ToLowerInvariant() == "yes")
            {
                await context.PostAsync($"You are .NET Developer");
            }
            else
            {
                await context.PostAsync($"You are not a .NET Developer");
            }

            context.Wait(HelloMessageReceivedAsync);
        }
    }
}