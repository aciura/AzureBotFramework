using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace SimpleEchoBot.Dialogs
{
    [Serializable]
    public class SurveyDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            PromptDialog.Text(context, TrainingNameReceivedAsync, "What was the training name?");
        }

        private async Task TrainingNameReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            PromptDialog.Choice(context, DidYouLikeReceivedAsync, 
                new[] { "Yes", "Ehh", "No" }, 
                "Did you like the training?");
        }

        private Task DidYouLikeReceivedAsync(IDialogContext context, IAwaitable<string> result)
        {
            throw new NotImplementedException();
        }
    }
}