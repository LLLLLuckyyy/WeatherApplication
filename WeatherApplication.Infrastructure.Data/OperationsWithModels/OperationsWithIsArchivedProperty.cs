using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.Domain.Core;

namespace WeatherApplication.Infrastructure.Data.OperationsWithModels
{
    //Changing value of IsArchived property
    public static class OperationsWithIsArchivedProperty
    {
        public static async Task SetIsArchivedTrueAndSaveChanges(IQueryable<WeatherModel> weatherHistory, WeatherAppContext context)
        {
            foreach (var wm in weatherHistory)
            {
                wm.IsArchived = true;
            }
            await context.SaveChangesAsync();
        }

        public static async Task SetIsArchivedFalseAndSaveChanges(IQueryable<WeatherModel> weatherHistory, WeatherAppContext context)
        {
            foreach (var wm in weatherHistory)
            {
                wm.IsArchived = false;
            }
            await context.SaveChangesAsync();
        }
    }
}
