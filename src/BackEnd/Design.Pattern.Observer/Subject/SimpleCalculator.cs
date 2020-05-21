namespace Design.Pattern.Observer.Subject
{
    public class SimpleCalculator: SubjectBase<SimpleCalculator>
    {
        public SimpleCalculator(int firstNumber, int secondNumber)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
        }

        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        public Operation Operation { get; set; }
    }


    public enum Operation
    {
        Sum,
        Subtraction,
        Multiplication,
        Division
    }
}
