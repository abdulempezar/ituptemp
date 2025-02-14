using FluentValidation;

namespace Models.Validations;

public class NFARequestValidator : AbstractValidator<Users>
{
	//    public NFARequestValidator()
	//    {
	//        When(y => (new NFAViewFor[] { NFAViewFor.Draft, NFAViewFor.PushBackRequester }).Contains(y.nfaviewfor), () =>
	//        {
	//            RuleFor(y => y.budgetary).NotNull().When(x => x.selTab!.requestTab == RequestTabs.Budgetary || (x.maxTabOrder == x.selTab!.order && x.requesttype == RequestType.Budgetary)).SetValidator(new BudgetaryValidator()!);
	//            RuleFor(x => x.nfastatus).SetValidator(new NFAStatusValidator()).When(x => x.selTab!.requestTab == RequestTabs.ApprovalFlow || (x.maxTabOrder == x.selTab!.order));
	//        });

	//        RuleFor(x => x.nfastatus).SetValidator(new NFAStatusValidator()).When(x => x.nfaviewfor == NFAViewFor.EditApprover && x.selTab!.requestTab == RequestTabs.ApprovalFlow);
	//    }
	//}

	//public class NFAStatusValidator : AbstractValidator<NFAStatus>
	//{
	//    public NFAStatusValidator()
	//    {
	//        RuleFor(x => x.revieweremailaddress).NotEmpty().WithMessage("Please enter valid email id of reviewer within adani domain")
	//            .Must((x, y) => !y.Contains(x.creatoremailid, StringComparer.CurrentCultureIgnoreCase)).WithMessage("Requestor cannot be an reviewer for the same request")
	//            .Must((n, r) => !r.Intersect(n.approvers?.SelectMany(x => x.apprdetails?.Select(y => y.appr) ?? Enumerable.Empty<string>()) ?? Enumerable.Empty<string>()).Any()).WithMessage("Reviewer cannot be an approver for the same request")
	//            .When(n => n.sendforreview);

	//        RuleFor(x => x.approvers).Cascade(CascadeMode.Stop).NotNull().WithMessage("Please enter valid email id of approver within adani domain").NotEmpty().WithMessage("Please enter valid email id of approver within adani domain")
	//            .Must((n, r) => !(n.approvers?.SelectMany(x => x.apprdetails?.Select(y => y.appr) ?? Enumerable.Empty<string>()) ?? Enumerable.Empty<string>()).Contains(n.creatoremailid, StringComparer.CurrentCultureIgnoreCase)).WithMessage("Requestor cannot be an approver for the same request")
	//            .ForEach(a => a.ChildRules(y => y.RuleFor(z => z.apprdetails).Cascade(CascadeMode.Stop).NotNull().NotEmpty().WithMessage("Please enter valid email id of approver within adani domain")))
	//            .ForEach(a => a.ChildRules(y => y.RuleFor(z => z.apprdetails).ForEach(u => u.ChildRules(z =>
	//                        z.RuleFor(s => s.appr).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Please enter approver email id").EmailAddress().WithMessage("Please enter valid email id of approver within adani domain")
	//#if DEBUG
	//                        .Must(s => s.EndsWith("@adani.com", StringComparison.CurrentCultureIgnoreCase) || s.EndsWith("@empezar.test", StringComparison.CurrentCultureIgnoreCase) || s.EndsWith("@empezar.digital", StringComparison.CurrentCultureIgnoreCase))
	//#else
	//						.Must(s => s.EndsWith("@adani.com", StringComparison.CurrentCultureIgnoreCase))
	//#endif
	//                        .WithMessage("Please enter valid email id of approver within adani domain")
	//                        )))).When(x => !x.isfromapprmatrix)
	//            .ForEach(a => a.ChildRules(y => y.RuleFor(z => z.apprdetails).ForEach(u => u.ChildRules(z =>
	//                        z.RuleFor(x => x.designation).NotEmpty().WithMessage("Please enter designation of approver").When(x => !string.IsNullOrWhiteSpace(x.appr))))));
	//    }
	//}

	//public class BudgetaryValidator : AbstractValidator<Budgetary>
	//{
	//    public BudgetaryValidator()
	//    {
	//        RuleFor(b => b.company).NotEmpty().WithMessage("Please select company");
	//        RuleFor(b => b.location).NotEmpty().WithMessage("Please select location");
	//        RuleFor(b => b.department).NotEmpty().WithMessage("Please select department");
	//        RuleFor(b => b.section).NotEmpty().WithMessage("Please select section");
	//        RuleFor(b => b.subsection).NotEmpty().WithMessage("Please select sub section");
	//        RuleFor(b => b.clause).NotEmpty().WithMessage("Please select clause");
	//        RuleFor(b => b.nfaamount).NotEmpty().WithMessage("Please enter nfa amount");
	//        RuleFor(b => b.subject).NotEmpty().WithMessage("Please enter subject");

	//        RuleFor(b => b.budgetdetails).NotNull().SetValidator(new BudgetDetailsValidator()!).When(x => x.section == "2 : CAPEX and OPEX");

	//        RuleFor(b => b.background).NotEmpty().WithMessage("Please enter background");
	//        RuleFor(b => b.details).NotEmpty().WithMessage("Please enter details");
	//        RuleFor(b => b.proposal).NotEmpty().WithMessage("Please enter proposal");

	//    }
	//}

	//public class BudgetDetailsValidator : AbstractValidator<BudgetDetails>
	//{
	//    public BudgetDetailsValidator()
	//    {
	//        RuleFor(b => b.budgetcode).NotEmpty().WithMessage("Please enter budget code");
	//        RuleFor(b => b.budget).NotEmpty().WithMessage("Please select budget");
	//        RuleFor(b => b.budgettype).NotEmpty().WithMessage("Please select budget type");
	//        RuleFor(b => b.capextype).NotEmpty().WithMessage("Please select capex type");
	//        RuleFor(b => b.simplepayback).NotEmpty().WithMessage("Please enter simple payback");
	//        RuleFor(b => b.discountedpayback).NotEmpty().WithMessage("Please enter discounted payback");
	//        RuleFor(b => b.netpresentvalueincr).NotEmpty().WithMessage("Please enter net present value in cr");
	//        RuleFor(b => b.projectirr).NotEmpty().WithMessage("Please enter project irr");
	//        RuleFor(b => b.equityirr).NotEmpty().WithMessage("Please enter equity irr");
	//        RuleFor(b => b.roce).NotEmpty().WithMessage("Please enter roce");
	//        RuleFor(b => b.projectduration).NotEmpty().WithMessage("Please enter project duration");
	//        RuleFor(b => b.tat).NotEmpty().WithMessage("Please enter tat");
	//        RuleFor(b => b.wbscreation).NotEmpty().WithMessage("Please enter wbs creation");
	//        RuleFor(b => b.raisingpr).NotEmpty().WithMessage("Please enter raising pr");
	//        RuleFor(b => b.prapproval).NotEmpty().WithMessage("Please enter pr approval");
	//        RuleFor(b => b.commnegotiation).NotEmpty().WithMessage("Please enter commercial negotiation");
	//        RuleFor(b => b.commnafaapproval).NotEmpty().WithMessage("Please enter commercial approval");
	//        RuleFor(b => b.porelease).NotEmpty().WithMessage("Please enter po release");
	//        RuleFor(b => b.projectenddate).NotEmpty().WithMessage("Please select project end date");
	//    }
}