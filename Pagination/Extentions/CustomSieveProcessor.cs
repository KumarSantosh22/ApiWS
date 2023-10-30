using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace Pagination.Extentions
{
    public class CustomSieveProcessor: SieveProcessor
    {
        public CustomSieveProcessor(IOptions<SieveOptions> options): base(options) { }
    }
}
