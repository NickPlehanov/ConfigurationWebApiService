namespace ConfigurationWebApiService.CRUDModels.Users
{
    public class UserBase
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Login { get; set; }
        internal DateTime CreateDate { get; set; } = DateTime.Now;
        internal DateTime? UpdateDate { get; set; } = null;
        internal bool IsActive { get; set; } = true;
    }
}
