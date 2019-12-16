namespace Envelopes
{
    interface IEnvelopesUI
    {
        double GetUserParameter(string parameterName);

        bool IsOneMore();

        void ShowHelp();

        void ShowResult(string result);
    }
}