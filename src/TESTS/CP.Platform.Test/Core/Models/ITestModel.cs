namespace CP.Platform.Test.Core.Models
{
    public interface ITestModel<T>
    {
        string Name { get; set; }

        T Entity { get; set; }
    }
}