using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envelopes
{
    static class TextMessages
    {
        #region PublicMembers
        public const string HEIGHT = "Height";
        public const string WIDTH = "Width";
        public const string HELP = "Exit - to complete the work.\nYes or Y - to get started." +
            "\nAfter that you will need to enter side of the envelopes.";
        public const string INCORRECT_INPUT = "Use the numeric value to enter the Height and Width.";
        public const string START_MODE = "yes";
        public const string GET_AB = "(a, b)";
        public const string GET_CD = "(c, d)";
        public const string START_MODE_SECOND = "y";
        public const string EXIT_MODE = "exit";
        public const string FIRST_ENVELOPE_IN = "First envelope can be placed in second envelope";
        public const string SECOND_ENVELOPE_IN = "Second envelope can be placed in first envelope";
        public const string CANT_BE_PLACED = "None of the envelopes can be placed in the second envelope";
        public const string SETTINGS_MODE = "settings";
        #endregion
    }
}
