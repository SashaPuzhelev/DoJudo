//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoJudo.Models.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class ParticipantCompetition
    {
        public int Id { get; set; }
        public int IdGroup { get; set; }
        public int IdSportsman { get; set; }
        public double Weight { get; set; }
    
        public virtual Group Group { get; set; }
        public virtual Participant Participant { get; set; }
    }
}