using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GangOfFourTuts.BehaviouralPatterns.Observer
{
        public interface SplObserver
        {
            void update(SplSubject subject);
        }

        public interface SplSubject
        {
            void attach(SplObserver observer);

            void detach(SplObserver observer);

            void notify();
        }

        public class Subject : SplSubject
        {
            public int State { get; set; } = -0;

            private List<SplObserver> _observers = new List<SplObserver>();

            public void attach(SplObserver observer)
            {
                Console.Write("Subject: Attached an observer.\n");
                this._observers.Add(observer);
            }

            public void detach(SplObserver observer)
            {
                foreach (var elem in _observers)
                {
                    if (elem == observer)
                    {
                        _observers.Remove(observer);
                        Console.Write("Subject: Detached an observer.\n");
                        break;
                    }
                }
            }

            public void notify()
            {
                Console.Write("Subject: Notifying observers...\n");

                foreach (var observer in _observers)
                {
                    observer.update(this);
                }
            }

            public void someBusinessLogic()
            {
                Console.Write("\nSubject: I'm doing something important.\n");
                this.State = this.State+2;

                Thread.Sleep(2);

                Console.Write("Subject: My state has just changed to: " + this.State + "\n");
                this.notify();
            }
        }

        class ConcreteObserverA : SplObserver
        {
            public void update(SplSubject subject)
            {
                if (!(subject is Subject))
                {
                    return;
                }

                if ((subject as Subject).State < 3)
                {
                    Console.Write("ConcreteObserverA: Reacted to the event.\n");
                }
            }
        }

        class ConcreteObserverB : SplObserver
        {
            public void update(SplSubject subject)
            {
                if (!(subject is Subject))
                {
                    return;
                }

                if ((subject as Subject).State == 0 || (subject as Subject).State >= 2)
                {
                    Console.Write("ConcreteObserverB: Reacted to the event.\n");
                }
            }
        }

            
    }
