﻿namespace FlightAgency.model
{
    class Tuple<E1,E2>
    {
        public E1 ID1 { get; set; }
        public E2 ID2 { get; set; }

        public Tuple(E1 iD1, E2 iD2)
        {
            ID1 = iD1;
            ID2 = iD2;
        }

        public override string ToString()
        {
            return ID1 + " " + ID2;
        }
    }
}