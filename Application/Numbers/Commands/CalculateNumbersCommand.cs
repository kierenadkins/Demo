using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Numbers.Commands
{
    public class CalculateNumbersCommand : IRequest<int>
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
    }
}
