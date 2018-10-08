using System;
using System.Collections.Generic;
using System.Text;

namespace GangOfFourTuts.BehaviouralPatterns.Visitor
{
        interface Component
        {
            void accept(Visitor visitor);
        }

        public class ConcreteComponentA : Component
        {
            public void accept(Visitor visitor)
            {
                visitor.visitConcreteComponentA(this);
            }

            public string exclusiveMethodOfConcreteComponentA()
            {
                return "A";
            }
        }

        public class ConcreteComponentB : Component
        {
            public void accept(Visitor visitor)
            {
                visitor.visitConcreteComponentB(this);
            }

            public string specialMethodOfConcreteComponentB()
            {
                return "B";
            }
        }

        public interface Visitor
        {
            void visitConcreteComponentA(ConcreteComponentA el);

            void visitConcreteComponentB(ConcreteComponentB el);
        }

        class ConcreteVisitor1 : Visitor
        {
            public void visitConcreteComponentA(ConcreteComponentA el)
            {
                Console.Write(el.exclusiveMethodOfConcreteComponentA() + " + ConcreteVisitor1\n");
            }

            public void visitConcreteComponentB(ConcreteComponentB el)
            {
                Console.Write(el.specialMethodOfConcreteComponentB() + " + ConcreteVisitor1\n");
            }
        }

        class ConcreteVisitor2 : Visitor
        {
            public void visitConcreteComponentA(ConcreteComponentA el)
            {
                Console.Write(el.exclusiveMethodOfConcreteComponentA() + " + ConcreteVisitor2\n");
            }

            public void visitConcreteComponentB(ConcreteComponentB el)
            {
                Console.Write(el.specialMethodOfConcreteComponentB() + " + ConcreteVisitor2\n");
            }
        }

        internal class Client
        {
            internal static void ClientCode(List<Component> components, Visitor visitor)
            {
                foreach (var component in components)
                {
                    component.accept(visitor);
                }
            }
        }
    }
