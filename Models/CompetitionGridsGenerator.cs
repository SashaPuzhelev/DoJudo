﻿using DoJudo.Models.Database;
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
    internal class CompetitionGridsGenerator
    {
        private readonly IParticipantCompetitionRepository _participantCompetitionRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IFightRepository _fightRepository;
        private readonly Random _random;
        public CompetitionGridsGenerator()
        {
            _random = new Random();
            _fightRepository = new FightRepository();
            _participantCompetitionRepository = new ParticipantCompetitionRepository();
            _groupRepository = new GroupRepository();
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
            if (_participantCompetitions.Count == 1)
            {
                Fight fight = new Fight();
                fight.ParticipantCompetition = _participantCompetitions[0];
                fight.IdWinner = _participantCompetitions[0].Id;
                _fightRepository.Add(fight);
            }
        }
        public async void DrawCompetitionGrids(Competition competition)
        {
            var listGroups = await _groupRepository.GetAllByCompetition(competition);
            foreach(var item in listGroups)
            {
                var listConverter = await _participantCompetitionRepository.GetByGroup(item);
                if (listConverter == null)
                    return;
                var listParticipantCompetition = new ObservableCollection<ParticipantCompetition>(listConverter);
                DrawCompetitionGrid(listParticipantCompetition);
            }
        }
    }
}