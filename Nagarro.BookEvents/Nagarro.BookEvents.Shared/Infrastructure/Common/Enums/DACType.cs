namespace Nagarro.BookEvents.Shared
{
    /// <summary>
    /// Data Access Component Type
    /// </summary>
    public enum DACType
    {
        /// <summary>
        /// Undefined DAC (Default)
        /// </summary>
        Undefined = 0,

        [QualifiedTypeName("Nagarro.BookEvents.Data.dll", "Nagarro.BookEvents.Data.SampleDAC")]
        SampleDAC = 1

    }
}
