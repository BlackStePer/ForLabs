using System;
using System.Collections.Generic;

namespace VirusLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProtectionSystem sys = new ProtectionSystem("Windows 11", 10, 0.5);
            Skyda viru = new Skyda("CS-2", sys);
            List<IReactProtectionFall> nots = new List<IReactProtectionFall>();
            for (int i = 1; i <= 10; i++) 
            {
                if(i == 10)
                {
                    EndLayerNotifier enot = new EndLayerNotifier(i);
                    enot.Subscribe(viru);
                    nots.Add(enot);
                    break;
                }
                BasicLayerNotifier not = new BasicLayerNotifier(i);
                not.Subscribe(viru);
                nots.Add(not);
            }

            for (int i = 0; i < 20; i++) 
            {
                viru.Attack();
                viru.NotifyProtectionFall();
            }
        }
    }
}
