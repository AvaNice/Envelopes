using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envelopes
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            logger.Info(new string('-', 50));

            StartWithParams(args);

            ShowUserMenu();
        }
        private static void StartWithParams(string[] args)
        {
            try
            {
                double FirstAB = Convert.ToInt32(args[0]);
                double FirstCD = Convert.ToInt32(args[1]);
                double SecondAB = Convert.ToInt32(args[2]);
                double SecondCD = Convert.ToInt32(args[3]);

                OutputEnvelopeCompare(new Envelope(FirstAB, FirstCD)
                    , new Envelope(SecondAB, SecondCD));
            }
            catch
            {
                logger.Error("Can't read args");
                Console.WriteLine(TextMessages.HELP);
            }
        }
        private static void ShowUserMenu()
        {
            string userMode = Console.ReadLine().ToLower();
            switch (userMode)
            {
                case TextMessages.START_MODE:

                case TextMessages.START_MODE_SECOND:
                    OutputEnvelopeCompare(BuildEnvelope(), BuildEnvelope());
                    break;

                case TextMessages.EXIT_MODE:
                    logger.Info("Exit");
                    Process.GetCurrentProcess().Kill();
                    break;

                default:
                    Console.WriteLine(TextMessages.HELP);
                    logger.Trace($"Default in GetUserMode userMode input = ({userMode})");
                    break;
            }
            ShowUserMenu();
        }
        private static double GetUserParameter(string parameterName)
        {
            double parameterValue = 0;
            string input = string.Empty;

            Console.Write($"{parameterName} = ");

            input = Console.ReadLine();

            try
            {
                parameterValue = Convert.ToDouble(input);

                logger.Trace($"User enter {parameterName} = {parameterValue}");

                return parameterValue;
            }
            catch
            {
                Console.WriteLine(TextMessages.INCORRECT_INPUT);

                logger.Error($"Incorrect Input of {parameterName} - {input}");
            }

            return GetUserParameter(parameterName);
        }
        private static Envelope BuildEnvelope()
        {
            double aBSide;
            double cDSide;

            aBSide = GetUserParameter(TextMessages.GET_AB);
            cDSide = GetUserParameter(TextMessages.GET_CD);

            return new Envelope(aBSide, cDSide);
        }

        private static void OutputEnvelopeCompare(Envelope first, Envelope second)
        {
           // Console.WriteLine(Envelope.CanBeInvested(first, second));
            if (Envelope.CanBeInvested(first, second))
            {
                Console.WriteLine(TextMessages.SECOND_ENVELOPE_IN);
                
            }
            else if (Envelope.CanBeInvested(second, first))
            {
                Console.WriteLine(TextMessages.FIRST_ENVELOPE_IN);
            }
            else
            {
                Console.WriteLine(TextMessages.CANT_BE_PLACED);
            }
        }
    }
}
