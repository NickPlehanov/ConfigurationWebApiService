namespace ConfigurationWebApiService.CRUDModels.Users
{
    public class UserEditRemoveModel :UserBase
    {
        internal new DateTime CreateDate { get; set; }
        public Guid Id { get; set; }
        internal new DateTime? UpdateDate { get; set; } = DateTime.Now;
    }
}
