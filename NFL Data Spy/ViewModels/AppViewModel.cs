﻿using API.Data;
using API.Interfaces;
using API.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFL_Data_Spy.ViewModels
{
    public partial class AppViewModel : ObservableObject
    {
        private readonly IDbContextFactory<AppDbContext>? _dbContext;
        private readonly IMatchupService _matchupService;

        [RelayCommand]
        private async Task GetSeasonSchedule()
        {
            await _matchupService.GetSeasonSchedule(2023, "dallas-cowboys");
        }
        public AppViewModel(IDbContextFactory<AppDbContext>? dbContext, IMatchupService matchupService)
        {
            _dbContext = dbContext;
            _matchupService = matchupService;
        }
    }
}
