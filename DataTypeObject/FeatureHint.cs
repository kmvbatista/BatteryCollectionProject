namespace DataTypeObject
{
    public class FeatureHint
    {
        public FeatureHint(User sender, string material,
         string Description, string local)
        {
            this.Local = local;
            this.Material= material;
            this.Description = Description;
            this.Sender = sender;
        }
        public User Sender { get; set; }
        public string Material { get; set; }
        public string Description { get; set; }
        public string Local { get; set; }
    }
}