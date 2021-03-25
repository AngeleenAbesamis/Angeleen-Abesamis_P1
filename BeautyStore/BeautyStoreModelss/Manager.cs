using System;
using Serilog;

namespace BeautyStore.BeautyStoreModels
{
    public class Manager
    {
        private string managerName;
        private string password;
        private int managerId;
        private string phoneNumber;
        // public ICollection<Location> Location { get; set; }

        public string ManagerName
        {
            get { return managerName; }
            set
            {
                if (value.Equals(null))
                {
                    ThrowNullException();
                }
                managerName = value;
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                if (value.Equals(null))
                {
                    ThrowNullException();
                }
                password = value;
            }
        }
        public int ManagerID
        {
            get { return managerId; }
            set
            {
                if (value.Equals(null))
                {
                    ThrowNullException();
                }
                managerId = value;
            }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (value.Equals(null))
                {
                    ThrowNullException();
                }
                phoneNumber = value;
            }
        }
        public void ThrowNullException()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../Logs/UILogs.json").CreateLogger();
            Log.Error("Cannot accept null value.");
            throw new Exception("Null value cannot be accepted!");
        }
    }
}
