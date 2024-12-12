namespace ConfigurationWebApiService.Models
{
    public class EntityChangedEventArgs<T>: EventArgs
    {
        public EntityChangedEventArgs()
        {
        }
        public EntityChangedEventArgs(T entity, EntityAction entityAction, string notes, int affectedRows=-1)
        {
            Entity = entity;
            Action = entityAction;
            Notes = notes;
            AffectedRows = affectedRows;
        }
        public T? Entity { get; set; }
        public EntityAction Action { get; set; }
        public string? Notes { get; set; }
        public int AffectedRows { get; set; } = -1;
    }
    public enum EntityAction
    {
        Add, Update, Remove
    }
}
