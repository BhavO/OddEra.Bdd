using TechTalk.SpecFlow;
using OddEra.Bdd.AcceptanceTests.Pages;
using OddEra.Bdd.AcceptanceTests.Personas;
using OddEra.Bdd.AcceptanceTests.StepDefinitions.Base;
using FluentAssertions;

namespace OddEra.Bdd.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class AccessingApp : StepDefinitionBase
    {
        [Given(@"that (.*) does not have a subscription to the ExampleApp service")]
        public void GivenThatUserDoesNotHaveASubscriptionToTheExampleAppService(string personaName)
        {
            SetCurrentPersona(personaName);
        }

        [Given(@"that (.*) does have a subscription to the ExampleApp service")]
        public void GivenThatUserDoesHaveASubscriptionToTheExampleAppService(string personaName)
        {
            SetCurrentPersona(personaName);
        }

        [When(@"(.*) logs in to the App")]
        public void WhenLogsInToThePortal(string personaName)
        {
            User.Login(new ExampleAppHomePage());
            User.OnPage<ExampleAppHomePage>();
        }

        [Then(@"(.*) will see the ExampleApp admin console on the menu")]
        public void ThenDavidWillSeeTheExampleAppAdminConsoleOnTheMenu(string personaName)
        {
            User.OnPage<ExampleAppHomePage>().HasText(ExampleAppConstants.ExampleAppMenuTitle).Should().BeTrue();
        }

        [Then(@"(.*) will not see any reference to the ExampleApp admin console on the menu")]
        public void ThenDavidWillNotSeeAnyReferenceToTheExampleAppAdminConsoleOnTheMenu(string personaName)
        {
            User.OnPage<ExampleAppHomePage>().HasText(ExampleAppConstants.ExampleAppMenuTitle).Should().BeFalse();
        }
    }
}