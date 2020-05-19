using Design.Pattern.Mediator.Component;
using Design.Pattern.Mediator.Interfaces;
using Design.Pattern.Mediator.Service;
using System;

namespace Design.Pattern.Mediator.Mediator
{
    public class SumAndSubtractionMediator : IMediator
    {
        private SimpleCalculatorService _simpleCalculatorService = new SimpleCalculatorService();
        public void Send(object send)
        {
            if (send is SumComponent)
                _simpleCalculatorService.Sum((SumComponent)send);
            else if (send is SubtractionComponent)
                _simpleCalculatorService.Subtraction((SubtractionComponent)send);
            else
                throw new NotImplementedException();
        }
    }
}
