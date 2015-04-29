using System;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace OddEra.Bdd.Framework
{
    public static class PersonaContext
    {
        private static ArrayList Users = new ArrayList();

        public static T GetUser<T>() where T : class, new()
        {
            var users = Users;
            T userToReturn = default(T);

            foreach (var item in users)
            {
                if (item is T)
                {
                    userToReturn = item as T;
                }
            }

            if (userToReturn == null)
            {
                userToReturn = new T();
                users.Add(userToReturn);
            }

            return (T)userToReturn;
        }

        public static Persona GetUser(string personaType)
        {
            var users = Users;
            Persona userToReturn = null;

            foreach (var user in users)
            {
                if (user.GetType().Name.ToLower().Contains(personaType.ToLower()))
                {
                    userToReturn = user as Persona;
                }
            }

            if (userToReturn == null)
            {
                var userType = Assembly.GetExecutingAssembly().GetTypes().First(i => i.Name == personaType);
                userToReturn = (Persona)Activator.CreateInstance(userType, null, null);
                users.Add(userToReturn);
            }

            return (Persona)userToReturn;
        }
    }
}
