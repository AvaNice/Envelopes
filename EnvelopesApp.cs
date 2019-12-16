using NLog;
using System;

namespace Envelopes
{
    class EnvelopesApp
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private readonly IEnvelopesUI _userInterface;

        public EnvelopesApp(IEnvelopesUI userInterface)
        {
            _userInterface = userInterface;
        }

        public void StartWithParams(string[] args)
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

                _userInterface.ShowHelp();
            }
        }

        public void OutputEnvelopeCompare(Envelope first, Envelope second)
        {
            // Console.WriteLine(Envelope.CanBeInvested(first, second));
            if (Envelope.CanBeInvested(first, second))
            {
               // Console.WriteLine(TextMessages.SECOND_ENVELOPE_IN);
                _userInterface.ShowResult(TextMessages.SECOND_ENVELOPE_IN);

            }
            else if (Envelope.CanBeInvested(second, first))
            {
               // Console.WriteLine(TextMessages.FIRST_ENVELOPE_IN);
                _userInterface.ShowResult(TextMessages.FIRST_ENVELOPE_IN);
            }
            else
            {
               // Console.WriteLine(TextMessages.CANT_BE_PLACED);
                _userInterface.ShowResult(TextMessages.CANT_BE_PLACED);
            }
        }

        public void Start()
        {
            Envelope first = BuildEnvelope(TextMessages.FIRST);
            Envelope second = BuildEnvelope(TextMessages.SECOND);
            
            OutputEnvelopeCompare(first, second);
        }

        private Envelope BuildEnvelope(string name)
        {
            double aBSide;
            double cDSide;

            aBSide = _userInterface.GetUserParameter($"{name} {TextMessages.GET_AB}");
            cDSide = _userInterface.GetUserParameter($"{name} {TextMessages.GET_CD}");

            return new Envelope(aBSide, cDSide);
        }
    }
}
