namespace DuplicateFinder
{
    public class DuplicateSearchProgress
    {
        public DuplicateSearchOperation Operation { get; set; }
        public int Percentage { get; set; } = 0;
        public string CurrentDirectory { get; set; } = "";
        public string AdditionalInformation { get; set; }
    }

    public enum DuplicateSearchOperation
    {
        DetectingDirectories,
        SearchingDuplicates,
        ErrorFound
    }
}