using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
  
       public abstract class Storage
        {
            public string Name { get; }
            public string Model { get; }

            public Storage(string name, string model)
            {
                Name = name;
                Model = model;
            }

            public abstract double GetCapacity();
            public abstract (int, double) Copy(double fileSize);
            public abstract double FreeMemory();

            public void PrintDeviceInfo()
            {
                Console.WriteLine($"Media: {Name}");
                Console.WriteLine($"Model: {Model}");
                Console.WriteLine($"Capacity: {GetCapacity()} GB");
                Console.WriteLine($"Free Memory: {FreeMemory()} GB");
            }
        }

        class Flash : Storage
        {
            public double UsbSpeed { get; }
            public double Memory { get; }

            public Flash(string name, string model, double usbSpeed, double memory)
                : base(name, model)
            {
                UsbSpeed = usbSpeed;
                Memory = memory;
            }

            public override double GetCapacity()
            {
                return Memory;
            }

            public override (int, double) Copy(double fileSize)
            {
                double mediaNeeded = fileSize / Memory;
                double timeNeeded = mediaNeeded / (UsbSpeed * 1024); 
                return (Convert.ToInt32(mediaNeeded), timeNeeded);
            }

            public override double FreeMemory()
            {
                return Memory;
            }
        }

        class DVD : Storage
        {
            public double ReadWriteSpeed { get; }
            public bool SingleSided { get; }

            public DVD(string name, string model, double readWriteSpeed, bool singleSided)
                : base(name, model)
            {
                ReadWriteSpeed = readWriteSpeed;
                SingleSided = singleSided;
            }

            public override double GetCapacity()
            {
                return SingleSided ? 4.7 : 9.0;
            }

            public override (int, double) Copy(double fileSize)
            {
                double mediaNeeded = fileSize / GetCapacity();
                double timeNeeded = mediaNeeded * 60 / ReadWriteSpeed;
                return (Convert.ToInt32(mediaNeeded), timeNeeded);
            }

            public override double FreeMemory()
            {
                return GetCapacity();
            }
        }

        class HDD : Storage
        {
            public double UsbSpeed { get; }
            public double TotalSize { get; }

            public HDD(string name, string model, double usbSpeed, double totalSize)
                : base(name, model)
            {
                UsbSpeed = usbSpeed;
                TotalSize = totalSize;
            }

            public override double GetCapacity()
            {
                return TotalSize;
            }

            public override (int, double) Copy(double fileSize)
            {
                double mediaNeeded = fileSize / TotalSize;
                double timeNeeded = mediaNeeded / (UsbSpeed * 1024); 
                return (Convert.ToInt32(mediaNeeded), timeNeeded);
            }

            public override double FreeMemory()
            {
                return TotalSize;
            }
        }

    
         }

