using Design.Pattern.Mediator.Interfaces;

namespace Design.Pattern.Mediator.Component
{
    public class DivisionComponent : BaseComponent
    {

        public DivisionComponent(int firstNumber, int secondNumber, IMediator mediator) : base(mediator)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
        }

        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
    }
}
