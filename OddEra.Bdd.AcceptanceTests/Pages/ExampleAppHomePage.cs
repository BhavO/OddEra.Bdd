using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OddEra.Bdd.Framework;
using System.Configuration;

namespace OddEra.Bdd.AcceptanceTests.Pages
{
    public class ExampleAppHomePage : ExampleAppPageBase
    {
        protected override string Title
        {
            get { return "Home"; }
        }
    }
}
