using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OddEra.Bdd.Framework
{
    public static class PersonaFactory
    {
        private static IList<Type> Personas = new List<Type>();

        public static void AddPersonaType(Type personaType)
        {
            Personas.Add(personaType);
        }

        [DebuggerStepThrough]
        public static T Create<T>() where T : Persona, new()
        {
            foreach (var persona in Personas)
            {
                if (persona.Equals(typeof(T)))
                {
                    return PersonaContext.GetUser<T>();
                }
            }

            throw new InvalidOperationException("Unable to Create Persona - Cannot Find Persona Type");
        }

        public static Persona Create(string personaName)
        {
            Persona user = PersonaContext.GetUser(personaName);

            if (user != null)
            {
                return user;
            }

            throw new InvalidOperationException("Unable to Create Persona - Cannot Find Persona Type");
        }
    }
}
