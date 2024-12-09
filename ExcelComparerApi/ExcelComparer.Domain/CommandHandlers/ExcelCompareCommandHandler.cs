using ExcelCompareNuget.Compare.Entities;
using ExcelCompareNuget.Compare.Service;
using ExcelCompareNuget.Models;
using ExcelComparer.Domain.Commands;
using ExcelComparer.Domain.Helpers;
using ExcelComparer.Domain.Responses;
using MediatR;
using Newtonsoft.Json;

namespace ExcelComparer.Domain.CommandHandlers
{
    public class ExcelCompareCommandHandler : IRequestHandler<ExcelCompareCommand, ExcelCompareResponse>
    {
        private const string FileNameA = "tmpA.csv";
        private const string FileNameB = "tmpB.csv";
        private readonly CompareService _compareService;

        public ExcelCompareCommandHandler()
        {
            _compareService = new CompareService();
        }

        public Task<ExcelCompareResponse> Handle(ExcelCompareCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var fileStreamA = FileStreamParser.ToCsv(request.fileA.Replace("\t", ","), FileNameA);
                var fileStreamB = FileStreamParser.ToCsv(request.fileB.Replace("\t", ","), FileNameB);

                var fileInputA = new FileInput(fileStreamA.Name);
                var fileInputB = new FileInput(fileStreamB.Name);

                var excelCompareRequest = new CompareRequest(fileInputA, fileInputB);
                var compareResult = _compareService.CompareInputs(excelCompareRequest);

                var result = new ExcelCompareResponse(compareResult);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                var t = ex.Message;
            }
            finally
            {
                if (File.Exists(FileNameA))
                {
                    File.Delete(FileNameA);
                }

                if (File.Exists(FileNameB))
                {
                    File.Delete(FileNameB);
                }
            }

            return Task.FromResult(new ExcelCompareResponse());
        }
    }
}
