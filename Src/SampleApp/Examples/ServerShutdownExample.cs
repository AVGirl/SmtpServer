﻿//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using SmtpServer;

//namespace SampleApp.Examples
//{
//    public static class ServerShutdownExample
//    {
//        public static void Run()
//        {
//            var cancellationTokenSource = new CancellationTokenSource();

//            var options = new SmtpServerOptionsBuilder()
//                .ServerName("SmtpServer SampleApp")
//                .Port(9025)
//                .MailboxFilter(new SampleMailboxFilter(TimeSpan.FromSeconds(2)))
//                .Build();

//            var server = new SmtpServer.SmtpServer(options);
//            server.SessionCreated += OnSessionCreated;
//            server.SessionCompleted += OnSessionCompleted;
//            server.SessionFaulted += OnSessionFaulted;
//            server.SessionCancelled += OnSessionCancelled;

//            var serverTask = server.StartAsync(cancellationTokenSource.Token);

//            // ReSharper disable once MethodSupportsCancellation
//            Task.Run(() => SampleMailClient.Send());

//            Console.WriteLine("Press any key to shudown the server.");
//            Console.ReadKey();

//            Console.WriteLine("Gracefully shutting down the server.");
//            server.Shutdown();

//            server.ShutdownTask.WaitWithoutException();
//            Console.WriteLine("The server is no longer accepting new connections.");

//            Console.WriteLine("Waiting for active sessions to complete.");
//            serverTask.WaitWithoutException();

//            Console.WriteLine("All active sessions are complete.");
//        }

//        static void OnSessionCreated(object sender, SessionEventArgs e)
//        {
//            Console.WriteLine("Session Created.");
//        }

//        static void OnSessionCompleted(object sender, SessionEventArgs e)
//        {
//            Console.WriteLine("Session Completed");
//        }

//        static void OnSessionFaulted(object sender, SessionFaultedEventArgs e)
//        {
//            Console.WriteLine("Session Faulted: {0}", e.Exception);
//        }

//        static void OnSessionCancelled(object sender, SessionEventArgs e)
//        {
//            Console.WriteLine("Session Cancelled");
//        }
//    }
//}