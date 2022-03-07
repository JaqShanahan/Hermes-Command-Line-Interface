using System;
using System.Net;
using System.Threading;
using static System.Console;
using System.Net.NetworkInformation;

namespace Hermes_ClI
{
    internal class hermescli
    {
        private IPHostEntry iphostentry;

        public void Main()
        {
            //Change console color to green
            Console.ForegroundColor = ConsoleColor.Green;
            Title = "Hermes Command Line Interface created by Jaq Shanahan";
            runMain();
        }

        public void runMain()
        {

            Typewritereffect(@"Hermes OS [Version 1.0.0]
(c) Hermes OS.All rights reserved.
Created by Jaq Shanahan

");
            string command, a, b;
            //name of the prompt, either customize the default here or change in session using the 'prompt' function
            b = "hermes> ";
        start:
            Typewritereffect(b);
            command = Console.ReadLine();
            command = command.ToLower();

            //Print function
            if (command == "print")
            {
                a = Console.ReadLine();
                Typewritereffect(a + @"
");
            }
            //Changes prompt name
            else if (command == "prompt")
            {
                b = Console.ReadLine();
            }
            //Clears command line interface
            else if (command == "clear")
            {
                Console.Clear();
                Typewritereffect(@"Hermes OS [Version 1.0.0]
(c) Hermes OS.All rights reserved.
Created by Jaq Shanahan

");
            }
            //Displays current Date and Time
            else if (command == "time")
            {
                DateTime now = DateTime.Now;
                Typewritereffect("The Date and Time is currently: " + now);
                Console.ReadLine();
            }
            //Displays Host name and Ip address
            else if (command == "ip")
            {
                String strHostName = Dns.GetHostName();

                Typewritereffect("Host Name: " + strHostName);

                // Find host by name    IPHostEntry
                iphostentry = Dns.GetHostByName(strHostName);

                // Enumerate IP addresses
                int nIP = 3;
                foreach (IPAddress ipaddress in iphostentry.AddressList)
                {
                    Typewritereffect(@"
IP " + ++nIP + ": " + ipaddress.ToString() + @"

");
                }
            }
            //Displays the physical addresses of all interfaces on the local computer
            else if (command == "mac")
            {
                IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                Console.WriteLine("Interface information for {0}.{1}     ",
                        computerProperties.HostName, computerProperties.DomainName);
                if (nics == null || nics.Length < 1)
                {
                    Typewritereffect("  No network interfaces found.");
                    return;
                }

                Console.WriteLine("  Number of interfaces .................... : {0}", nics.Length);
                foreach (NetworkInterface adapter in nics)
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties(); //  .GetIPInterfaceProperties();
                    Console.WriteLine();
                    Typewritereffect(adapter.Description);
                    Typewritereffect(String.Empty.PadLeft(adapter.Description.Length, '='));
                    Console.WriteLine("  Interface type .......................... : {0}", adapter.NetworkInterfaceType);
                    Console.Write("  Physical address ........................ : ");
                    PhysicalAddress address = adapter.GetPhysicalAddress();
                    byte[] bytes = address.GetAddressBytes();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        // Display the physical address in hexadecimal.
                        Console.Write("{0}", bytes[i].ToString("X2"));
                        // Insert a hyphen after each byte, unless we are at the end of the
                        // address.
                        if (i != bytes.Length - 1)
                        {
                            Console.Write("-");
                        }
                    }
                    Console.WriteLine();
                }
            }
            //Simple calculator program
            else if (command == "calc")
            {
                while (true)
                {
                    int num1;
                    int num2;
                    string operand;
                    ConsoleKeyInfo status;
                    float answer;

                    Console.Write("Please enter the first integer: ");
                    num1 = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Please enter an operand (+, -, /, *): ");
                    operand = Console.ReadLine();

                    Console.Write("Please enter the second integer: ");
                    num2 = Convert.ToInt32(Console.ReadLine());

                    switch (operand)
                    {

                        case "-":
                            answer = num1 - num2;
                            break;

                        case "+":
                            answer = num1 + num2;
                            break;

                        case "/":
                            answer = num1 / num2;
                            break;

                        case "*":
                            answer = num1 * num2;
                            break;

                        default:
                            answer = 0;
                            break;
                    }
                    Typewritereffect(num1.ToString() + " " + operand + " " + num2.ToString() + " = " + answer.ToString());
                    Typewritereffect("\n\n Do You Want To Break (Y/N)");
                    status = Console.ReadKey();
                    if (status.Key == ConsoleKey.Y)
                    {
                        Console.Clear();
                        Typewritereffect(@"Hermes OS [Version 1.0.0]
(c) Hermes OS.All rights reserved.
Created by Jaq Shanahan

");
                        break;
                    }
                    else if (status.Key == ConsoleKey.N)
                    {
                        Typewritereffect("ok");
                        Console.Clear();
                        Typewritereffect(@"Hermes OS [Version 1.0.0]
(c) Hermes OS.All rights reserved.
Created by Jaq Shanahan

");
                    }
                }
            }
            //Displays help functions
            else if (command == "help")
            {
                Typewritereffect(@"CALC     Starts up simple calculator program
CLEAR   Clears the Screen
IP      Displays Hostname and IP address
MAC     Displays the physical addresses of all interfaces on the local computer
PRINT   Prints Text
PROMPT  Changes the hermes command Name
TIME    Displays current date and time");
            }
            else
            {
                Typewritereffect('"' + command + '"' + @" was not a valid command
");
            }
            goto start;
        }

        //Typewriter function prints out letters one by one
        //use instead of Console.Writeline("example")
        //use Typewritereffect("example)
        public void Typewritereffect(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(15);
            }
        }
    }
}
