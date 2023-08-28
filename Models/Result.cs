namespace loadtestapi.Models
{
    public class Result
    {
        public long PartnerGroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupType { get; set; }

        public string Object { get; set; }

        public bool IsIncluded { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTime LastUpdatedOn { get; set; }



    }
}
