using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XbankQuery.Domain.Interfaces;
using XBankQuery.Repository.Repository;

namespace XBankQuery.CrossCutting.Configurations
{
    public static class ConfigureRepository
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IBankBalanceRepository, BankBalanceRepository>();
            services.AddTransient<IBankStatementRepository, BankStatementRepository>();
        }
    }
}
