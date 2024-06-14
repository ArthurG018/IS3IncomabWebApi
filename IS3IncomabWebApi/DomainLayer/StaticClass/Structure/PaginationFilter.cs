namespace IS3IncomabWebApi.DomainLayer.StaticClass.Structure
{
    public readonly struct PaginationFilter
    {
        public int StartIndex { get; init; }
        public int MaxRecord { get; init; }
        public string filter { get; init; }
    }
}
