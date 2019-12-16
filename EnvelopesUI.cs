using NLog;
using System;

namespace Envelopes
{
    class EnvelopesUI : IEnvelopesUI
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public double GetUserParameter(string parameterName)
        {
            double parameterValue = 0;
            string input = string.Empty;

            Console.Write($"{parameterName} = ");

            input = Console.ReadLine();

            try
            {
                parameterValue = Convert.ToDouble(input);

                logger.Trace($"User enter {parameterName} = {parameterValue}");

                if (parameterValue > 0)
                {
                    return parameterValue;
                }
                Console.WriteLine(TextMessages.INCORRECT_INPUT);

                return GetUserParameter(parameterName);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(TextMessages.INCORRECT_INPUT);

                logger.Error($"{ex.Message} Incorrect Input of {parameterName} - {input}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(TextMessages.INCORRECT_INPUT);

                logger.Error($"{ex.Message} Incorrect Input of {parameterName} - {input}");
            }

            return GetUserParameter(parameterName);
        }

        public bool IsOneMore()
        {
            string input;
            bool result = false;

            Console.WriteLine(TextMessages.ONE_MORE);
            input = Console.ReadLine();

            switch (input.ToLower())
            {
                case TextMessages.START_MODE:
                case TextMessages.START_MODE_SECOND:
                    result = true;
                    break;

                default:
                    result = false;
                    logger.Trace($"Default in GetUserMode userMode input = ({input})");
                    break;

            }

            return result;
        }

        public void ShowResult(string result)
        {
            Console.WriteLine(result);
        }

        public void ShowHelp()
        {
            Console.WriteLine(TextMessages.HELP);
        }
    }
}
