using System;
using System.ComponentModel.DataAnnotations.Schema;
using CP.Repository.Contract;

namespace CP.Repository.Models
{
    public class JobFunction : IEntityWithId<Guid>
    {
        public Guid Id { get; set; }

        [ForeignKey("JobFunctionPosition")]
        public Guid PositionId { get; set; }

        public JobFunctionPosition JobFunctionPosition { get; set; }

        [ForeignKey("JobFunctionTitle")]
        public Guid TitleId { get; set; }

        public JobFunctionTitle JobFunctionTitle { get; set; }
    }
}