namespace GraphQLvsRest.Abstractions.Types
{
    /// <summary> Filter for method GetBooks. </summary>
    public class GetBooksFilter
    {
        /// <summary> Filter by template in books name. </summary>
        public string? BookName { get; set; }

        /// <summary> Filter by template in authors. </summary>
        public string? Author { get; set; }
    }
}
