using GangOfFourTuts.CreationalPatterns.Prototype;
using GangOfFourTuts.CreationalPatterns.Singleton;
using GangOfFourTuts.StructuralPatterns.Adapter;
using GangOfFourTuts.StructuralPatterns.Bridge;
using GangOfFourTuts.StructuralPatterns.Composite;
using System;
using System.Collections.Generic;

namespace GangOfFourTuts
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Which Pattern would you like to test?\n"
                    + "1. Factory\n"
                    + "2. Abstract Factory\n"
                    + "3. Builder\n"
                    + "4. Prototype\n"
                    + "5. Singleton\n"
                    + "6. Adapter\n"
                    + "7. Bridge\n"
                    + "8. Decorator\n"
                    + "9. Facade\n"
                    + "10. FlyWeight\n"
                    + "11. Proxy\n"
                    + "12. Chain of Responsobility\n"
                    + "13. Command\n"
                    + "14. Iterator\n"
                    + "15. Mediator\n"
                    + "16. Memento\n"
                    + "17. Observer\n"
                    + "18. State\n"
                    + "19. Strategy\n"
                    + "20. Template\n"
                    + "21. Visitor\n");
                var selection = Console.ReadLine();
                Console.Clear();
                switch (selection)
                {
                    case "1":
                        RunFactory();
                        break;
                    case "2":
                        RunAbstractFactory();
                        break;
                    case "3":
                        RunBuilder();
                        break;
                    case "4":
                        RunPrototype();
                        break;
                    case "5":
                        RunSingleton();
                        break;
                    case "6":
                        RunAdapter();
                        break;
                    case "7":
                        RunBridge();
                        break;
                    case "8":
                        RunDecorator();
                        break;
                    case "9":
                        RunFacade();
                        break;
                    case "10":
                        RunFlyWeight();
                        break;
                    case "11":
                        RunProxy();
                        break;
                    case "12":
                        RunChainOfResponsibility();
                        break;
                    case "13":
                        RunCommand();
                        break;
                    case "14":
                        RunIterator();
                        break;
                    case "15":
                        RunMediator();
                        break;
                    case "16":
                        RunMemento();
                        break;
                    case "17":
                        RunObserver();
                        break;
                    case "18":
                        RunState();
                        break;
                    case "19":
                        RunStrategy();
                        break;
                    case "20":
                        RunTemplate();
                        break;
                    case "21":
                        RunVisitor();
                        break;

                    default:
                        break;
                }
                Console.Clear();
            }           
        }


        public static void RunFactory()
        {
            CreationalPatterns.Factory.VehicleFactory factory = new CreationalPatterns.Factory.ConcreteVehicleFactory();

            CreationalPatterns.Factory.IFactory scooter = factory.GetVehicle("Scooter");
            scooter.Drive(10);

            CreationalPatterns.Factory.IFactory bike = factory.GetVehicle("Bike");
            bike.Drive(20);

            Console.ReadKey();
        }

        public static void RunAbstractFactory()
        {
            CreationalPatterns.AbstractFactory.VehicleFactory honda = new CreationalPatterns.AbstractFactory.HondaFactory();
            CreationalPatterns.AbstractFactory.VehicleClient hondaclient = new CreationalPatterns.AbstractFactory.VehicleClient(honda, "Regular");

            Console.WriteLine("******* Honda **********");
            Console.WriteLine(hondaclient.GetBikeName());
            Console.WriteLine(hondaclient.GetScooterName());

            hondaclient = new CreationalPatterns.AbstractFactory.VehicleClient(honda, "Sports");
            Console.WriteLine(hondaclient.GetBikeName());
            Console.WriteLine(hondaclient.GetScooterName());

            CreationalPatterns.AbstractFactory.VehicleFactory hero = new CreationalPatterns.AbstractFactory.HeroFactory();
            CreationalPatterns.AbstractFactory.VehicleClient heroclient = new CreationalPatterns.AbstractFactory.VehicleClient(hero, "Regular");

            Console.WriteLine("******* Hero **********");
            Console.WriteLine(heroclient.GetBikeName());
            Console.WriteLine(heroclient.GetScooterName());

            heroclient = new CreationalPatterns.AbstractFactory.VehicleClient(hero, "Sports");
            Console.WriteLine(heroclient.GetBikeName());
            Console.WriteLine(heroclient.GetScooterName());

            Console.ReadKey();
        }

        public static void RunBuilder()
        {
            var vehicleCreator = new CreationalPatterns.Builder.VehicleCreator(new CreationalPatterns.Builder.HeroBuilder());
            vehicleCreator.CreateVehicle();
            var vehicle = vehicleCreator.GetVehicle();
            vehicle.ShowInfo();

            Console.WriteLine("---------------------------------------------");

            vehicleCreator = new CreationalPatterns.Builder.VehicleCreator(new CreationalPatterns.Builder.HondaBuilder());
            vehicleCreator.CreateVehicle();
            vehicle = vehicleCreator.GetVehicle();
            vehicle.ShowInfo();

            Console.ReadKey();
        }

        public static void RunPrototype()
        {
            Prototype.Developer dev = new Prototype.Developer();
            dev.Name = "Rahul";
            dev.Role = "Team Leader";
            dev.PreferredLanguage = "C#";

            Prototype.Developer devCopy = (Prototype.Developer)dev.Clone();
            devCopy.Name = "Arif"; //Not mention Role and PreferredLanguage, it will copy above

            Console.WriteLine(dev.GetDetails());
            Console.WriteLine(devCopy.GetDetails());

            Prototype.Typist typist = new Prototype.Typist();
            typist.Name = "Monu";
            typist.Role = "Typist";
            typist.WordsPerMinute = 120;

            Prototype.Typist typistCopy = (Prototype.Typist)typist.Clone();
            typistCopy.Name = "Sahil";
            typistCopy.WordsPerMinute = 115;//Not mention Role, it will copy above

            Console.WriteLine(typist.GetDetails());
            Console.WriteLine(typistCopy.GetDetails());

            Console.ReadKey();
        }

        public static void RunSingleton()
        {
            Singleton.Instance.Show();
            Singleton.Instance.Show();

            Console.ReadKey();
        }

        public static void RunAdapter()
        {
            Adapter.ITarget Itarget = new Adapter.EmployeeAdapter();
            Adapter.ThirdPartyBillingSystem client = new Adapter.ThirdPartyBillingSystem(Itarget);
            client.ShowEmployeeList();

            Console.ReadKey();
        }

        public static void RunBridge()
        {
            StructuralPatterns.Bridge.IMessageSender email = new StructuralPatterns.Bridge.EmailSender();
            StructuralPatterns.Bridge.IMessageSender queue = new StructuralPatterns.Bridge.MSMQSender();
            StructuralPatterns.Bridge.IMessageSender web = new StructuralPatterns.Bridge.WebServiceSender();

            StructuralPatterns.Bridge.Message message = new SystemMessage();
            message.Subject = "Test Message";
            message.Body = "Hi, This is a Test Message";

            message.MessageSender = email;
            message.Send();

            message.MessageSender = queue;
            message.Send();

            message.MessageSender = web;
            message.Send();

            StructuralPatterns.Bridge.UserMessage usermsg = new StructuralPatterns.Bridge.UserMessage();
            usermsg.Subject = "Test Message";
            usermsg.Body = "Hi, This is a Test Message";
            usermsg.UserComments = "I hope you are well";

            usermsg.MessageSender = email;
            usermsg.Send();

            Console.ReadKey();
        }

        public static void RunComposite()
        {
            StructuralPatterns.Composite.Employee Rahul = new StructuralPatterns.Composite.Employee { EmpID = 1, Name = "Rahul" };

            StructuralPatterns.Composite.Employee Amit = new StructuralPatterns.Composite.Employee { EmpID = 2, Name = "Amit" };
            StructuralPatterns.Composite.Employee Mohan = new StructuralPatterns.Composite.Employee { EmpID = 3, Name = "Mohan" };

            Rahul.AddSubordinate(Amit);
            Rahul.AddSubordinate(Mohan);

            StructuralPatterns.Composite.Employee Rita = new StructuralPatterns.Composite.Employee { EmpID = 4, Name = "Rita" };
            StructuralPatterns.Composite.Employee Hari = new StructuralPatterns.Composite.Employee { EmpID = 5, Name = "Hari" };

            Amit.AddSubordinate(Rita);
            Amit.AddSubordinate(Hari);

            StructuralPatterns.Composite.Employee Kamal = new StructuralPatterns.Composite.Employee { EmpID = 6, Name = "Kamal" };
            StructuralPatterns.Composite.Employee Raj = new StructuralPatterns.Composite.Employee { EmpID = 7, Name = "Raj" };

            StructuralPatterns.Composite.Contractor Sam = new StructuralPatterns.Composite.Contractor { EmpID = 8, Name = "Sam" };
            StructuralPatterns.Composite.Contractor tim = new StructuralPatterns.Composite.Contractor { EmpID = 9, Name = "Tim" };

            Mohan.AddSubordinate(Kamal);
            Mohan.AddSubordinate(Raj);
            Mohan.AddSubordinate(Sam);
            Mohan.AddSubordinate(tim);

            Console.WriteLine("EmpID={0}, Name={1}", Rahul.EmpID, Rahul.Name);

            foreach (Employee manager in Rahul)
            {
                Console.WriteLine("\n EmpID={0}, Name={1}", manager.EmpID, manager.Name);

                foreach (var employee in manager)
                {
                    Console.WriteLine(" \t EmpID={0}, Name={1}", employee.EmpID, employee.Name);
                }
            }
            Console.ReadKey();
        }

        public static void RunDecorator()
        {
            // Basic vehicle
            GangOfFourTuts.StructuralPatterns.Decorator.HondaCity car = new GangOfFourTuts.StructuralPatterns.Decorator.HondaCity();
            Console.WriteLine("Honda City base price are : {0}", car.Price);

            // Special offer
            GangOfFourTuts.StructuralPatterns.Decorator.SpecialOffer offer = new GangOfFourTuts.StructuralPatterns.Decorator.SpecialOffer(car);
            offer.DiscountPercentage = 25;
            offer.Offer = "25 % discount";

            Console.WriteLine("{1} @ Diwali Special Offer and price are : {0} ", offer.Price, offer.Offer);
            Console.ReadKey();
        }

        public static void RunFacade()
        {
            GangOfFourTuts.StructuralPatterns.Facade.CarFacade facade = new GangOfFourTuts.StructuralPatterns.Facade.CarFacade();
            facade.CreateCompleteCar();
            Console.ReadKey();
        }

        public static void RunFlyWeight()
        {
            StructuralPatterns.FlyWeight.ShapeObjectFactory sof = new StructuralPatterns.FlyWeight.ShapeObjectFactory();

            StructuralPatterns.FlyWeight.IShape shape = sof.GetShape("Rectangle");
            shape.Print();
            shape = sof.GetShape("Rectangle");
            shape.Print();
            shape = sof.GetShape("Rectangle");
            shape.Print();

            shape = sof.GetShape("Circle");
            shape.Print();
            shape = sof.GetShape("Circle");
            shape.Print();
            shape = sof.GetShape("Circle");
            shape.Print();

            int NumObjs = sof.TotalObjectsCreated;
            Console.WriteLine("\nTotal No of Objects created = {0}", NumObjs);
            Console.ReadKey();
        }

        public static void RunProxy()
        {
            StructuralPatterns.Proxy.ProxyClient proxy = new StructuralPatterns.Proxy.ProxyClient();
            Console.WriteLine("Data from Proxy Client = {0}", proxy.GetData());

            Console.ReadKey();
        }

        public static void RunChainOfResponsibility()
        {
            // Setup Chain of Responsibility
            BehaviouralPatterns.ChainOfResponsibility.Approver rohit = new BehaviouralPatterns.ChainOfResponsibility.Clerk();
            BehaviouralPatterns.ChainOfResponsibility.Approver rahul = new BehaviouralPatterns.ChainOfResponsibility.AssistantManager();
            BehaviouralPatterns.ChainOfResponsibility.Approver manoj = new BehaviouralPatterns.ChainOfResponsibility.Manager();

            rohit.Successor = rahul;
            rahul.Successor = manoj;

            // Generate and process loan requests
            var loan = new BehaviouralPatterns.ChainOfResponsibility.Loan { Number = 2034, Amount = 24000.00, Purpose = "Laptop Loan" };
            rohit.ProcessRequest(loan);

            loan = new BehaviouralPatterns.ChainOfResponsibility.Loan { Number = 2035, Amount = 42000.10, Purpose = "Bike Loan" };
            rohit.ProcessRequest(loan);

            loan = new BehaviouralPatterns.ChainOfResponsibility.Loan { Number = 2036, Amount = 156200.00, Purpose = "House Loan" };
            rohit.ProcessRequest(loan);

            // Wait for user
            Console.ReadKey();
        }

        public static void RunCommand()
        {
            Console.WriteLine("Enter Commands (ON/OFF) : ");
            string cmd = Console.ReadLine();

            BehaviouralPatterns.Command.Light lamp = new BehaviouralPatterns.Command.Light();
            BehaviouralPatterns.Command.ICommand switchUp = new BehaviouralPatterns.Command.FlipUpCommand(lamp);
            BehaviouralPatterns.Command.ICommand switchDown = new BehaviouralPatterns.Command.FlipDownCommand(lamp);

            BehaviouralPatterns.Command.Switch s = new BehaviouralPatterns.Command.Switch();

            if (cmd == "ON")
            {
                s.StoreAndExecute(switchUp);
            }
            else if (cmd == "OFF")
            {
                s.StoreAndExecute(switchDown);
            }
            else
            {
                Console.WriteLine("Command \"ON\" or \"OFF\" is required.");
            }

            Console.ReadKey();
        }

        public static void RunIterator()
        {
            BehaviouralPatterns.Iterator.Client client = new BehaviouralPatterns.Iterator.Client();
            client.UseIterator();
            Console.ReadKey();
        }

        public static void RunMediator()
        {
            BehavioralPatterns.Mediator.IChatMediator chatMediator = new BehavioralPatterns.Mediator.ChatMediator();
            // create users and add them to chat mediator's user list
            BehavioralPatterns.Mediator.IUser john = new BehavioralPatterns.Mediator.BasicUser(chatMediator, "John");
            BehavioralPatterns.Mediator.IUser tina = new BehavioralPatterns.Mediator.PremiumUser(chatMediator, "Tina");
            BehavioralPatterns.Mediator.IUser lara = new BehavioralPatterns.Mediator.PremiumUser(chatMediator, "Lara");
            chatMediator.AddUser(john);
            chatMediator.AddUser(tina);
            chatMediator.AddUser(lara);
            // send message
            lara.SendMessage("Hello Everyone!");
            Console.ReadLine();
        }

        public static void RunMemento()
        {
            BehaviouralPatterns.Memento.Originator originator = new BehaviouralPatterns.Memento.Originator("Super-duper-super-puper-super.");
            BehaviouralPatterns.Memento.Caretaker caretaker = new BehaviouralPatterns.Memento.Caretaker(originator);

                caretaker.backup();
                originator.doSomething();

                caretaker.backup();
                originator.doSomething();

                caretaker.backup();
                originator.doSomething();

                Console.WriteLine();
                caretaker.showHistory();

                Console.Write("\nClient: Now, let's rollback!\n\n");
                caretaker.undo();

                Console.Write("\n\nClient: Once more!\n\n");
                caretaker.undo();

                Console.WriteLine();
                Console.ReadKey();
        }

        public static void RunObserver()
        {
            var subj = new BehaviouralPatterns.Observer.Subject();
            var o1 = new BehaviouralPatterns.Observer.ConcreteObserverA();
            subj.attach(o1);

            var o2 = new BehaviouralPatterns.Observer.ConcreteObserverB();
            subj.attach(o2);

            subj.someBusinessLogic();
            subj.detach(o1);
            subj.someBusinessLogic();
            Console.ReadKey();
        }

        public static void RunState()
        {
            var context = new BehaviouralPatterns.State.Context(new BehaviouralPatterns.State.ConcreteStateA());
            context.request1();
            context.request2();
            Console.ReadKey();
        }

        public static void RunStrategy()
        {
            var context = new BehaviouralPatterns.Strategy.Context();

            Console.Write("Client: Strategy is set to normal sorting.\n");
            context.setStrategy(new BehaviouralPatterns.Strategy.ConcreteStrategyA());
            context.doSomeBusinessLogic();
            Console.Write("\n");
            Console.Write("Client: Strategy is set to reverse sorting.\n");
            context.setStrategy(new BehaviouralPatterns.Strategy.ConcreteStrategyB());
            context.doSomeBusinessLogic();

            Console.Write("\n");
            Console.ReadKey();
        }

        public static void RunTemplate()
        {
            Console.Write("Same client code can work with different subclasses:\n");

            BehaviouralPatterns.Template.Client.ClientCode(new BehaviouralPatterns.Template.ConcreteClass1());

            Console.Write("\n");
            Console.Write("Same client code can work with different subclasses:\n");
            BehaviouralPatterns.Template.Client.ClientCode(new BehaviouralPatterns.Template.ConcreteClass2());
            Console.ReadKey();
        }

        public static void RunVisitor()
        {
            List<BehaviouralPatterns.Visitor.Component> components = new List<BehaviouralPatterns.Visitor.Component>
                {
                    new BehaviouralPatterns.Visitor.ConcreteComponentA(),
                    new BehaviouralPatterns.Visitor.ConcreteComponentB()
                };

            Console.Write("The client code works with all visitors via the base Visitor interface:\n");
            var visitor1 = new BehaviouralPatterns.Visitor.ConcreteVisitor1();
            BehaviouralPatterns.Visitor.Client.ClientCode(components, visitor1);

            Console.WriteLine();

            Console.Write("It allows the same client code to work with different types of visitors:\n");
            var visitor2 = new BehaviouralPatterns.Visitor.ConcreteVisitor2();
            BehaviouralPatterns.Visitor.Client.ClientCode(components, visitor2);
            Console.ReadKey();
        }
    }
}
