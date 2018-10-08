using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GangOfFourTuts.StructuralPatterns.Composite
{
    
        /// <summary>
        /// The 'Component' Treenode
        /// </summary>
        public interface IEmployed
        {
            int EmpID { get; set; }
            string Name { get; set; }
        }

        /// <summary>
        /// The 'Composite' class
        /// </summary>
        public class Employee : IEmployed, IEnumerable<IEmployed>
        {
            private List<IEmployed> _subordinates = new List<IEmployed>();

            public int EmpID { get; set; }
            public string Name { get; set; }

            public void AddSubordinate(IEmployed subordinate)
            {
                _subordinates.Add(subordinate);
            }

            public void RemoveSubordinate(IEmployed subordinate)
            {
                _subordinates.Remove(subordinate);
            }

            public IEmployed GetSubordinate(int index)
            {
                return _subordinates[index];
            }

            public IEnumerator<IEmployed> GetEnumerator()
            {
                foreach (IEmployed subordinate in _subordinates)
                {
                    yield return subordinate;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        /// <summary>
        /// The 'Leaf' class
        /// </summary>
        public class Contractor : IEmployed
        {
            public int EmpID { get; set; }
            public string Name { get; set; }
        }
}
