using System;
using System.Collections.Generic;
using System.Text;

namespace GangOfFourTuts.CreationalPatterns.Prototype
{
    class Prototype
    {
        /// <summary>
        /// The 'Prototype' interface
        /// </summary>
        public interface IEmployee
        {
            IEmployee Clone();
            string GetDetails();
        }

        /// <summary>
        /// A 'ConcretePrototype' class
        /// </summary>
        public class Developer : IEmployee
        {
            public int WordsPerMinute { get; set; }
            public string Name { get; set; }
            public string Role { get; set; }
            public string PreferredLanguage { get; set; }

            public IEmployee Clone()
            {
                // Shallow Copy: only top-level objects are duplicated
                return (IEmployee)MemberwiseClone();

                // Deep Copy: all objects are duplicated
                //return (IEmployee)this.Clone();
            }

            public string GetDetails()
            {
                return string.Format("{0} - {1} - {2}", Name, Role, PreferredLanguage);
            }
        }

        /// <summary>
        /// A 'ConcretePrototype' class
        /// </summary>
        public class Typist : IEmployee
        {
            public int WordsPerMinute { get; set; }
            public string Name { get; set; }
            public string Role { get; set; }

            public IEmployee Clone()
            {
                // Shallow Copy: only top-level objects are duplicated
                return (IEmployee)MemberwiseClone();

                // Deep Copy: all objects are duplicated
                //return (IEmployee)this.Clone();
            }

            public string GetDetails()
            {
                return string.Format("{0} - {1} - {2}wpm", Name, Role, WordsPerMinute);
            }
        }        
    }
}
