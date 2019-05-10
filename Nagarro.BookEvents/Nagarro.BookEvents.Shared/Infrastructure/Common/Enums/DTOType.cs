namespace Nagarro.BookEvents.Shared
{
    /// <summary>
    /// Data Transfer Objects
    /// </summary>
    public enum DTOType
    {
        /// <summary>
        /// Undefined DTO (Default)
        /// </summary>
        Undefined = 0,

        [QualifiedTypeName("Nagarro.BookEvents.DTOModel.dll", "Nagarro.BookEvents.DTOModel.SampleDTO")]
        SampleDTO = 1
    }
}
