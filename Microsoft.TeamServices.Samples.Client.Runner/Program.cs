﻿using System;

namespace Microsoft.TeamServices.Samples.Client.Runner
{
    /// <summary>
    /// Simple program that uses reflection to discovery/run client samples.
    /// 
    /// Arguments:
    /// 
    /// 
    /// </summary>
    public class Runner
    {

        public static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                ShowUsage();
                return 0;
            } 

            Uri connectionUrl;
            string area, resource;

            try
            {
                CheckArguments(args, out connectionUrl, out area, out resource);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }

            ClientSampleUtils.RunClientSampleMethods(connectionUrl, null, null, area, resource);            
            
            return 0;
        }
 
        private static void CheckArguments(string[] args, out Uri connectionUrl, out string area, out string resource)
        {
            try 
            {
                connectionUrl = new Uri(args[0]);
            } 
            catch (Exception)
            {
                throw new ArgumentException("Invalid URL");
            }
            
            if (args.Length > 1)
            {
                area = args[1];
                //if (!IsValidArea(area))
                //{
                //    throw new ArgumentException("Invalid area. Supported areas: {0}.", String.Join(", ", GetSupportedAreas()));     
                //}

                if (args.Length > 2)
                {
                    resource = args[2];
                //    if (!IsValidResource(area, resource)) 
                //    {
                //        throw new ArgumentException("Invalid resource. Supported resources for {0}: {1}.", area, String.Join(", ", GetSupportedAreas()));
                //    }
                }
                else
                {
                    resource = null;
                }
            }
            else
            {
                area = null;
                resource = null;
            }
        }

        private static void ShowUsage() {
            Console.WriteLine("Runs the client samples on a Team Services account or Team Foundation Server instance.");
            Console.WriteLine("");
            Console.WriteLine("!!WARNING!! Some samples are destructive. Always run on a test account or collection.");
            Console.WriteLine("");
            Console.WriteLine("Usage: Microsoft.TeamServices.Samples.Client.Runner.exe url area resource ");
            Console.WriteLine("");
            Console.WriteLine("  url        URL for the account or collection to run the samples on");
            Console.WriteLine("             Example: https://fabrikam.visualstudio.com");
            Console.WriteLine("  area       API area (e.g. build, wit, git) to run the client samples for, or specify * for all areas.");
            Console.WriteLine("  resource   API resource (e.g. definitions, workitems, repositories) to run the client samples for, or specify * for all resources.");
            Console.WriteLine("");
        }

    }

}