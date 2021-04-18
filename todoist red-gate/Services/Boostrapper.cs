using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoist_red_gate.Services.TrelloServices.ITrelloServices;
using todoist_red_gate.Services.TrelloServices.TrelloServices;

namespace todoist_red_gate.Services
{
    public static class Bootstrapper
    {
        public static void UseServices(this IServiceCollection services)
        {
            services.AddHttpClient<IListService, ListService>();
            services.AddHttpClient<ICardService, CardService>();
            services.AddHttpClient<ILabelService, LabelService>();
            services.AddHttpClient<IChecklistService, ChecklistService>();
            services.AddHttpClient<IBoardService, BoardService>();
        }
    }
}
