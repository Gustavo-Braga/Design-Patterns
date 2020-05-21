using Design.Pattern.Observer.Subject;
using System;

namespace Design.Pattern.Observer.Observer
{
    public class MultiplicationObserver : Interfaces.IObserver<SimpleCalculator>
    {
        public void Update(SimpleCalculator subject)
        {
            if (subject.Operation == Operation.Multiplication)
                Console.WriteLine($"A multiplicação dos valores é {subject.FirstNumber}*{subject.SecondNumber} = {subject.FirstNumber * subject.SecondNumber}");
        }
    }
}
