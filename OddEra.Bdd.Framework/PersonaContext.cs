using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OddEra.Bdd.Framework
{
    public static class PersonaContext
    {
        private static IList<Persona> Users = new List<Persona>();

        public static T GetUser<T>() where T : Persona, new()
        {
            T userToReturn = default(T);

            foreach (var item in Users)
            {
                if (item is T)
                {
                    userToReturn = item as T;
                }
            }

            if (userToReturn == null)
            {
                userToReturn = new T();
                Users.Add(userToReturn);
            }

            return (T)userToReturn;
        }

        public static Persona GetUser(string personaType)
        {
            Persona userToReturn = null;

            foreach (var user in Users)
            {
                if (user.GetType().Name.ToLower().Contains(personaType.ToLower()))
                {
                    userToReturn = user;
                }
            }

            if (userToReturn == null)
            {
                var userType = Assembly.GetExecutingAssembly().GetTypes().First(i => i.Name == personaType);
                userToReturn = (Persona)Activator.CreateInstance(userType, null, null);
                Users.Add(userToReturn);
            }

            return (Persona)userToReturn;
        }

        public static void CloseBrowsers()
        {
            foreach (var user in Users)
            {
                user.CloseBrowser();
            }        
        }
    }
}
