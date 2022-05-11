namespace Example.TodoWebApp.Data.Domains
{
    public class Work : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
