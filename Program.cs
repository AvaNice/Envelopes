using NLog;
using System.Diagnostics;

namespace Envelopes
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            EnvelopesUI userInterface = new EnvelopesUI();
            EnvelopesApp app = new EnvelopesApp(userInterface);

            logger.Info(new string('-', 50));

            if (args.Length > 1)
            {
                app.StartWithParams(args);

                if(!userInterface.IsOneMore())
                {
                    Process.GetCurrentProcess().Kill();
                }
            }
            else
            {
                userInterface.ShowHelp();
            }

            do
            {
                app.Start();
            }
            while (userInterface.IsOneMore());
        }
    }
}
