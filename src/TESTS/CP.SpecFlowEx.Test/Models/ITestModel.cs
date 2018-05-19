namespace CP.SpecFlowEx.Test.Models
{
    public interface ITestModel<T>
    {
        string Name { get; set; }

        T Entity { get; set; }
    }
}