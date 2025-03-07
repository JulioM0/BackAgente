namespace BackAgente.Modelos
{
    public class DispositivosModel
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
    }
}
