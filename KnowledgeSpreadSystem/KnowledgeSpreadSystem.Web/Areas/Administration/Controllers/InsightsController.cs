﻿namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.UI;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.Controllers.Base;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Insight;
    using KnowledgeSpreadSystem.Web.Filters;
    using KnowledgeSpreadSystem.Web.Infrastructure.Extensions;

    public class InsightsController : AdministrationKendoGridController
    {
        // GET: Administration/Insights
        public InsightsController(IKSSData data)
            : base(data)
        {
        }

        [HttpPost]
        public JsonResult Delete([DataSourceRequest] DataSourceRequest request, InsightViewModel model)
        {
            base.Delete<Insight>(model.Id, true);

            return this.GridOperation(model, request);
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Insigths
                .All()
                .Project()
                .To<InsightViewModel>()
                .ForEach(
                         x =>
                         {
                             x.Target = x.ModuleId.HasValue
                                            ? this.Data.CourseModules.Find(x.ModuleId.Value).Name + "(module)"
                                            : this.Data.CourseModules.Find(x.CourseId.Value).Name + "(course)";
                             return x;
                         });
        }
    }
}