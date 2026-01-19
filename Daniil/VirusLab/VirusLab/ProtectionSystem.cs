using System;
using System.Runtime.Remoting.Messaging;

namespace VirusLab
{
    /// <summary>
    /// Система с защитой от вирусом
    /// </summary>
    internal class ProtectionSystem
    {
        private int currentProtectionLvl = 1;
        public double Security;
        public string Title { get; private set; }
        public DateTime Date { get; private set; } =  new DateTime(1, 1, 1);
        public int ProtectionLeyerNember { get; private set; }
        public int FailedProtectionLeyerNumber { get; private set; } = 0;
        private static Random rnd = new Random();

        public ProtectionSystem(string title, int protectionLeyerNum, double security)
        {
            Title = title;
            ProtectionLeyerNember = protectionLeyerNum;
            Security = security;
        }
        /// <summary>
        /// Проверка безорпасности
        /// </summary>
        /// <returns>Уровень защиты взломан?</returns>
        public virtual bool ProtectionCheck()
        {
            Date = Date.AddDays(1);
            if (currentProtectionLvl - FailedProtectionLeyerNumber == 1)
            {
                return false;
            }
            else
            {
                FailedProtectionLeyerNumber = currentProtectionLvl - 1;
                return true;
            }
        }
        /// <summary>
        /// Ответ на атаку вируса
        /// </summary>
        public virtual void GetAttack()
        {
            if (rnd.NextDouble() < Security  && currentProtectionLvl <= ProtectionLeyerNember)
                currentProtectionLvl++;
        }
    }
}
