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
    
    public partial class Fight
    {
        public int Id { get; set; }
        public int idZeroParticipantCompetition { get; set; }
        public int idOneParticipantCompetition { get; set; }
        public Nullable<bool> Result { get; set; }
    
        public virtual ParticipantCompetition ParticipantCompetition { get; set; }
        public virtual ParticipantCompetition ParticipantCompetition1 { get; set; }
    }
}
