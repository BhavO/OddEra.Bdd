using OddEra.Bdd.AcceptanceTests.Personas;
using OddEra.Bdd.Framework;
using TechTalk.SpecFlow;

namespace OddEra.Bdd.AcceptanceTests.StepDefinitions.Base
{
    public class StepDefinitionBase
    {
        public StepDefinitionBase()
        {
            PersonaFactory.AddPersonaType(typeof(David));
            PersonaFactory.AddPersonaType(typeof(John));
        }

        public void SetCurrentPersona(string personaName)
        {
            ScenarioContext.Current.Add("User", (ExampleAppUserBase)PersonaFactory.Create(personaName));
        }

        protected static ExampleAppUserBase User { get { return ScenarioContext.Current.Get<ExampleAppUserBase>("User"); } }

        [AfterFeature]
        public static void CloseBrowser()
        {
            User.CloseBrowser();
        }
    }
}