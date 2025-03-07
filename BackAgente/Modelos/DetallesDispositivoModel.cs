namespace BackAgente.Modelos
{
    public class DetallesDispositivoModel
    {
        public int id { get; set; }
        public int organizationId { get; set; }
        public int locationId { get; set; }
        public string nodeClass { get; set; }
        public int nodeRoleId { get; set; }
        public int rolePolicyId { get; set; }
        public string approvalStatus { get; set; }
        public bool offline { get; set; }
        public string displayName { get; set; }
        public string systemName { get; set; }
        public string dnsName { get; set; }
        public double created { get; set; }
        public double lastContact { get; set; }
        public double lastUpdate { get; set; }
        public List<string> ipAddresses { get; set;}
        public List<string> MacAddresses { get; set;}
        public string publicIP { get; set; }
        public OSInfo os { get; set; }
        public SystemInfo system { get; set; }
        public MemoryInfo memory { get; set; }
        public List<ProcessorInfo> processors { get; set; }
        public List<VolumeInfo> volumes { get; set; }
        public string lastLoggedInUser { get; set; }
        public string deviceType { get; set; }
    }


    public class OSInfo
    {
        public string manufacturer { get; set; }
        public string name { get; set; }
        public string architecture { get; set; }
        public double lastBootTime { get; set; }
        public string buildNumber { get; set; }
        public string releaseId { get; set; }
        public int servicePackMajorVersion { get; set; }
        public int servicePackMinorVersion { get; set; }
        public string locale { get; set; }
        public string language { get; set; }
        public bool needsReboot { get; set; }
    }

    public class SystemInfo
    {
        public string name { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public string biosSerialNumber { get; set; }
        public string serialNumber { get; set; }
        public string domain { get; set; }
        public string domainRole { get; set; }
        public int numberOfProcessors { get; set; }
        public long totalPhysicalMemory { get; set; }
        public bool virtualMachine { get; set; }
        public string chassisType { get; set; }
    }

    public class MemoryInfo
    {
        public long capacity { get; set; }
    }

    public class ProcessorInfo
    {
        public string architecture { get; set; }
        public long maxClockSpeed { get; set; }
        public long clockSpeed { get; set; }
        public string name { get; set; }
        public int numCores { get; set; }
        public int numLogicalCores { get; set; }
    }

    public class VolumeInfo
    {
        public string name { get; set; }
        public string label { get; set; }
        public string deviceType { get; set; }
        public string fileSystem { get; set; }
        public bool autoMount { get; set; }
        public bool compressed { get; set; }
        public long capacity { get; set; }
        public long freeSpace { get; set; }
        public string serialNumber { get; set; }
    }

}
