using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using DoJudo.Models.Repositories;
using DoJudo.Views.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoJudo.Models
{
    internal class CompetitionGrid
    {
        private readonly IParticipantCompetitionRepository _participantCompetitionRepository;
        private readonly IFightRepository _fightRepository;
        private Random _random;
        public CompetitionGrid()
        {
            _random = new Random();
            _fightRepository = new FightRepository();
            _participantCompetitionRepository = new ParticipantCompetitionRepository();
        }
        private void DrawCompetitionGrid(ObservableCollection<ParticipantCompetition> _participantCompetitions)
        {
            while(_participantCompetitions.Count >= 2)
            {
                int index1 = _random.Next(_participantCompetitions.Count);
                ParticipantCompetition participant0 = _participantCompetitions[index1];
                _participantCompetitions.RemoveAt(index1);
                int index2 = _random.Next(_participantCompetitions.Count);
                ParticipantCompetition participant1 = _participantCompetitions[index2];
                _participantCompetitions.RemoveAt(index2);
                Fight fight = new Fight();
                fight.ParticipantCompetition = participant0;
                fight.ParticipantCompetition1 = participant1;
                _fightRepository.Add(fight);
            }
        }
        public async void DrawCompetitionGrids()
        {
            foreach(var item in DbDoJudo.GetInstance().Groups)
            {
                var listConverter = await _participantCompetitionRepository.GetByGroup(item);
                if (listConverter == null)
                    return;
                var listParticipantCompetition = new ObservableCollection<ParticipantCompetition>((IEnumerable<ParticipantCompetition>)listConverter);
                DrawCompetitionGrid(listParticipantCompetition);
            }
        }
    }
}
