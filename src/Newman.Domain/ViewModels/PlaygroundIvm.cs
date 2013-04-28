using System.Text;

namespace Newman.Domain.ViewModels
{
    public class PlaygroundIvm : BaseVm
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public Position Position { get; set; }
        public string CityPart { get; set; }
        public string Type { get; set; }
        public string FullText
        {
            get
            {
                var builder = new StringBuilder();
                builder.AppendLine(Name);
                builder.AppendLine(Category);
                builder.AppendLine(CityPart);
                return builder.ToString();
            }
        }
    }
}