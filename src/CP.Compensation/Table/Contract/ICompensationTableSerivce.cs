using CP.Compensation.Table.Models;

namespace CP.Compensation.Table.Contract
{
    public interface ICompensationTableSerivce
    {
        CompensationTableView Get(CompensationTableParameters parameters);
    }
}