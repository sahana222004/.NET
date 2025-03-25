namespace assesssment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EvenNumber evenProcessor = new EvenNumber();

            evenProcessor.StoreEvenNumbers(10);
            Console.WriteLine("Even number stored : " +string.Join("," , evenProcessor.StoreEvenNumbers(10)));

            Console.WriteLine("after doubling : " +string.Join(", ", evenProcessor.PrintEvenNumbers()));

            Console.WriteLine("Retrieveing even number 4 : "+evenProcessor.RetrieveEvenNumber(4));
            Console.WriteLine("Retrieveing even number  7: " + evenProcessor.RetrieveEvenNumber(7));
        }
    }
}
