using Design.Pattern.Mediator.Component;
using Design.Pattern.Mediator.Interfaces;
using Design.Pattern.Mediator.Service;
using System;

namespace Design.Pattern.Mediator.Mediator
{
    public class MultiplicationAndDivisionMediator : IMediator
    {
        private SimpleCalculatorService _simpleCalculatorService = new SimpleCalculatorService();
        public void Send(object send)
        {
            if (send is MultiplicationComponent)
                _simpleCalculatorService.Multiplication((MultiplicationComponent)send);
            else if (send is DivisionComponent)
                _simpleCalculatorService.Division((DivisionComponent)send);
            else
                throw new NotImplementedException();
        }
    }
}
