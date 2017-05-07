using BKind.Web.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BKind.Web.Features.Stories
{
    public class StoryButtonsViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public StoryButtonsViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IViewComponentResult Invoke(Story story, User userWithRoles)
        {
            if (userWithRoles == null)
                return View("Anonymous");

            var model = new StoryButtonsViewModel();

            model.CanApprove = userWithRoles.Is<Reviewer>();
            model.CanEdit = story.AuthorId == userWithRoles.Id;
            model.CanUnpublish = model.CanEdit || userWithRoles.Is<Administrator>() || userWithRoles.Is<Reviewer>();
            model.CanVote = !model.CanEdit;

            model.StoryId = story.Id;

            return View(model);
        }
    }
}