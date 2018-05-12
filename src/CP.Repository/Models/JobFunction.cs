using System;
using System.ComponentModel.DataAnnotations.Schema;
using CP.Repository.Contract;

namespace CP.Repository.Models
{
    public class JobFunction : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public Guid PositionId { get; set; }

        public Guid TitleId { get; set; }

        

        [ForeignKey("PositionId")]
        public virtual JobFunctionPosition JobFunctionPosition { get; set; }

        [ForeignKey("TitleId")]
        public virtual JobFunctionTitle JobFunctionTitle { get; set; }
    }
}