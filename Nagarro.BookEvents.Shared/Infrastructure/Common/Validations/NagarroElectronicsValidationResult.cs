using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    public class NagarroElectronicsValidationResult
    {
        public IList<NagarroElectronicsValidationFailure> Errors { get; private set; }

        public bool IsValid
        {
            get { return Errors == null || Errors.Count == 0; }
        }

        public NagarroElectronicsValidationResult(IList<NagarroElectronicsValidationFailure> failures)
        {
            Errors = failures;
        }

        public NagarroElectronicsValidationResult()
        {
            Errors = new List<NagarroElectronicsValidationFailure>();
        }
    }
}
