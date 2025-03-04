namespace BackAgente.Models
{
    public class Devices
    {
        public int id { get; set; }
        public int parentDeviceId { get; set; }
        public int organizationId { get; set; }
        public int locationId { get; set; }
        public string nodeClass { get; set; }
        public int nodeRoleId { get; set; }
        public int rolePolicyId { get; set; }
        public int policyId { get; set; }
        public string approvalStatus { get; set; }
        public bool offline { get; set; }
        public string displayName { get; set; }
        public string systemName { get; set; }
        public string dnsName { get; set; }
        public string netbiosName { get; set; }
        public int created { get; set; }
        public int lastContact { get; set; }
        public int lastUpdate { get; set; }
    }
}
