using ExcelComparer.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ExcelComparer.Domain.Commands
{
    public class ExcelCompareCommand : IRequest<ExcelCompareResponse>
    {
        public string fileA { get; set; }
        public string fileB { get; set; }
    }
}
