using API.Data;
using CommunityToolkit.Mvvm.ComponentModel;
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

        public AppViewModel(IDbContextFactory<AppDbContext>? dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
