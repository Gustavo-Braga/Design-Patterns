using Design.Pattern.Observer.Subject;
using System;

namespace Design.Pattern.Observer.Observer
{
    public class DivisionObserver : Interfaces.IObserver<SimpleCalculator>
    {
        public void Update(SimpleCalculator subject)
        {
            if (subject.Operation == Operation.Division)
                Console.WriteLine($"A divisão dos valores é {subject.FirstNumber}/{subject.SecondNumber} = {(subject.SecondNumber == 0 ? "Inválida.. Divisão por 0" : $"{subject.FirstNumber / subject.SecondNumber}")}");
        }
    }
}
