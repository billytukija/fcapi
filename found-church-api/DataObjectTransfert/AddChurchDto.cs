namespace found_church_api.DataObjectTransfert
{
    public class AddChurchDto
    {
        public string ChurchName { get; set; }
        public string PastorName { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string AdditionalInformations { get; set; }
        public string NameProvider { get; set; }
        public string EmailProvider { get; set; }
    }
}
