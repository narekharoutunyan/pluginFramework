namespace Infrastructure
{
    public class FileModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public double Radius { get; set; }
        public double Size { get; set; }

        public List<FileEffects> FileEffects { get; set; }
    }
}