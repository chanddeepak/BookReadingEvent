﻿namespace Nagarro.BookEvents.Shared
{
    /// <summary>
    /// Business Domain Component Type
    /// </summary>
    public enum BDCType
    {
        /// <summary>
        /// Undefined BDC (Default)
        /// </summary>
        Undefined = 0,

        [QualifiedTypeName("Nagarro.BookEvents.Business.dll", "Nagarro.BookEvents.Business.SampleBDC")]
        SampleBDC = 1

    }
}
