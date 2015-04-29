using OddEra.Bdd.Framework;

namespace OddEra.Bdd.AcceptanceTests.Personas
{
    public abstract class ExampleAppUserBase : Persona
    {
        public abstract string Username { get; }
        public abstract string Password { get; }

        public void Login(PageBase page)
        {
            this.SetCurrentPage(page);
            page.Login(Username, Password);
        }
    }
}
