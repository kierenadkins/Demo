using Application.Numbers.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Numbers
{
    public class CalculateNumbersCommandHandler : IRequestHandler<CalculateNumbersCommand, int>
    {
        public async Task<int> Handle(CalculateNumbersCommand request, CancellationToken cancellationToken)
        {
            int result = request. Number1 + request.Number2;

            SaveWork(request, result);

            return result;
        }

        //this would normally be put in a seperate class for databases. 
        //INSERT INTO tbl_calculations (number1, number2, result, ...)
        //VALUES(request.Number1,request.Number2,result);
        public void SaveWork (CalculateNumbersCommand request, int result)
        {
            string filePath = "results.csv";
            bool fileExists = File.Exists(filePath);

            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                if (!fileExists)
                {
                    writer.WriteLine("Number 1,Number 2,Result");
                }

                writer.WriteLine($"{request.Number1},{request.Number2},{result}");
            }
        }
    }
}
