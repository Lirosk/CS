﻿using System;

namespace LR_8
{
    class Pack<T>
    {
        public IPackСontingent Contingent { get; set; }
        public T Staff { get; set; }

        public delegate void CheckTheStaffDelegate(ushort q);
        public CheckTheStaffDelegate checkTheStaffDelegate = delegate (ushort q)
        {
            if (q == 0)
            {
                Console.WriteLine("Staff has been stolen...\n");
            }
            else
            {
                Console.WriteLine("Staff still here.");
            }
        };

        public void CheckStaff(CheckTheStaffDelegate checkTheStaffDelegate)
        {
            checkTheStaffDelegate?.Invoke(Contingent.Quantity);
        }

        public Pack(T Staff, IPackСontingent Contingent = null)
        {
            this.Staff = Staff;
            this.Contingent = Contingent;
        }
    }
}
