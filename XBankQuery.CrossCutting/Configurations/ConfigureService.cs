using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XbankQuery.Domain.Interfaces;
using XbankQuery.Domain.Interfaces.BalanceService;
using XbankQuery.Domain.Interfaces.StatementService;
using XBankQuery.Application.Service;
using XBankQuery.Application.Service.Balance;
using XBankQuery.Application.Service.Statement;

namespace XBankQuery.CrossCutting.Configurations
{
    public static class ConfigureService
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IBankBalanceService, BankBalanceService>();
            services.AddTransient<IBankStatementService, BankStatementService>();
            services.AddTransient<IStatementService, StatementService>();
            services.AddTransient<IBalanceService, BalanceService>();
        }
    }
}
