using Objectivity.Bot.Tests.Stories.Recorder;
using Objectivity.Bot.Tests.Stories.Xunit;
using SimpleEchoBot.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{    
    public class UserDataDialogTests: DialogUnitTestBase<UserDataDialog>
    {
        [Fact]
        public async void Test0()
        {
            var story = StoryRecorder.Record()
                .User.Says("Hello")
                .Bot.Says("Hi what's your name?")
                .User.Says("Adrian")
                .Bot.Says("Hi Adrian")
                .Bot.Says("How old are you Adrian?")
                .User.Says("123")
                .Bot.Says("You are 123 years old.")
                .Bot.Says("Are you a .NET Developer?")
                .User.Says("Yes")
                .Bot.Says("You are.NET Developer")
                .Rewind();

            await this.Play(story);
        }
    }
}
