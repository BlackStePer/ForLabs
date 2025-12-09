using System;

namespace SmartPhone8
{
    enum TransformatorType
    {
        Multiplier,
        Devider
    }
    internal class Transformator
    {
        public TransformatorType TransfromType { get; private set; }
        public int SerialNumber { get; private set; }
        public Transformator(int id, TransformatorType transType)
        {
            SerialNumber = id;
            TransfromType = transType;
        }
    }
}
