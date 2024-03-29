﻿namespace Envelopes
{
    public class Envelope
    {
        private double _aBSide;
        private double _cDSide;

        public Envelope(double aBSide, double cDSide)
        {
            _aBSide = aBSide;
            _cDSide = cDSide;
        }

        public static bool operator >(Envelope c1, Envelope c2)
        {
            if (((c1._aBSide > c2._aBSide) && (c1._cDSide > c2._cDSide))
                || ((c1._aBSide > c2._cDSide) && (c1._cDSide > c2._aBSide)))
            {
                return true;
            }
            return false;
        }

        public static bool operator <(Envelope c1, Envelope c2)
        {
            return c2 > c1;
        }
    }
}
