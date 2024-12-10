namespace ConfigurationWebApiService.Models
{
    public class EntityChangedEventArgs<T>: EventArgs
    {
        public EntityChangedEventArgs()
        {
        }
        public EntityChangedEventArgs(T entity, EntityAction entityAction, string notes)
        {
            Entity = entity;
            Action = entityAction;
            Notes = notes;
        }
        public T? Entity { get; set; }
        public EntityAction Action { get; set; }
        public string? Notes { get; set; }
    }
    public enum EntityAction
    {
        Add, Update, Remove
    }
}
