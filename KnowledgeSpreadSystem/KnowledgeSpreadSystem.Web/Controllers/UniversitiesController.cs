﻿namespace KnowledgeSpreadSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Infrastructure;
    using KnowledgeSpreadSystem.Web.Infrastructure.Extensions;
    using KnowledgeSpreadSystem.Web.ViewModels;

    [Authorize]
    public class UniversitiesController : BaseController
    {
        // GET: Universities
        public UniversitiesController(IKSSData data)
            : base(data)
        {
        }

        public ActionResult All()
        {
            return this.View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var universities = this.Data.Universities.All().Project().To<UniversityViewModel>();
            var universitiesShortenedDescription = universities.ForEach(
                                                                        x =>
                                                                            {
                                                                                x.About = x.About.ToShortString(200);
                                                                                return x;
                                                                            });
            return this.Json(universitiesShortenedDescription.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {
            var uni = this.Data.Universities.All().FirstOrDefault(u => u.Id == id);
            var university = Mapper.Map<UniversityViewModel>(uni);

            return this.View(university);
        }

    }
}