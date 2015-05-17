using OddEra.Bdd.AcceptanceTests.Personas;
using OddEra.Bdd.Framework;
using System;
using TechTalk.SpecFlow;

namespace OddEra.Bdd.AcceptanceTests.StepDefinitions.Base
{
    public class StepDefinitionBase
    {
        public StepDefinitionBase()
        {
            AppDomain.CurrentDomain.DomainUnload += (object sender, EventArgs e) => CloseBrowsers();
        }

        public void SetCurrentPersona(string personaName)
        {
            ScenarioContext.Current.Add("User", (ExampleAppUserBase)PersonaContext.GetUser(personaName));
        }

        protected static ExampleAppUserBase User { get { return ScenarioContext.Current.Get<ExampleAppUserBase>("User"); } }

        public static void CloseBrowsers()
        {
            PersonaContext.CloseBrowsers();
        }
    }
}